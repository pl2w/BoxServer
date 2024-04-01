using BoxServer.Behaviours.OpHandlers;
using BoxServer.Protocols;
using BoxServer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BoxServer.Behaviours
{
    public class Server
    {
        public readonly HttpListener server = new HttpListener();
        public const string url = "http://127.0.0.1:8080/";

        public Dictionary<OperationCode, IOperation> opHandlers = new Dictionary<OperationCode, IOperation>()
        {
            { OperationCode.OPCODE_LOGIN_ANDROID, new AndroidLoginHandler() },
            { OperationCode.OPCODE_COMPLETE_GUIDE, new CompleteGuideHandler() },
            { OperationCode.OPCODE_VIEW_COMMENT, new ViewCommentHandler() }
        };

        public void InitServer()
        {
            Console.WriteLine($"Starting server at {url}");
            server.Prefixes.Add(url);
            server.Start();

            Task listener = ServerListener();
            listener.GetAwaiter().GetResult();

            server.Close();
        }

        public async Task ServerListener()
        {
            while (true)
            {
                HttpListenerContext ctx = await server.GetContextAsync();

                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                if (req.InputStream == null)
                    return;

                MemoryStream stream = new MemoryStream();
                req.InputStream.CopyTo(stream);
                stream.Seek(0, SeekOrigin.Begin);

                byte[] recData = stream.ToArray();
                byte[] dataBeforeFixing = DES_Encryption.decode(recData);

                Console.WriteLine(Encoding.ASCII.GetString(dataBeforeFixing));
                Console.WriteLine(Encoding.ASCII.GetString(DES_Encryption.decode(dataBeforeFixing)));

                byte[] data = dataBeforeFixing;
                if (dataBeforeFixing.Length > 10) // fuck you
                {
                    data = new byte[dataBeforeFixing.Length - 10]; // remove garbage stuff fuck you
                    for (int i = 0; i < dataBeforeFixing.Length - 10; i++)
                        data[i] = dataBeforeFixing[i];
                }

                Console.WriteLine(Encoding.ASCII.GetString(data));

                int opCode = int.Parse(req.RawUrl.Substring(1));

                Console.WriteLine($"Received '{(OperationCode)opCode}'");

                if(opHandlers.TryGetValue((OperationCode)opCode, out IOperation operationHandler))
                {
                    operationHandler.OperationReceived(data, ctx, req, resp);
                    continue;
                }

                Console.WriteLine($"No handler found for '{(OperationCode)opCode}'");

                msg_response response2 = new msg_response();
                response2.res = -1;

                PacketUtils.SendPacketToClient(response2, resp.OutputStream);
            }
        }
    }
}
