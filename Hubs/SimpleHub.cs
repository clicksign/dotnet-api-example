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

			var clicksign = new Clicksign.Clicksign();
			var list = clicksign.List();

			Console.WriteLine (list.Count);
			Send (list.Count.ToString());
		}
	}
}

