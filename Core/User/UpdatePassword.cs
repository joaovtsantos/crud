using Core.Infrastructure.Exceptions;
using Core.Infrastructure.Utils;
using Core.User.Interfaces;
using DataAcess.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class UpdatePassword : PasswordEncryptionToDecrypt, IUpdatePassword
    {
        IUserRepository _userRepository;
        IPasswordValidator _passwordValidator;
        public UpdatePassword(IUserRepository userRepository, IPasswordValidator passwordValidator)
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
        }

        public async Task<bool> Execute(Model.UserModificPassword user)
        {
            var userExiste = await _userRepository.GetByIdAsync(user.UserId);
            if (userExiste == null)
            {
                IList<ValidationFailure> validationList = new List<ValidationFailure>();
                ValidationFailure validation = new ValidationFailure("Usuário não cadastrado", "Usuário não cadastrado em nossa base de Dados.");
                validationList.Add(validation);

                throw new ApiDomainException(validationList);
            }

            bool isValidate = _passwordValidator.IsPasswordValidator(user.NewPassword);

            if (!isValidate)
            {
                IList<ValidationFailure> validationList = new List<ValidationFailure>();
                ValidationFailure validation = new ValidationFailure("Senha fora do padrão", "A senha não está de acordo com os padrões de validação. Minimo de 8 caracteres e máximo de 30. Sendo obrigatória 1 letra maiúscula, 1 letra minúscula, 1 número e 1 caractere especial.");
                validationList.Add(validation);

                throw new ApiDomainException(validationList);
            }

            userExiste.Password = DecryptPassword(userExiste.Password);

            if (userExiste.Password != user.OldPassword)
            {
                IList<ValidationFailure> validationList = new List<ValidationFailure>();
                ValidationFailure validation = new ValidationFailure("Senha Antiga", "A Senha Antiga está Errada.");
                validationList.Add(validation);

                throw new ApiDomainException(validationList);
            }

            if (user.NewPassword != user.NewConfirmPassword)
            {
                IList<ValidationFailure> validationList = new List<ValidationFailure>();
                ValidationFailure validation = new ValidationFailure("Senha novas ", "As Senhas Novas não Confere");
                validationList.Add(validation);

                throw new ApiDomainException(validationList);
            }

            userExiste.Password = user.NewPassword = EncryptPassword(user.NewPassword);

            return await _userRepository.UpdateAsyncPassword(userExiste);
        }
    }
}
