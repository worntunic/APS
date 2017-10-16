using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beeffudge.GameLogic.GameObjects;

namespace Beeffudge.GameLogic {
    class GameDBManager {
        private static List<Question> questions;
        private static List<string> categories;

        private static void initDB () {
            string jsonQuestions = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/db.json");
            JsonReader reader = new JsonReader(jsonQuestions);
            questions = JsonMapper.ToObject<List<Question>>(reader);
            initCategories();
        }

        private static void initCategories () {
            categories = questions.Select(q => q.category).Distinct().ToList();
        }

        public static Question getQuestion () {
            if (questions == null) {
                initDB();
            }
            Random random = new Random();
            int categoryNumber = random.Next(0, categories.Count);
            List<Question> questionsForThatCategory = questions.Where(q => q.category == categories[categoryNumber]).ToList();
            int countOfQForThatCategory = questionsForThatCategory.Count;
            int questionNumber = random.Next(0, countOfQForThatCategory);
            return questionsForThatCategory[questionNumber];
        }



    }
}
