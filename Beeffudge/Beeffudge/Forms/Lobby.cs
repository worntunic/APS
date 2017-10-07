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
        public const int SUB_CHAT = 0;
        // Request for chat message (from single user):
        public const int REP_CHAT_MSG = 1;
        // Publisher for questions:
        public const int SUB_QUESTION = 2;
        // Request for typed answer on a question:
        public const int REP_ANSWER = 4;
        // Request for picked choice:
        public const int REP_CHOICE = 8;
        // Publisher for points:
        public const int SUB_POINTS = 16;
        // Request for player name:
        public const int REP_PLAYER = 32;

        // Ports:
        // Port # for chat message publishing:
        public const string PORT_CHAT = "5555";
        // Port # for incoming chat messages:
        public const string PORT_MSG = "5556";
        // Port # for publishing questions:
        public const string PORT_QUESTION = "5557";
        // Port # for receiving an answer:
        public const string PORT_ANSWER = "5558";
        // Port # for receiving picked choice:
        public const string PORT_CHOICE = "5559";
        // Port # for publishing points:
        public const string PORT_POINTS = "5560";
        // Port # for receiving player names:
        public const string PORT_PLAYER = "5561";

        // e.g. "Player1: 100;Player2: 300;Player3: etc."
        private string Points = string.Empty;
        private string[] Players;

        // Placeholder for our message workers:
        private Dictionary<int, MessagePassing> dictSockets
                = new Dictionary<int, MessagePassing>();

        public Dictionary<int, MessagePassing> DictSockets { get { return dictSockets;  } set { dictSockets = value; } }

        private string Name { get; set; }
        private string IP { get; set; }

        public Lobby(string Name, string IP, bool showPlay = false)
        {
            this.Name = Name;
            this.IP = IP;

            InitializeComponent();

            btnPlay.Visible = showPlay;

            // Socket setup:
            SetupMessageWorkers();

            // Send your username to the server:
            SendUsername();

            // Turn on subscribers:
            Thread getPointsThread = new Thread(() => GetPoints());
            Thread playButtonThread = new Thread(() => EnableDisablePlayButton());
            Thread chatSubscriberThread = new Thread(() => SetChatSubscriber());
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
                dictSockets[REP_PLAYER].SendMessage(Name);
            // Start game:
            else
                dictSockets[REP_PLAYER].SendMessage(startGame);
        }

        #endregion PLAYER

        #region MESSAGING

        // Own thread!
        private void SetChatSubscriber()
        {
            while (true)
            {
                txtChat.Text = txtChat.Text + dictSockets[SUB_CHAT].GetMessage() + Environment.NewLine;
            }
        }

        private void SendChatMessage()
        {
            string dummy = dictSockets[REP_CHAT_MSG].GetMessage();
            // Send as 'Name: msg'
            dictSockets[REP_CHAT_MSG].SendMessage(string.Format("{0}: {1}", Name, txtSend.Text.ToString()));
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
            GameScreen gameScreen = new GameScreen();
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
