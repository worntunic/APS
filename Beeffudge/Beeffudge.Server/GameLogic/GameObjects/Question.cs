using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeffudge.Server.GameLogic.GameObjects {
    public class Question {
        public string text;
        public string category;
        public string correctAnswer;
        public string[] wrongAnswers;
        private string reqType = "QUESTION";

        public Question () {

        }

        public Question (string text, string category, string correctAnswer, params string[] wrongAnswers) {
            this.text = text;
            this.category = category;
            this.correctAnswer = correctAnswer;
            List<string> falseAnswersTemp = new List<string>();
            if (wrongAnswers != null) {
                for (int i = 0; i < wrongAnswers.Length; i++) {
                    if (Utils.IsStringValid(wrongAnswers[i])) {
                        falseAnswersTemp.Add(wrongAnswers[i]);
                    }
                }
            }
            this.wrongAnswers = falseAnswersTemp.ToArray<string>();
        }

        public void PrintQuestion () {
            Console.WriteLine("Category:\t\t\t" + category);
            Console.WriteLine("Text:\t\t\t\t" + text);
            Console.WriteLine("Correct Answer:\t\t" + correctAnswer);
            if (wrongAnswers != null) {
                for (int i = 0; i < wrongAnswers.Length; i++) {
                    Console.WriteLine("Wrong Answer #" + i + ":\t" + wrongAnswers[i]);
                }
            }
            Console.WriteLine("=====================================");
        }
    }
}
