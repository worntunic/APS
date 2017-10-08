using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Beeffudge.Server.GameLogic.GameObjects;
using LitJson;

namespace Beeffudge.Server.GameLogic {

    public class Answer {
        public string text;
        public bool isCorrect;
        public Player creator;

        public Answer (string text) {
            this.text = text;
            creator = null;
            isCorrect = true;
        }

        public Answer (string text, Player creator) {
            this.text = text;
            this.creator = creator;
            isCorrect = false;
        }
    }

    public struct PlayerAnswer {
        public Player player;
        public Answer answer;

        public PlayerAnswer(Player player, Answer answer) {
            this.player = player;
            this.answer = answer;
        }
    }

    public class QA {
        public Question question;
        public List<Answer> answers;
        public Dictionary<Player, Answer> playersSelectedAnswers;
        public bool answeringOpen;

        public QA (Question question) {
            this.question = question;
            this.answers = new List<Answer>();
            Answer correctAnswer = new Answer(question.correctAnswer);
            answers.Add(correctAnswer);
            playersSelectedAnswers = new Dictionary<Player, Answer>();
            answeringOpen = true;
        }

        public void answerQuestion (Player player, string answer, bool useSampleAnswer = false) {
            if (answeringOpen && answers.Where(ans => ans.creator == player).Count() == 0) {
                if (useSampleAnswer) {
                    int wrongAnswersCount = question.wrongAnswers.Length;
                    Random random = new Random();
                    answer = question.wrongAnswers[random.Next(0, wrongAnswersCount)];
                }
                answers.Add(new Answer(answer, player));
            }
        }

        public void answerQuestion (Answer answer, bool useSampleAnswer = false) {
            if (answeringOpen && answers.Where(ans => ans.creator == answer.creator).Count() == 0) {
                if (useSampleAnswer) {
                    int wrongAnswersCount = question.wrongAnswers.Length;
                    Random random = new Random();
                    string answerText = question.wrongAnswers[random.Next(0, wrongAnswersCount)];
                    answer.text = answerText;
                }
                answers.Add(answer);
            }
        }

        public void selectAnswer (Player selectingPlayer, Answer answer) {
            playersSelectedAnswers.Add(selectingPlayer, answer);
        }

        public List<Answer> getAllAnswers () {
            return answers;
        }
    }


    class GameController {
        public static int maxPlayers = 4;
        public static int minPlayers = 2;
        public static float answerTime = 30;
        public static float showAnswerTime = 30;
        public static int maxRounds = 4;
        public static int scorePerWrongAnswer = 200;
        public static int scorePerCorrectAnswer = 500;
        
        //concrete game
        private string gameID;
        private List<Player> players;
        public bool gameStarted;
        public List<QA> questionsAsked;
        public Timer timer;
        public int currentRound;
        public bool answeringOpen = false;


        private GameController () {
            gameID = Guid.NewGuid().ToString();
            gameStarted = false;
            players = new List<Player>();
            questionsAsked = new List<QA>();
            currentRound = 0;
        }

        public static GameController createGame () {
            return new GameController();
        }

        //join game
        private Player getPlayerByName(string name) {
            return players.First(plr => plr.name == name);
        }

        public void answerQuestion(string player, string answer) {

            questionsAsked.Last().answerQuestion(getPlayerByName(player), answer);
        }

        public void answerQuestion(Answer answer) {
            questionsAsked.Last().answerQuestion(answer);
        }

        public void selectQuestion(Player player, Answer answer) {
            questionsAsked.Last().selectAnswer(player, answer);
        }

        public void selectQuestion(PlayerAnswer plrAnswer) {
            questionsAsked.Last().selectAnswer(plrAnswer.player, plrAnswer.answer);
        }

        public bool tryAddPlayer (string playerName) {
            if (!gameStarted && players.Count >= maxPlayers || players.Exists(plr => plr.name.Equals(playerName))) {
                return false;
            }
            Player newPlayer = new Player(playerName);
            players.Add(newPlayer);
            return true;
        }

        public bool tryStartGame () {
            gameStarted = players.Count >= minPlayers;
            if (gameStarted) {
                startAnsweringTimer();
            }
            return gameStarted;
        }

        public void removePlayer (Player player) {
            players.Remove(player);
            if (players.Count == 0) {
                //game not valid
            }
        }

        public string askQuestion () {
            Question newQuestion = GameDBManager.getQuestion();
            QA newQA = new QA(newQuestion);
            questionsAsked.Add(newQA);
            answeringOpen = true;
            return JsonMapper.ToJson(newQuestion);
        }



        public Question getCurrentQuestion () {
            return questionsAsked.Last().question;
        }

        public void startAnsweringTimer () {
            timer = new Timer(answerTime * 1000);
            timer.AutoReset = false;
            timer.Elapsed += showAnswersEvent;
            timer.Enabled = true;
        }

        public void startShowAnswersTimer () {
            timer = new Timer(showAnswerTime * 1000);
            timer.AutoReset = false;
            timer.Elapsed += askQuestionOrEndGame;
            timer.Enabled = true;
        }

        private void showAnswersEvent (Object source, ElapsedEventArgs e) {
            answeringOpen = false;
            QA currentQuestion = questionsAsked.Last();
            //show answers
        }

        private void askQuestionOrEndGame (Object source, ElapsedEventArgs e) {
            calculateScores();
            if (currentRound == maxRounds) {
                endGame();
            } else {
                currentRound++;
                askQuestion();
            }
        }

        private void calculateScores () {
            foreach (KeyValuePair<Player, Answer> pair in questionsAsked.Last().playersSelectedAnswers) {
                if (pair.Value.isCorrect) {
                    pair.Key.score += scorePerCorrectAnswer;
                } else {
                    pair.Value.creator.score += scorePerWrongAnswer;
                }
            }
        }

        public string calculateCurrentScoreboard() {
            string retScores = "";
            for (int i = 0; i < players.Count; i++) {
                retScores += players[i].name + ": " + players[i].score + ";";
            }
            return retScores;
        }

        private void endGame () {

        }
    }
}
