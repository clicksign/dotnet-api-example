using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace dotnet_example.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Clicksign.Clicksign _clicksign;

        [TestInitialize]
        public void TestSetUp()
        {
            _clicksign = new Clicksign.Clicksign();
        }

        [DeploymentItem("Documento-Teste.docx")]
        [TestMethod]
        public void ShouldListDocuments()
        {
            var listBeforeUpload = ListDocuments();
            UploadDocument();
            var listAfterUpload = ListDocuments();
            Assert.AreEqual(listAfterUpload.Count, listBeforeUpload.Count + 1);
        }

        [TestMethod]
        public void ShouldUploadDocument()
        {
            UploadDocument();
        }

        private List<Clicksign.Document> ListDocuments()
        {
            var list = _clicksign.List();

            return list;
        }

        public void UploadDocument()
        {
            //Envio através do caminho do arquivo
            string filePath = @"Documento-Teste.docx";

            string path = Directory.GetCurrentDirectory();

            _clicksign.Upload(filePath);


        }
    }
}
