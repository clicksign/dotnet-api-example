using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using dotnet_example.Core;

namespace dotnet_example.Tests
{
    [TestClass]
    public class UnitTest1 : ClickSignExampleCore
    {

        public override void Send(string message)
        {
            Console.WriteLine(message);
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

      
    }
}
