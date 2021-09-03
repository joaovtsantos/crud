using Core.User.Interfaces;
using DataAcess.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Validators
{
    public class UserValidator : AbstractValidator<Model.User>
    {
        public static UserValidator Validate()
        {
            return new UserValidator();
        }

        public UserValidator CreateUserValidator(IEmailValidate validateEmail, IValidateSocialNumber validateSocialNumber, IUserRepository userRepository)
        {
            RuleFor(Model => Model.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório");

            RuleFor(Model => Model.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório");

            RuleFor(Model => Model.Password)
                .NotEmpty()
                .WithMessage("A senha é obrigatória");

            RuleFor(Model => Model.SocialNumber)
                .NotEmpty()
                .WithMessage("O CPF é obrigatório");

            RuleFor(model => model)
                .Must(model => validateEmail.IsValidEmail(model.Email))
                .WithMessage("O e-mail informado não está correspondente ao formato de um e-mail");

            RuleFor(model => model)
                .Must(model => validateSocialNumber.IsSocialNumber(model.SocialNumber))
                .WithMessage("O CPF informado não está correspondente ao formato de um CPF");

            RuleFor(model => model)
               .Must(model => !userRepository.RegisteredEmail(model.Email).Result)
               .WithMessage("E-mail já cadastrado");

            RuleFor(model => model)
               .Must(model => !userRepository.RegisteredSocialNumber(model.SocialNumber).Result)
               .WithMessage("CPF já cadastrado");

            return this;
        }

        public UserValidator UpdateUserValidator(IEmailValidate validateEmail, IValidateSocialNumber validateSocialNumber)
        {
            RuleFor(Model => Model.UserId)
                .NotEmpty()
                .WithMessage("O Id é obrigatório");

            RuleFor(Model => Model.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório");

            RuleFor(Model => Model.Email)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório");

            RuleFor(Model => Model.Password)
                .NotEmpty()
                .WithMessage("A senha é obrigatória");

            RuleFor(Model => Model.SocialNumber)
                .NotEmpty()
                .WithMessage("O CPF é obrigatório");

            RuleFor(model => model)
                .Must(model => validateEmail.IsValidEmail(model.Email))
                .WithMessage("O e-mail informado não está correspondente ao formato de um e-mail");

            RuleFor(model => model)
                .Must(model => validateSocialNumber.IsSocialNumber(model.SocialNumber))
                .WithMessage("O CPF informado não está correspondente ao formato de um CPF");

            return this;
        }
    }
}
