using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace dotnet_example.Hubs
{
    public class SimpleHub : Hub
    {
        private Clicksign.Clicksign _clicksign;

        public SimpleHub()
        {
            _clicksign = new Clicksign.Clicksign();
        }

        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }

        public void StartMessages()
        {
            Send(".....Iniciando Requests.......");

            Send("Listando Documentos");
            ListDocuments();
            Send("Fazendo upload de um novo documento");
            UploadDocument();
            Send("Upload finalizado");
            Send("Listando novamente os documentos");
            ListDocuments();

            Send("Fim");
        }

        private void ListDocuments()
        {
            var list = _clicksign.List();

            if (list.Count > 0)
            {
                Send("Encontrei " + list.Count + " documentos, são eles: ");
                foreach (var document in list)
                {
                    Send("Documento: " + document.Name + ", data de atualizacao : " +
                         document.Updated);
                }
            }
            else
            {
                Send("Não encontrei nenhum documento");
            }
        }

        public void UploadDocument()
        {
            //Envio através do caminho do arquivo
            string filePath = System.Web.HttpContext.Current.Server.MapPath(@"..\Teste-Rodrigo.docx");

            _clicksign.Upload(filePath);


        }

 
}
}




