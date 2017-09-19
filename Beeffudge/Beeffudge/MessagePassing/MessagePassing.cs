using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace Beeffudge.MessagePassing
{
    class MessagePassing
    {
        public const int SUBSCRIBER = 1;
        public const int PUBLISHER = 2;
        private ZmqContext _context;
        private ZmqSocket _socket;
        private string _IP = string.Empty;
        private string _port = "5556";
        private int _role = -1;
        private string _subscribeCode = "12345";

        /// <summary>
        /// Use class constants 'SUBSCRIBER' or 'PUBLISHER'.
        /// </summary>
        /// <param name="role"></param>
        public MessagePassing(int role)
        {
            // Set role type:
            _role = role;

            // Pick socket type:
            SocketType socketType = _role == SUBSCRIBER
                ? SocketType.SUB
                : SocketType.PUB;

            // Create context:
            _context = ZmqContext.Create();

            // Create socket:
            _socket = _context.CreateSocket(socketType);
        }

        /// <summary>
        /// Set ip address to whom we're sending messages.
        /// </summary>
        /// <param name="addr"></param>
        public void SetIPAndPort(string addr, string port)
        {
            if (Int32.TryParse(port, out int port_int))
                _port = port;

            _IP = "tcp://" + addr + ":" + _port;
        }

        /// <summary>
        /// Set the code that you want to subscribe to.
        /// </summary>
        /// <param name="code"></param>
        public void SetSubscribeCode(string code) {
            if (Int32.TryParse(code, out int c))
                _subscribeCode = code;
        }

        /// <summary>
        /// Connect as publisher or subscriber, 
        /// depending on the role passed to constructor.
        /// </summary>
        public void Connect()
        {
            // Connect or Bind depending on the role:
            switch (_role)
            {
                case SUBSCRIBER:
                    {
                        _socket.Connect(_IP);
                        _socket.Subscribe(Encoding.UTF8.GetBytes(_subscribeCode));
                        break;
                    }
                case PUBLISHER:
                    {
                        _socket.Bind(_IP);
                        break;
                    }
                default:
                    break;
            }
        }

        public void SendMessage(string msg)
        {
            var updateFrame = new Frame(Encoding.UTF8.GetBytes(_subscribeCode + " " + msg));
            _socket.Send(updateFrame);
        }

        public string GetMessage() {
            var receivedFrame = _socket.ReceiveFrame();
            return Encoding.UTF8.GetString(receivedFrame);
        }

        #region Disconnect & Dispose
        /// <summary>
        /// Disconnect and dispose the socket.
        /// </summary>
        public void DisconnectAndDispose()
        {
            Disconnect();
            Dispose();
        }

        /// <summary>
        /// Disconnect from the connected IP address.
        /// </summary>
        private void Disconnect()
        {
            _socket.Disconnect(_IP);
        }

        /// <summary>
        /// Dispose the socket used.
        /// </summary>
        private void Dispose()
        {
            _socket.Dispose();
        }
        #endregion Disconnect & Dispose
    }
}
