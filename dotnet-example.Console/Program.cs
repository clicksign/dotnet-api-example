using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clicksign;
using System.IO;
using System.Threading;

namespace dotnet_example.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var self = new Program();
            self.StartMessages();
        }

        private Clicksign.Clicksign _clicksign;

        public Program()
        {
            _clicksign = new Clicksign.Clicksign();
        }

        public void Send(string message)
        {
            System.Console.WriteLine(message);
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
            var document = ListDocuments().First();
            Send("Downloading o primeiro documento");
            DownloadDocument(document.Key);

            Send("Fim");
            System.Console.ReadKey();
        }

        private void DownloadDocument(string p)
        {
            DownloadResponse downloadResponse = new DownloadResponse();
            do
            {
                Thread.Sleep(1000);
                downloadResponse = _clicksign.Download("Key do document");
            } while (!downloadResponse.isActionFinished);

            var numBytes = downloadResponse.binaryFile.Count();
            Send("Baixado arquivo com "+numBytes+" bytes");

        }

        private IList<Document> ListDocuments()
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

            return list;
        }

        public void UploadDocument()
        {
            //Envio através do caminho do arquivo
            string filePath = @"Documento-Teste.docx";

            _clicksign.Upload(filePath);


        }
    }
}
