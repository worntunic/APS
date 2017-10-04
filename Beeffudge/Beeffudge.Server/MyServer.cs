using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZeroMQ;

namespace Beeffudge.Server
{
    class MyServer
    {

        #region moja smernica // +nj
        // Uspostavi konekciju:
        // Osluskuj za konektovane korisnike
        // Za escape simbol pokrenuti igru ("START")
        // Svim korisnicima proslediti pitanje
        // Cekati odgovor od svih klijenata
        // Evaluirati odgovore
        // Azurirati poene
        // Poslati preko publisher-a svim korisnicima, poene

        // Sa druge strane:
        // Osluskuj korisnike za neku primljenu poruku
        // Prosledi primljenu poruku svima
        #endregion moja smernica // +nj

        #region CONSTANTS

        // Socket IDs:
        // Publisher for received chat messages:
        private const int PUB_CHAT = 0;
        // Request for chat message (from single user):
        private const int REQ_CHAT_MSG = 1;
        // Publisher for questions:
        private const int PUB_QUESTION = 2;
        // Request for typed answer on a question:
        private const int REQ_ANSWER = 4;
        // Request for picked choice:
        private const int REQ_CHOICE = 8;
        // Publisher for points:
        private const int PUB_POINTS = 16;
        // Request for player name:
        private const int REQ_PLAYER = 32;

        // Ports:
        // Port # for chat message publishing:
        private const string PORT_CHAT = "5555";
        // Port # for incoming chat messages:
        private const string PORT_MSG = "5556";
        // Port # for publishing questions:
        private const string PORT_QUESTION = "5557";
        // Port # for receiving an answer:
        private const string PORT_ANSWER = "5558";
        // Port # for receiving picked choice:
        private const string PORT_CHOICE = "5559";
        // Port # for publishing points:
        private const string PORT_POINTS = "5560";
        // Port # for receiving player names:
        private const string PORT_PLAYER = "5561";

        #endregion CONSTANTS

        #region PRIVATE VARIABLES

        // Placeholder for our message workers:
        private Dictionary<int, MessagePassing> dictSockets
                = new Dictionary<int, MessagePassing>();

        #endregion PRIVATE VARIABLES

        #region CONNECTION

        void Connect()
        {
            // Create and add our needed message workers:
            dictSockets.Add(PUB_CHAT, new MessagePassing(MessagePassing.PUBLISHER));
            dictSockets.Add(REQ_CHAT_MSG, new MessagePassing(MessagePassing.REQUEST));
            dictSockets.Add(PUB_QUESTION, new MessagePassing(MessagePassing.PUBLISHER));
            dictSockets.Add(REQ_ANSWER, new MessagePassing(MessagePassing.REQUEST));
            dictSockets.Add(REQ_CHOICE, new MessagePassing(MessagePassing.REQUEST));
            dictSockets.Add(PUB_POINTS, new MessagePassing(MessagePassing.PUBLISHER));
            dictSockets.Add(REQ_PLAYER, new MessagePassing(MessagePassing.REQUEST));

            // Setup our message workers:
            SetupPlayer();
            SetupChatPUB();
            SetupChatREQ();
            SetupQuestionPUB();
            SetupAnswerREQ();
            SetupChoiceREQ();
            SetupPointsPUB();
        }

        #endregion CONNECTION

