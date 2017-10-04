using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeroMQ;

namespace Beeffudge.Forms {
    public partial class GameScreen : Form {

        public List<string> answers;
        public List<Button> answerButtons;

        public GameScreen () {
            InitializeComponent();

        }

        private void txtChat_TextChanged (object sender, EventArgs e) {

        }

        private void GameScreen_Load (object sender, EventArgs e) {
            answerButtons = new List<Button>();
            answerButtons.Add(btnAnswer1);
            answerButtons.Add(btnAnswer2);
            answerButtons.Add(btnAnswer3);
            answerButtons.Add(btnAnswer4);
            answerButtons.Add(btnAnswer5);
        }

        private void btnChatSend_Click (object sender, EventArgs e) {
            string chatMessage = txtChat.Text;
            //Send chatMessage to server for our player
            //TEST
            List<string> someAnswers = new List<string>() { "first", "second", "third", "fourth", "fifth" };
            InstantiateAnswerButtons(someAnswers);
        }

        public void UpdateQuestionText (string newQuestion) {
            lblQuestion.Text = newQuestion;
        }

        public void HideAnswerButtons () {
            for (int i = 0; i < answerButtons.Count; i++) {
                answerButtons[i].Visible = false;
            }
        }

        public void InstantiateAnswerButtons (List<string> allAnswers) {
            answers = Shuffle(allAnswers);
            for (int i = 0; i < answers.Count; i++) {
                answerButtons[i].Text = answers[i];
                answerButtons[i].Visible = true;
            }
        }

        public static List<string> Shuffle (List<string> list) {
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

        private void btnAnswer1_Click (object sender, EventArgs e) {
            sendSelectedAnswerToServer(0);
        }

        private void btnAnswer2_Click (object sender, EventArgs e) {
            sendSelectedAnswerToServer(1);
        }

        private void btnAnswer3_Click (object sender, EventArgs e) {
            sendSelectedAnswerToServer(2);
        }

        private void btnAnswer4_Click (object sender, EventArgs e) {
            sendSelectedAnswerToServer(3);
        }

        private void btnAnswer5_Click (object sender, EventArgs e) {
            sendSelectedAnswerToServer(4);
        }

        private void sendSelectedAnswerToServer (int answerNumber) {
            string answer = answers[answerNumber];
            //send selected answer to server for our player
        }

        private void btnEnterAnswer_Click_1 (object sender, EventArgs e) {
            string answer = txtAnswer.Text;
            //Send answer to server for our player
            //TEST
            HideAnswerButtons();
            UpdateQuestionText("A new question fosho");
        }
    }
}
