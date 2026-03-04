using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using System.Text;

namespace Genius___Idiot
{
    public class QuestionsStorage
    {
        private string questionsBankPath = "..\\..\\..\\questionsBank.json";

        public List<Question> GetAll()
        {
            if (string.IsNullOrWhiteSpace(File.ReadAllText(questionsBankPath)) == false)
            {
                GetDefaultQuestions();
                return GetAll();
            }
            string json = File.ReadAllText(questionsBankPath);

            return System.Text.Json.JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
        }

        public void Add(Question question)
        {
            var questions = GetAll();
            questions.Add(question);
            Save(questions);
        }

        public void Remove(int questionNum)
        {
            var questions = GetAll();
            int questionIndex = questionNum - 1;

            if (questionIndex >= 0 && questionIndex < questions.Count)
            {
                questions.RemoveAt(questionIndex);
                Save(questions);
            }

            questionIndex = questionIndex - 1;
        }

        public void Save(List<Question> questions)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(questions);
            File.WriteAllText(questionsBankPath, json);
        }
        public void GetDefaultQuestions()
        {
            var defaultQuestions = new List<Question>
            {
                new Question { Text = "2+2?", Answer = "4" },
                new Question { Text = "Столица Франции?", Answer = "Париж" },
                new Question { Text = "Язык программирования?", Answer = "C#" }
            };

            Save(defaultQuestions);
        }
    }
}