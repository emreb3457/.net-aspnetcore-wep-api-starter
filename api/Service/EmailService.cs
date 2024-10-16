using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interface;

namespace api.Service
{
    public class EmailService
    {
        public async Task SendPasswordResetLink(string email, string token)
        {
            // Burada e-posta gönderim servisi entegre edilecek
            // Örnek: SMTP kullanarak e-posta gönderimi
            await Task.CompletedTask;
        }
    }

}