using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace TesteWebSocket
{
    class testeComportamentoWS : WebSocketBehavior
    {
        protected override void OnMessage(WebSocketSharp.MessageEventArgs e)
        {
            string msg = "ficou vazio";

            switch (e.Data)
            {
                case "1":
                    msg = "Dia 1";
                    break;
                case "2":
                    msg = "Dia 2";
                    break;
                default:
                    msg = "nenhum dia";
                    break;
            }

            Send(msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var wsServer = new WebSocketServer("ws://localhost:2000");
            wsServer.AddWebSocketService<testeComportamentoWS>("/");
            wsServer.Start();
            Console.ReadKey();
            wsServer.Stop();
        }
    }
}
