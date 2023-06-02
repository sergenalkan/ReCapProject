using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).Must(EndWithEmail).WithMessage("Mail adresi olarak sadece gmail kabul edilmektedir.");
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8).MaximumLength(32).WithMessage("En az 8 en fazla 32 karakter kullanılabilir.");
            RuleFor(u => u.Password).Must(CharacterPassword).WithMessage("En az 1 adet büyük ve küçük harf, karakter ve sayı kullanmanız gerekmektedir.");
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
        }    

        private bool CharacterPassword(string arg)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSybols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            var isValidated = hasNumber.IsMatch(arg) && hasUpperChar.IsMatch(arg) && hasLowerChar.IsMatch(arg) && hasSybols.IsMatch(arg);
            return isValidated;
        }

        private bool EndWithEmail(string arg)
        {
            return arg.EndsWith("@gmail.com");
        }
    }
}
