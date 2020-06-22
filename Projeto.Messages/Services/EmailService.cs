using Projeto.Messages.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Projeto.Messages.Services
{
    public class EmailService : IEmailService
    {
        private const string conta = "cotiexemplo2@gmail.com";
        private const string senha = "@coticoti@";
        private const string smtp = "smtp.gmail.com";
        private const int porta = 587;

        public void EnviarMensagem(string destinatario, string assunto, string mensagem)
        {
            var mail = new MailMessage(conta, destinatario);
            mail.Subject = assunto;
            mail.Body = mensagem;

            var client = new SmtpClient(smtp, porta);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(conta, senha);
            client.Send(mail);
        }
             
    }
    
}
