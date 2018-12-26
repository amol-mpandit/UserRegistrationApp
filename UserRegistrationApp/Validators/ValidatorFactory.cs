
using System;
using System.Collections.Generic;
using FluentValidation;
using UserRegistrationApp.Models;

namespace UserRegistrationApp.Validators
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static readonly Dictionary<Type, IValidator> Validators = new Dictionary<Type, IValidator>();

        static ValidatorFactory()
        {
            Validators.Add(typeof(IValidator<UserViewModel>), new UserViewModelValidator());
            Validators.Add(typeof(IValidator<LoginViewModel>), new LoginViewModelValidator());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (Validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return null;
        }
    }
}