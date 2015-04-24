using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clicksign;
using System.IO;

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
            ListDocuments();

            Send("Fim");
            System.Console.ReadKey();
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
            string filePath = @"Documento-Teste.docx";

            _clicksign.Upload(filePath);


        }
    }
}
