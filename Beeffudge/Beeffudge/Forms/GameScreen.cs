using Beeffudge.GameLogic;
using Beeffudge.GameLogic.GameObjects;
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
        private Answer answerToSend;
        private bool shouldSendAnswer = false;
        private Answer chosenAnswerToSend;
        private bool shouldSendChosenAnswer = false;

        public GameScreen(Lobby parent) {
            InitializeComponent();
            LoadAnswerButtons();
            // Get lobby reference:
            /*parent.IsMdiContainer = true;
            this.MdiParent = parent;*/
            this.parent = parent;
            _username = parent._Name;
            _payers = parent.Players;
            // Get reference for message workers:
            dictSockets = parent.DictSockets;
            parent.chatWindow = txtChat;
            parent.chatSendBox = txtChatSend;
            // Start thread to listen for chat messages:
            /*Thread chatSubscribeThread = new Thread(() => UpdateChat());
            chatSubscribeThread.Start();*/
            Thread answerQuestionThread = new Thread(() => AnswerQuestionThread());
            answerQuestionThread.Start();

            Thread getQuestionThread = new Thread(() => GetQuestionThread());
            getQuestionThread.Start();

            Thread answerChosenThread = new Thread(() => ChosenAnswerThread());
            answerChosenThread.Start();
            // Prvi put uzmemo pitanje i odgovore od servera:
            //GetQuestionFromServer();
        }

        private void txtChat_TextChanged(object sender, EventArgs e) {

        }

        private void LoadAnswerButtons() {
            answerButtons = new List<Button>();
            answerButtons.Add(btnAnswer1);
            answerButtons.Add(btnAnswer2);
            answerButtons.Add(btnAnswer3);
            answerButtons.Add(btnAnswer4);
            answerButtons.Add(btnAnswer5);
        }
        private void GameScreen_Load(object sender, EventArgs e) {
        }

        private void btnChatSend_Click(object sender, EventArgs e) {
            //Send chatMessage to server for our player
            //SendChatMessage();
            string message = string.Empty;
            Invoke(new Action(() => {
                message = txtChatSend.Text.ToString();
            }));
            this.parent.PrepareChatMessage(message);
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
        public void SetEnabledAnswerButtons(bool areEnabled) {
            for (int i = 0; i < answerButtons.Count; i++) {
                answerButtons[i].Enabled = areEnabled;
            }
        }

        public void InstantiateAnswerButtons(List<string> allAnswers) {
            answers = Shuffle(allAnswers);
            SetEnabledAnswerButtons(true);
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
            chosenAnswerToSend = new Answer(answer, new Player(this._username));
            shouldSendChosenAnswer = true;
        }
        
        private void ChosenAnswerThread() {
            while (true) {
                string dummy = dictSockets[Lobby.REP_CHOICE].GetMessage();
                if (shouldSendChosenAnswer) {
                    string answerToSend = LitJson.JsonMapper.ToJson(chosenAnswerToSend);
                    dictSockets[Lobby.REP_CHOICE].SendMessage(answerToSend);
                    shouldSendChosenAnswer = false;
                    // Iskljucimo dugmice do sledeceg pitanja:
                    Invoke(new Action(() => {
                        SetEnabledAnswerButtons(false);
                    }));
                } else {
                    dictSockets[Lobby.REP_CHOICE].SendMessage("");
                }
            }
        }

        private void btnEnterAnswer_Click_1(object sender, EventArgs e) {
            if (!txtAnswer.Equals("")) {
                
                string answerText = txtAnswer.Text;
                //Send answer to server for our player
                Player ourPlayer = new Player(this._username);
                
                this.answerToSend = new Answer(answerText, ourPlayer);
                this.shouldSendAnswer = true;
                //string dummy = dictSockets[Lobby.REP_ANSWER].GetMessage();
                //dictSockets[Lobby.REP_ANSWER].SendMessage(answerText);

                // Iskljucimo dugme da ne salje 
                // bespotrebno kada ne treba:
                btnEnterAnswer.Enabled = false;
                txtAnswer.Clear();
            }



            //TEST
            //HideAnswerButtons();
            //UpdateQuestionText("A new question fosho");
        }

        //No longer used, since we use the same thread for chat that starts in lobby
        /*private void SendChatMessage() {
            string dummy = dictSockets[Lobby.REP_CHAT_MSG].GetMessage();
            // Send as 'Name: msg'
            dictSockets[Lobby.REP_CHAT_MSG].SendMessage(string
                .Format("{0}: {1}", Name, txtChatSend.Text.ToString()));
        }*/

        // Own thread!
        /*private void UpdateChat() {
            string msg = string.Empty;
            while (true)
            {
                msg = dictSockets[Lobby.SUB_CHAT].GetMessage();
                Invoke(new Action(() => {
                    txtChat.Text = txtChat.Text + msg + Environment.NewLine;
                }));
            }
        }*/

        // TODO: Pozvati svaki put kad se runda zavrsi \i sledeci red ispod
        // i kada istekne tajmer i kada se ocekuje prikaz odgovora!
        //
        // Moguce da je GetMessage() blokirajuci! Pokrenuti u 
        // posebnom thread-u ako treba!

        private void GetQuestionThread() {
            while (true) {
                GetQuestionFromServer();
            }
        }

        private void GetQuestionFromServer() {
            string questionJSON = string.Empty;

            questionJSON = dictSockets[Lobby.SUB_QUESTION].GetMessage();

            //string questionText;
            //QuestionWithAnswers qwa = new QuestionWithAnswers(questionJSON);
            QA question = LitJson.JsonMapper.ToObject<QA>(questionJSON);
            if (question.answers.Count <= 1) {
                Invoke(new Action(() => { 
                    UpdateQuestionText(question.question.text);
                    btnEnterAnswer.Enabled = true;
                    HideAnswerButtons();
                }));
            } else {
                Invoke(new Action(() => {
                    answers = question.getAllAnswersAsStrings();
                    InstantiateAnswerButtons(answers);
                }));
            }

            // Question now has only the question:
            //question = qwa.QuestionString;

            // Received answers from question:
            //answers = question.wrongAnswers.ToList();

            // Update question text:


            // Ako je poslato pitanje sa unesenim odgovorima:
            // '#' je escape simbol za prvo slanje pitanja.
            /*if (!answers[0].Equals("#"))
                // Instantiate answers:
                InstantiateAnswerButtons(answers);
            else {
                // U suprotnom treba da se samo pitanje postavi
                // i ugase dugmici.
                HideAnswerButtons();
            }*/
        }

        private void AnswerQuestionThread () {
            while (true) {
                string dummy = dictSockets[Lobby.REP_ANSWER].GetMessage();
                if (shouldSendAnswer) {
                    string answer = LitJson.JsonMapper.ToJson(answerToSend);
                    dictSockets[Lobby.REP_ANSWER].SendMessage(answer);
                    shouldSendAnswer = false;
                } else {
                    dictSockets[Lobby.REP_ANSWER].SendMessage("");
                }
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
