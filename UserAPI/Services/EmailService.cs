using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string[] remittee, string subject, int userId, string code)
        {
            Message message = new Message(remittee, subject, userId, code);
            var messageEmail = CreateBodyEmail(message);
            SendEmail(messageEmail);
        }

        private void SendEmail(MimeMessage messageEmail)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(
                        _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);

                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(
                        _configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));

                    client.Send(messageEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateBodyEmail(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(
                new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            emailMessage.To.AddRange(message.Remittee);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };
            return emailMessage; 
        }
    }
}
