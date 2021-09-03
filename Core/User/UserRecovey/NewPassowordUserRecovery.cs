using Core.Infrastructure.Exceptions;
using Core.Infrastructure.Utils;
using Core.User.Interfaces;
using Core.User.UserRecovey.Interfaces;
using Core.User.UserRecovey.Model;
using DataAcess.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.UserRecovey
{
    public class NewPassowordUserRecovery : PasswordEncryptionToDecrypt, INewPassowordUserRecovery
    {
        readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        public NewPassowordUserRecovery(IUserRepository userRepository, IPasswordValidator passwordValidator)
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
        }

        public async Task<bool> Execute(UserRecoveryPassword userRecoveryPassword)
        {
            // buscar o Usuario por 
            var user = await _userRepository.GetByIdAsync(userRecoveryPassword.UserId);

            // Verificar se as Senhas COnferem
            if (userRecoveryPassword.Password != userRecoveryPassword.PasswordConfirm)
            {
                IList<ValidationFailure> validationList = new List<ValidationFailure>();
                ValidationFailure validation = new ValidationFailure("Senha novas ", "As Senhas Novas não Confere.");
                validationList.Add(validation);

                throw new ApiDomainException(validationList);

            }
            bool isValidate = _passwordValidator.IsPasswordValidator(userRecoveryPassword.Password);

            if (!isValidate)
            {
                IList<ValidationFailure> validationList = new List<ValidationFailure>();
                ValidationFailure validation = new ValidationFailure("Senha fora do padrão", "A senha não está de acordo com os padrões de validação. Minimo de 8 caracteres e máximo de 30. Sendo obrigatória 1 letra maiúscula, 1 letra minúscula, 1 número e 1 caractere especial.");
                validationList.Add(validation);

                throw new ApiDomainException(validationList);
            }

            // passar Senha do Usuario a nova senha 
            user.Password = userRecoveryPassword.Password = EncryptPassword(userRecoveryPassword.Password);

            user.Status = true;
            // Atualizar o Usuario
            return await _userRepository.UpdateAsync(user);
        }
    }
}
