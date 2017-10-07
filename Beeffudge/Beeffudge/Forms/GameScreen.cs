using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeroMQ;

namespace Beeffudge.Forms {
    public partial class GameScreen : Form {

        public List<string> answers;
        public List<Button> answerButtons;

        private Dictionary<int, MessagePassing> dictSockets;
        private Lobby parent;
        private string _username;
        private string[] _payers;

        public GameScreen(Lobby parent) {
            InitializeComponent();

            // Get lobby reference:
            this.parent = parent;
            _username = parent._Name;
            _payers = parent.Players;
            // Get reference for message workers:
            dictSockets = parent.DictSockets;

            // Start thread to listen for chat messages:
            Thread chatSubscribeThread = new Thread(() => UpdateChat());
            chatSubscribeThread.Start();

            // Prvi put uzmemo pitanje i odgovore od servera:
            GetQuestionFromServer();
        }

        private void txtChat_TextChanged(object sender, EventArgs e) {

        }

        private void GameScreen_Load(object sender, EventArgs e) {
            answerButtons = new List<Button>();
            answerButtons.Add(btnAnswer1);
            answerButtons.Add(btnAnswer2);
            answerButtons.Add(btnAnswer3);
            answerButtons.Add(btnAnswer4);
            answerButtons.Add(btnAnswer5);
        }

        private void btnChatSend_Click(object sender, EventArgs e) {
            //Send chatMessage to server for our player
            SendChatMessage();

            //TEST
            //List<string> someAnswers = new List<string>() { "first", "second", "third", "fourth", "fifth" };
            //InstantiateAnswerButtons(someAnswers);
        }

        public void UpdateQuestionText(string newQuestion) {
            lblQuestion.Text = newQuestion;
        }

        public void HideAnswerButtons() {
            for (int i = 0; i < answerButtons.Count; i++) {
                answerButtons[i].Visible = false;
            }
        }

        public void InstantiateAnswerButtons(List<string> allAnswers) {
            answers = Shuffle(allAnswers);
            for (int i = 0; i < answers.Count; i++) {
                answerButtons[i].Text = answers[i];
                answerButtons[i].Visible = true;
            }
        }

        public static List<string> Shuffle(List<string> list) {
            int n = list.Count;
            Random rng = new Random();
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        private void btnAnswer1_Click(object sender, EventArgs e) {
            SendChoiceToServer(0);
        }

        private void btnAnswer2_Click(object sender, EventArgs e) {
            SendChoiceToServer(1);
        }

        private void btnAnswer3_Click(object sender, EventArgs e) {
            SendChoiceToServer(2);
        }

        private void btnAnswer4_Click(object sender, EventArgs e) {
            SendChoiceToServer(3);
        }

        private void btnAnswer5_Click(object sender, EventArgs e) {
            SendChoiceToServer(4);
        }

        private void SendChoiceToServer(int answerNumber) {
            string answer = answers[answerNumber];
            //send selected answer to server for our player

            string dummy = dictSockets[Lobby.REP_CHOICE].GetMessage();
            dictSockets[Lobby.REP_CHOICE].SendMessage(answer);

            // Iskljucimo dugmice do sledeceg pitanja:
            foreach (Button btn in answerButtons) {
                btn.Enabled = false;
            }
        }

        private void btnEnterAnswer_Click_1(object sender, EventArgs e) {
            string answer = txtAnswer.Text;
            //Send answer to server for our player
            string dummy = dictSockets[Lobby.REP_ANSWER].GetMessage();
            dictSockets[Lobby.REP_ANSWER].SendMessage(answer);

            // Iskljucimo dugme da ne salje 
            // bespotrebno kada ne treba:
            btnEnterAnswer.Enabled = false;



            //TEST
            //HideAnswerButtons();
            //UpdateQuestionText("A new question fosho");
        }

        private void SendChatMessage() {
            string dummy = dictSockets[Lobby.REP_CHAT_MSG].GetMessage();
            // Send as 'Name: msg'
            dictSockets[Lobby.REP_CHAT_MSG].SendMessage(string
                .Format("{0}: {1}", Name, txtChatSend.Text.ToString()));
        }

        // Own thread!
        private void UpdateChat() {
            string msg = string.Empty;
            while (true)
            {
                msg = dictSockets[Lobby.SUB_CHAT].GetMessage();
                txtChat.Text = txtChat.Text + msg + Environment.NewLine;
            }
        }

        // TODO: Pozvati svaki put kad se runda zavrsi \i sledeci red ispod
        // i kada istekne tajmer i kada se ocekuje prikaz odgovora!
        private void GetQuestionFromServer() {
            string question = string.Empty;

            question = dictSockets[Lobby.SUB_QUESTION].GetMessage();

            QuestionWithAnswers qwa = new QuestionWithAnswers(question);

            // Question now has only the question:
            question = qwa.QuestionString;
            
            // Received answers from question:
            answers = qwa.AnswersString;

            // Update question text:
            UpdateQuestionText(question);

            // Ako je poslato pitanje sa unesenim odgovorima:
            // '#' je escape simbol za prvo slanje pitanja.
            if (!answers[0].Equals("#"))
                // Instantiate answers:
                InstantiateAnswerButtons(answers);
            else {
                // U suprotnom treba da se samo pitanje postavi
                // i ugase dugmici.
                HideAnswerButtons();
            }
        }

        // Question received looks like this:
        // 'questionQuqestion bla bla ___ ?$answer1$answer2$..etc'
        partial class QuestionWithAnswers
        {
            public string QuestionString { get; private set; }
            public List<string> AnswersString { get; private set; }

            public QuestionWithAnswers(string questionWithAnswers) {
                string[] questionSeparated = questionWithAnswers.Split('$');
                QuestionString = questionSeparated[0];

                for (int i = 1; i < questionSeparated.Length; i++) {
                    AnswersString.Add(questionSeparated[i]);
                }
            }
        }
    }
}
