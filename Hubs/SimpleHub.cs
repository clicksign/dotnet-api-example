using System;
using Microsoft.AspNet.SignalR;

namespace ClickSign.APIClientTest
{
	public class SimpleHub : Hub
	{
		public void Send(string message)
		{
			Clients.All.addMessage (message);
		}

		public void StartMessages(){
			Send ("oi");
			Send ("oi");
			Send ("oi");
		}
	}
}

