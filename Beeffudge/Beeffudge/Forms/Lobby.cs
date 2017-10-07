using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeroMQ;


namespace Beeffudge.Forms
{
    public partial class Lobby : Form
    {
        // Socket IDs:
        // Publisher for received chat messages:
        public static readonly int SUB_CHAT = 0;
        // Request for chat message (from single user):
        public static readonly int REP_CHAT_MSG = 1;
        // Publisher for questions:
        public static readonly int SUB_QUESTION = 2;
        // Request for typed answer on a question:
        public static readonly int REP_ANSWER = 4;
        // Request for picked choice:
        public static readonly int REP_CHOICE = 8;
        // Publisher for points:
        public static readonly int SUB_POINTS = 16;
        // Request for player name:
        public static readonly int REP_PLAYER = 32;

        // Ports:
        // Port # for chat message publishing:
        public static readonly string PORT_CHAT = "5555";
        // Port # for incoming chat messages:
        public static readonly string PORT_MSG = "5556";
        // Port # for publishing questions:
        public static readonly string PORT_QUESTION = "5557";
        // Port # for receiving an answer:
        public static readonly string PORT_ANSWER = "5558";
        // Port # for receiving picked choice:
        public static readonly string PORT_CHOICE = "5559";
        // Port # for publishing points:
        public static readonly string PORT_POINTS = "5560";
        // Port # for receiving player names:
        public static readonly string PORT_PLAYER = "5561";

        // e.g. "Player1: 100;Player2: 300;Player3: etc."
        public string Points = string.Empty;
        public string[] Players;

        // Placeholder for our message workers:
        private Dictionary<int, MessagePassing> dictSockets
                = new Dictionary<int, MessagePassing>();

        public Dictionary<int, MessagePassing> DictSockets { get { return dictSockets;  } set { dictSockets = value; } }

        public string _Name { get; set; }
        private string IP { get; set; }

        public Lobby(string Name, string IP, bool showPlay = false)
        {
            this._Name = Name;
            this.IP = IP;

            InitializeComponent();

            btnPlay.Visible = showPlay;

            // Socket setup:
            SetupMessageWorkers();

            // Send your username to the server:
            SendUsername();

            // Turn on subscribers:
            Thread getPointsThread = new Thread(() => GetPoints());
            getPointsThread.Start();

            Thread playButtonThread = new Thread(() => EnableDisablePlayButton());
            playButtonThread.Start();

            Thread chatSubscriberThread = new Thread(() => SetChatSubscriber());
            chatSubscriberThread.Start();
        }

        #region POINTS, GAME & PLAYBUTTON

        // Own thread!
        private void GetPoints() {
            while (true)
            {
                Points = dictSockets[SUB_POINTS].GetMessage();
            }
        }
        
        // Own thread!
        private void EnableDisablePlayButton() {
            int numbOfPlayers = 0;
            btnPlay.Enabled = false;
            while (numbOfPlayers < 2) {
                numbOfPlayers = GetNumberOfPlayers();
            }
            btnPlay.Enabled = true;
        }

        private void StartGame() {
            SendUsername("#start#");
        }

        #endregion POINTS, GAME & PLAYBUTTON

        #region PLAYER

        private int GetNumberOfPlayers()
        {
            return GetPlayerNames().Length;
        }

        // Converts names in Points to string array 
        // containing only players' usernames:
        private string[] GetPlayerNames()
        {
            string[] names = Points.Split(';');

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Substring(0, names[i].IndexOf(':'));
            }

            return names;
        }

        private void SetPlayerList() {
            string[] names = GetPlayerNames();
            for (int i = 0; i < GetNumberOfPlayers(); i++) {
                lvPlayers.Items[i].Text = names[i];
            }
        }

        // Send username, or start game command:
        private void SendUsername(string startGame = "")
        {
            string dummy = dictSockets[REP_PLAYER].GetMessage();

            if (startGame.Equals(""))
                dictSockets[REP_PLAYER].SendMessage(_Name);
            // Start game:
            else
                dictSockets[REP_PLAYER].SendMessage(startGame);
        }

        #endregion PLAYER

        #region MESSAGING

        // Own thread!
        private void SetChatSubscriber()
        {
            string exit = string.Empty;
            while (true)
            {
                exit = dictSockets[SUB_CHAT].GetMessage();
                // Let the thread die when the game starts:
                if (exit.Equals("#start#"))
                    break;
                txtChat.Text = txtChat.Text + dictSockets[SUB_CHAT].GetMessage() + Environment.NewLine;
            }
        }

        private void SendChatMessage()
        {
            string dummy = dictSockets[REP_CHAT_MSG].GetMessage();
            // Send as 'Name: msg'
            dictSockets[REP_CHAT_MSG].SendMessage(string.Format("{0}: {1}", _Name, txtSend.Text.ToString()));
        }

        #endregion MESSAGING

        #region SOCKET SETUP

        private void SetupMessageWorkers()
        {
            dictSockets.Add(SUB_CHAT, new MessagePassing(MessagePassing.SUBSCRIBER));
            dictSockets.Add(REP_CHAT_MSG, new MessagePassing(MessagePassing.REPLY));
            dictSockets.Add(REP_ANSWER, new MessagePassing(MessagePassing.REPLY));
            dictSockets.Add(SUB_QUESTION, new MessagePassing(MessagePassing.SUBSCRIBER));
            dictSockets.Add(REP_CHOICE, new MessagePassing(MessagePassing.REPLY));
            dictSockets.Add(REP_PLAYER, new MessagePassing(MessagePassing.REPLY));

            SetupChatSUB();
            SetupChatREP();
            SetupAnswerREP();
            SetupQuestionSUB();
            SetupChoiceREP();
            SetupPlayerREP();
        }

        private void SetupPlayerREP()
        {
            dictSockets[REP_PLAYER].SetIP(IP);
            dictSockets[REP_PLAYER].SetPort(PORT_PLAYER);
            dictSockets[REP_PLAYER].Connect();
        }

        private void SetupChoiceREP()
        {
            dictSockets[REP_CHOICE].SetIP(IP);
            dictSockets[REP_CHOICE].SetPort(PORT_CHOICE);
            dictSockets[REP_CHOICE].Connect();
        }

        private void SetupQuestionSUB()
        {
            dictSockets[SUB_QUESTION].SetIP(IP);
            dictSockets[SUB_QUESTION].SetPort(PORT_QUESTION);
            dictSockets[SUB_QUESTION].Connect();
        }

        private void SetupAnswerREP()
        {
            dictSockets[REP_ANSWER].SetIP(IP);
            dictSockets[REP_ANSWER].SetPort(PORT_ANSWER);
            dictSockets[REP_ANSWER].Connect();
        }

        private void SetupChatREP()
        {
            dictSockets[REP_CHAT_MSG].SetIP(IP);
            dictSockets[REP_CHAT_MSG].SetPort(PORT_MSG);
            dictSockets[REP_CHAT_MSG].Connect();
        }

        private void SetupChatSUB()
        {
            dictSockets[SUB_CHAT].SetIP(IP);
            dictSockets[SUB_CHAT].SetPort(PORT_CHAT);
            dictSockets[SUB_CHAT].Connect();
        }

        #endregion SOCKET SETUP

        #region BUTTON CONTROLS

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // TODO: Implement parameter passing between forms!
        private void btnPlay_Click(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen(this);
            StartGame();
            gameScreen.Show();
            Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Send message as: 'Username: msg'
            SendChatMessage();
            txtSend.Clear();
            txtSend.Focus();
        }

        #endregion BUTTON CONTROLS
    }
}
