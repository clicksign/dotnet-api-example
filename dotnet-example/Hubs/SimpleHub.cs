using System;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Web;
using Microsoft.AspNet.SignalR;
using dotnet_example.Core;

namespace dotnet_example.Hubs
{
    public class SimpleHub : Hub
    {

        public void StartMessages()
        {
            new ClickSignExampleCoreImplementation(this).StartAllMethods();
        }

        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }

        private class ClickSignExampleCoreImplementation : ClickSignExampleCore
        {
            private SimpleHub _simpleHub;

            public ClickSignExampleCoreImplementation(SimpleHub outerInstance)
            {
                _simpleHub = outerInstance;
            }

            public override void Send(string message)
            {
                _simpleHub.Send(message);
            }

            protected override string GetDocumentFilePath()
            {
                return System.Web.HttpContext.Current.Server.MapPath(@"..\Documento-Teste.docx");
            }
        }
    }
}




