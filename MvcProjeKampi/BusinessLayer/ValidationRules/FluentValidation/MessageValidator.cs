using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz").EmailAddress().WithMessage("Geçerli bir e-posta gerekli");
            RuleFor(m => m.SenderMail).NotEmpty().WithMessage("Gönderici adresini boş geçemezsiniz").EmailAddress().WithMessage("Geçerli bir e-posta gerekli");
            RuleFor(m => m.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz").Must(m=>m.Length>3 && m.Length<100).WithMessage("Girdiğiniz karakter sayısı 3 ve 100 arasında olmalı");
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");
            RuleFor(c => c.ReceiverMail).EmailAddress().WithMessage("Alıcı adresi mail adresi türünde olmalıdır!");
            RuleFor(c => c.SenderMail).EmailAddress().WithMessage("Gönderici adresi mail adresi türünde olmalıdır!");
        }
    }
}
