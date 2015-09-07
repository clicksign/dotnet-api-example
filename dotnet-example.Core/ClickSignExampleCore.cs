using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Clicksign;
using System.Threading;

namespace dotnet_example.Core
{
    public abstract class ClickSignExampleCore
    {
        protected Clicksign.Clicksign _clicksign;

        protected string _emailExample;

        public ClickSignExampleCore()
        {
            _clicksign = new Clicksign.Clicksign();
            _emailExample = ConfigurationManager.AppSettings["Clicksign-Host"];
        }

        public abstract void Send(string message);


        public void StartAllMethods()
        {
            Send(".....Iniciando Requests.......");

            Send("Listando Documentos");
            ListDocuments();
            Send("Fazendo upload de um novo documento");
            UploadDocument();
            Send("Upload finalizado");
            Send("Listando novamente os documentos");
            var key = ListDocuments().First();
            Send("Downloading o primeiro documento");
            DownloadDocument(key);
            Send("Reenviand email com o primeiro documento");
            ResendDocument(key, _emailExample, "reenviando documento");
            Send("Cancelando o primeiro documento");
            CancelDocument(key);

            Send("Fim");
        }

        public void DownloadDocument(string p)
        {
            DownloadResponse downloadResponse = new DownloadResponse();
            do
            {
                Thread.Sleep(1000);
                downloadResponse = _clicksign.Download(p);
            } while (!downloadResponse.isActionFinished);

            var numBytes = downloadResponse.binaryFile.Count();
            Send("Baixado arquivo com " + numBytes + " bytes");

        }

        public IList<String> ListDocuments()
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

            return list.Select(d => d.Key).ToList();
        }

        public void UploadDocument()
        {
            //Envio através do caminho do arquivo
            string filePath = GetDocumentFilePath();
            _clicksign.Upload(filePath);
        }

        public void ResendDocument(string key, string email, string message)
        {
            _clicksign.Resend(key, email, message);
        }
        public void CancelDocument(string key)
        {
            _clicksign.Cancel(key);
        }

        protected virtual string GetDocumentFilePath()
        {
            string filePath = @"Documento-Teste.docx";
            return filePath;
        }
    }
}
