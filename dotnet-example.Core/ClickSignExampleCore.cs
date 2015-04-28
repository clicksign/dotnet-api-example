using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clicksign;
using System.Threading;

namespace dotnet_example.Core
{
    public abstract class ClickSignExampleCore
    {
        protected Clicksign.Clicksign _clicksign;

        public ClickSignExampleCore()
        {
            _clicksign = new Clicksign.Clicksign();
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

            Send("Fim");
        }

        private void DownloadDocument(string p)
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

        protected virtual string GetDocumentFilePath()
        {
            string filePath = @"Documento-Teste.docx";
            return filePath;
        }
    }
}
