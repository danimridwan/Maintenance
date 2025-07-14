using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MaintenanceWebApp.Data;
using MimeKit;


namespace MaintenanceWebApp.Services
{
    public interface IMailerService
    {
        Task SendEmailAsync(string email, string subject, string body);
    }

    public class MailerService : IMailerService
    {
        private readonly SMTPSettings _smtpSettings;
        private readonly IWebHostEnvironment _env;

        public MailerService(IOptions<SMTPSettings> smtpSettings, IWebHostEnvironment env)
        {
            _smtpSettings = smtpSettings.Value;
            _env = env;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                string[] to = email.Split(",");
                //if (to.Length > 1)
                //{
                //    for (int i = 0; i < to.Length - 1; i++)
                //    {
                //        //message.To.Add(new MailboxAddress(to[i]));
                //        message.To.Add(new MailboxAddress(to[i], to[i]));
                //    }
                //}
                //else
                //{
                //    message.To.Add(new MailboxAddress(email, email));
                //}
                //single recipietn
                message.To.Add(new MailboxAddress(email, email));

                message.Subject = "subject";
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (_env.IsDevelopment())
                    {
                        //await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                        await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port);
                    }
                    else
                    {
                        await client.ConnectAsync(_smtpSettings.Server);
                    }

                    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
