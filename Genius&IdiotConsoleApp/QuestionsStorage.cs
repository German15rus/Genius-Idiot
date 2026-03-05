using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Genius___Idiot
{
    public class QuestionsStorage
    {
        private string questionsBankPath = "questionsBank.json";
        public List<Question> GetAll()
        {

            if (!File.Exists(questionsBankPath))
            {
                // Если файла нет - создаем с дефолтными вопросами
                List<Question> defaultQuestions = GetDefaultQuestions();
                string json = JsonConvert.SerializeObject(defaultQuestions);
                File.WriteAllText(questionsBankPath, json);
                return defaultQuestions;
            }


            string jsonContent = File.ReadAllText(questionsBankPath);

            // Если файл пустой или содержит только пробелы
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                List<Question> defaultQuestions = GetDefaultQuestions();
                string json = JsonConvert.SerializeObject(defaultQuestions);
                File.WriteAllText(questionsBankPath, json);
                return defaultQuestions;
            }

            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(jsonContent) ?? new List<Question>();

            // Если список пустой после десериализации
            if (questions.Count == 0)
            {
                List<Question> defaultQuestions = GetDefaultQuestions();
                string json = JsonConvert.SerializeObject(defaultQuestions);
                File.WriteAllText(questionsBankPath, json);
                return defaultQuestions;
            }

            return questions;
        }

        public void Add(Question question)
        {
            var questions = new List<Question>();

            if (File.Exists(questionsBankPath))
            {
                string json = File.ReadAllText(questionsBankPath);
                questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();
            }

            questions.Add(question);

            string updatedJson = JsonConvert.SerializeObject(questions);
            File.WriteAllText(questionsBankPath, updatedJson);
        }

        public void Remove(int questionNum)
        {
            int questionIndex = questionNum - 1;


            string json = File.ReadAllText(questionsBankPath);
            var questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();
            questions.RemoveAt(questionIndex);

            string updatedJson = JsonConvert.SerializeObject(questions);
            File.WriteAllText(questionsBankPath, updatedJson);

        }

        public void Save(List<Question> questions)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(questions);
            File.WriteAllText(questionsBankPath, json);
        }
        public List<Question> GetDefaultQuestions()
        {
            List<Question> defaultQuestions = new List<Question>();

            Question default1 = new Question();
            default1.Text =  "Где храниться суета?";
            default1.Answer = "в барсетке";

            Question default2 = new Question();
            default2.Text = "Барса или Реал?";
            default2.Answer = "барса";

            Question default3 = new Question();
            default3.Text = "Какое самое лучшее аниме?";
            default3.Answer = "незнаю";

            Question default4 = new Question();
            default4.Text = "Лучшая команда в СОГУ?";
            default4.Answer = "веревочный нонсенс";

            Question default5 = new Question();
            default5.Text = "Мужское есть?";
            default5.Answer = "жи есть";

            Question default6 = new Question();
            default6.Text = "Самая красивая девушка в СОГУ?";
            default6.Answer = "секретарша";

            defaultQuestions.Add(default1);
            defaultQuestions.Add(default2);
            defaultQuestions.Add(default3);
            defaultQuestions.Add(default4);
            defaultQuestions.Add(default5);
            defaultQuestions.Add(default6);

            return defaultQuestions;
        }
    }
}