using Core.Infrastructure.Exceptions;
using Core.Infrastructure.Utils;
using Core.User.Interfaces;
using Core.User.Validators;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class UpdateUser : PasswordEncryptionToDecrypt, IUpdateUser
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailValidate _validateEmail;
        private readonly IValidateSocialNumber _validateSocialNumber;
        private readonly UserValidator _userValidator;

        public UpdateUser(IUserRepository userRepository, IEmailValidate validateEmail, IValidateSocialNumber validateSocialNumber)
        {
            _userRepository = userRepository;
            _validateEmail = validateEmail;
            _validateSocialNumber = validateSocialNumber;
            _userValidator = UserValidator.Validate().UpdateUserValidator(validateEmail, validateSocialNumber);
        }

        public async Task<Model.User> Execute(Model.User user)
        {
            var UserValidated = _userValidator.Validate(user);

            if (!UserValidated.IsValid)
                throw new ApiDomainException(UserValidated.Errors);

            // criptografia de senha
            user.Password = PasswordEncryptionToDecrypt.EncryptPassword(user.Password);

            user.Status = true;

            await _userRepository.UpdateAsync(user);

            return user;
        }
    }
}
