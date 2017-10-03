using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroMQ
{
    /*
     * =======================================
     * Server:  PUBLISHER
     * =======================================
     * 
     * MessagePassing mp 
     *      = new MessagePassing(int PUB/REQ)
     * mp.SetIP("*")
     * mp.SetPort(port_#)
     * mp.Connect()
     * 
     * mp.SendMessage("msg")
     * 
     * =======================================
     * Client:  SUBSCRIBER
     * =======================================
     * 
     * MessagePassing mp 
     *      = new MessagePassing(int SUB)
     * mp.SetIP("*")
     * mp.SetPort(port_#)
     * mp.SetSubscribeCode(sub_code)
     * mp.Connect()
     * 
     * mp.GetMessage()
     * 
     * =======================================
     * Server:  REQUEST
     * =======================================
     * 
     * MessagePassing mp 
     *      = new MessagePassing(int REQ)
     * mp.SetIP("*")
     * mp.SetPort(port_#)
     * mp.Connect()
     * 
     * mp.SendMessage("msg")
     * mp.GetMessage()
     * 
     * =======================================
     * Client:  REPLY
     * =======================================
     * 
     * MessagePassing mp 
     *      = new MessagePassing(int REP)
     * mp.SetIP("*")
     * mp.SetPort(port_#)
     * mp.Connect()
     * 
     * mp.GetMessage()
     * mp.SendMessage("ACK");
     */

    class MessagePassing
    {
        public static readonly string PUB_SUB_QUESTION = "1111";
        public static readonly string PUB_SUB_MESSAGE = "2222";
        public static readonly string PUB_SUB_POINTS = "3333";

        public static readonly int SUBSCRIBER = 1;
        public static readonly int PUBLISHER = 2;
        public static readonly int REQUEST = 3;
        public static readonly int REPLY = 4;

        private ZmqContext _context;
        private ZmqSocket _socket;
        private string _IP = string.Empty;
        private string _RIP = string.Empty;
        private string _port = "5556";
        private const string _prefix = "tcp://";
        private int _type;
        private string _subscribeCode = "12345";

        /// <summary>
        /// Constructor for desired param type socket.
        /// </summary>
        /// <param name="type"></param>
        public MessagePassing(int type)
        {
            _type = type;
            _context = ZmqContext.Create();
            _socket = _context.CreateSocket(GetType(type));
        }

        /// <summary>
        /// Get enum for socket type based on it's 
        /// equal constant representation.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private SocketType GetType(int type)
        {
            if (type == SUBSCRIBER)
                return SocketType.SUB;
            else if (type == PUBLISHER)
                return SocketType.PUB;
            else if (type == REQUEST)
                return SocketType.REQ;
            else //if (type == REPLY)
                return SocketType.REP;
        }

        #region IP/PORT

        /// <summary>
        /// Set port number.
        /// </summary>
        /// <param name="port"></param>
        public void SetPort(string port)
        {
            _port = port;
            InvalidateIP();
        }

        /// <summary>
        /// Set IP address.
        /// </summary>
        /// <param name="ip"></param>
        public void SetIP(string ip)
        {
            // e.g. "tcp://127.0.0.1:"
            _IP = ip;
            InvalidateIP();
        }

        /// <summary>
        /// Set ip address to whom we're sending messages.
        /// </summary>
        /// <param name="addr"></param>
        public void SetIPAndPort(string addr, string port)
        {
            if (Int32.TryParse(port, out int port_int))
                _port = port;
            _IP = addr;

            InvalidateIP();
        }

        /// <summary>
        /// Conjure the IP address used by the socket 
        /// based on the provided ip & port number.
        /// </summary>
        private void InvalidateIP()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(_prefix);
            builder.Append(_IP);
            builder.Append(':');
            builder.Append(_port);

            // REAL IP
            _RIP = builder.ToString();
        }

        #endregion IP/PORT

        #region CONNECTION

        /// <summary>
        /// Set the code that you want to subscribe to.
        /// </summary>
        /// <param name="code"></param>
        public void SetSubscribeCode(string code)
        {
            if (Int32.TryParse(code, out int c))
            {
                _subscribeCode = code;
            }
        }

        /// <summary>
        /// Method for establishing 
        /// connection with the IP:Port.
        /// </summary>
        public void Connect()
        {
            // Connect or Bind depending on the role:
            if (_type == SUBSCRIBER || _type == REPLY)
            {
                // Connect your socket to the 
                // desired 'IP:Port address':
                _socket.Connect(_RIP);

                // Subscribe to the desired code (id) to
                // receive messages from:
                if (_type == SUBSCRIBER)
                {
                    _socket.Subscribe(Encoding.UTF8.GetBytes(_subscribeCode));
                }
            }
            else if (_type == PUBLISHER || _type == REQUEST)
            {
                // Listen to the selected IP address
                // on the selected port:
                _socket.Bind(_RIP);
            }
        }

        #endregion CONNECTION

        #region SEND/GET MESSAGES 

        /// <summary>
        /// Send string message.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            Frame updateFrame
                = new Frame(Encoding.UTF8.GetBytes(message));
            _socket.Send(updateFrame);
        }

        /// <summary>
        /// Get string message.
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            Frame receiveFrame = _socket.ReceiveFrame();
            string msg = System.Text.Encoding.UTF8.GetString(receiveFrame);

            if (_type == SUBSCRIBER)
                // _subscribeCode.Length == 5 + 1 white space
                msg = msg.Substring(6);

            return msg;
        }

        #endregion SEND/GET MESSAGES

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
            _socket.Disconnect(_RIP);
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