        #region SOCKET SETUP
        private void SetupChatPUB()
        {
            #region CHAT MESSAGE PUBLISHER
            {
                MessagePassing msgPass
                    = dictSockets.Where(x => x.Key == PUB_CHAT)
                    .FirstOrDefault().Value;
                msgPass.SetIP("*"); // Listen to all incoming;
                msgPass.SetPort(PORT_CHAT);
                msgPass.Connect();

                // Listen to the port for chat message:
            }
            #endregion CHAT MESSAGE PUBLISHER
        }
        private void SetupChatREQ()
        {
            #region REQUEST CHAT MESSAGE
            {
                MessagePassing msgPass
                    = dictSockets.Where(x => x.Key == REQ_CHAT_MSG)
                   .FirstOrDefault().Value;
                msgPass.SetIP("*"); // Listen to all incoming;
                msgPass.SetPort(PORT_MSG);
                msgPass.Connect();
            }
            #endregion REQUEST CHAT MESSAGE
        }
        private void SetupQuestionPUB()
        {
            #region PUBLISHER FOR QUESTIONS
            {
                MessagePassing msgPass
                    = dictSockets.Where(x => x.Key == PUB_QUESTION)
                   .FirstOrDefault().Value;
                msgPass.SetIP("*"); // Listen to all incoming;
                msgPass.SetPort(PORT_QUESTION);
                msgPass.Connect();
            }
            #endregion PUBLISHER FOR QUESTIONS
        }
        private void SetupAnswerREQ()
        {
            #region REQUEST FOR ANSWERS
            {
                MessagePassing msgPass
                    = dictSockets.Where(x => x.Key == REQ_ANSWER)
                   .FirstOrDefault().Value;
                msgPass.SetIP("*"); // Listen to all incoming;
                msgPass.SetPort(PORT_ANSWER);
                msgPass.Connect();
            }
            #endregion REQUEST FOR ANSWERS
        }
        private void SetupChoiceREQ()
        {
            #region REQUEST FOR CHOICE
            {
                MessagePassing msgPass
                    = dictSockets.Where(x => x.Key == REQ_CHOICE)
                   .FirstOrDefault().Value;
                msgPass.SetIP("*"); // Listen to all incoming;
                msgPass.SetPort(PORT_CHOICE);
                msgPass.Connect();
            }
            #endregion REQUEST FOR CHOICE
        }
        private void SetupPointsPUB()
        {
            #region PUBLISHER FOR POINTS
            {
                MessagePassing msgPass
                    = dictSockets.Where(x => x.Key == PUB_POINTS)
                   .FirstOrDefault().Value;
                msgPass.SetIP("*"); // Listen to all incoming;
                msgPass.SetPort(PORT_POINTS);
                msgPass.Connect();
            }
            #endregion PUBLISHER FOR POINTS
        }
        private void SetupPlayer()
        {
            #region REQUEST FOR PLAYER NAME
            {
                MessagePassing msgPass
                    = dictSockets.Where(x => x.Key == REQ_PLAYER)
                   .FirstOrDefault().Value;
                msgPass.SetIP("*"); // Listen to all incoming;
                msgPass.SetPort(PORT_PLAYER);
                msgPass.Connect();
            }
            #endregion REQUEST FOR PLAYER NAME
        }
        #endregion SOCKET SETUP

        #region QUESTION & ANSWER

        private void PublishQuestion()
        {
            // TODO: Logika za odabir pitanja i slanje:

            // Slanje:
            // ili neki laksi format za parsiranje.
            string question = "Q:Ko je ____ ? A:PR1, W:LIE1... ";

            // Broadcast question
            dictSockets[PUB_QUESTION].SendMessage(question);
        }

        private void ReqAnswer()
        {

            // TODO: Own thread!
            string answer = "name: answer";
            while (true)
            {
                dictSockets[REQ_ANSWER].SendMessage("#answer#");
                answer = dictSockets[REQ_ANSWER].GetMessage();
                Console.WriteLine("Thread: " + answer);

                // TODO: Evaluate answers!
            }
        }

        private void ReqChoice()
        {
            string choice = "name: Button.Text";
            // TODO: Own thread!
            while (true)
            {
                dictSockets[REQ_CHOICE].SendMessage("#choice#");
                choice = dictSockets[REQ_CHOICE].GetMessage();
            }
        }

        #endregion QUESTION & ANSWER

        #region CHAT MESSENGER

        private void ReqChatMessage()
        {

            // TODO: Own thread!
            while (true)
            {
                dictSockets[REQ_CHAT_MSG].SendMessage("#msg#");
                string msg = dictSockets[REQ_CHAT_MSG].GetMessage();

                if (msg.Equals("START"))
                {
                    // TODO: Start game!
                }
                else
                    PublishChatMessage(msg);
            }
        }

        private void PublishChatMessage(string msg)
        {
            // add username somehow e.g. 'name: msg'
            // TODO: Username should be posted with the message!
            dictSockets[PUB_CHAT].SendMessage(msg);
        }

        #endregion CHAT MESSENGER

        #region SCORE & USERNAME

        // 'score' should be formatted like:
        // name1: #
        // name2: #
        // etc.
        private void PublishScore(string score)
        {
            dictSockets[PUB_POINTS].SendMessage(score);
        }

        private void GetPlayerUsername()
        {
            // TODO: Own thread!
            while (true)
            {
                // Each player should only once (per login) enter username
                // and send it. Keep the socket listening for new arrivals:
                dictSockets[REQ_PLAYER].SendMessage("#username#");
                string username = dictSockets[REQ_PLAYER].GetMessage();
            }
        }

        #endregion SCORE & USERNAME


        // Master (STARTER) method for our server:
        public void Start()
        {
            // Create & configure sockets:
            Connect();

            // Thread for requesting user's username:
            Thread reqUserUsername = new Thread(() => GetPlayerUsername());
            reqUserUsername.Start();

            // Thread for requesting chat messages:
            Thread reqChatMessageThread = new Thread(() => ReqChatMessage());
            reqChatMessageThread.Start();

            // Thread for requesting an answer for the question:
            Thread reqAnswerThread = new Thread(() => ReqAnswer());
            reqAnswerThread.Start();

            // Thread for requesting picked choices:
            Thread reqChoiceThread = new Thread(() => ReqChoice());
            reqChoiceThread.Start();

            // TODO: Add game logic calls below!

            // In question thread, use timer 
        }
    }
}
