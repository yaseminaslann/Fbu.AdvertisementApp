using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.AdvertisementApp.UI.Models;

namespace Web.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        //[Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı zorunludur");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola min 3 karakter olmalıdır");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad alanı zorunludur");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı zorunludur");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı alanı zorunludur");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı min 3 karakter olmalıdır");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parolayı Onayla alanı zorunludur");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası alanı zorunludur");

            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("Kullanıcı adı, adınızı içeremez.").When(x => x.Username != null && x.Firstname != null);

            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.");


        }

        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
