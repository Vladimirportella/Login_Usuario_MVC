using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Messages.Contracts
{
    public interface IEmailService
    {
        void EnviarMensagem(string destinatario, string assunto, string mensagem);
    }
}
