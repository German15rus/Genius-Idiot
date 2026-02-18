using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Genius___Idiot
{
    class QuestionsStorage
    {
        private string textsPath = "..\\..\\..\\Questions";
        private string answersPath = "..\\..\\..\\Answers";
        public List<Question> GetAll()
        {
            string[] questionsTexts = File.ReadAllLines(textsPath);
            string[] questionsAnswers = File.ReadAllLines(answersPath);
            List<Question> questions = new List<Question>();
            for (int i = 0;  i < questionsTexts.Length; i++)
            {
                Question question = new Question();
                question.Text = questionsTexts[i];
                question.Answer = questionsAnswers[i];
                questions.Add(question);
            }
            return questions;
        }
        public void Add(Question question) 
        {//DONE
            File.AppendAllText(textsPath, question.Text + Environment.NewLine);
            File.AppendAllText(answersPath, question.Answer + Environment.NewLine);
        }
        public void Remove(int questionIndex)
        {
            //удаляю вопрос
            var withoutDel = File.ReadAllLines(textsPath).ToList();
            withoutDel.RemoveAt(questionIndex);
            File.WriteAllLines(textsPath, withoutDel);
            //удаляю ответ
            withoutDel = File.ReadAllLines(answersPath).ToList();
            withoutDel.RemoveAt(questionIndex);
            File.WriteAllLines(textsPath, withoutDel);
        }
        public void Finish(int cnt, string diagnos, string userName)
        {
            string results = ($"{userName}#{cnt}#{diagnos}");
            File.AppendAllText("..\\..\\..\\гений идиот.txt", results + Environment.NewLine);
        }
    }
    class User
    {
        public string Name;
        public string Diagnos;
        public int CorrectAnswers;
    }
    class Question
    {
        public string Text;
        public string Answer;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = CreateQuestions();

            SaveQuestions(questions);

            User user1 = new User();

            Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
            user1.Name = Console.ReadLine()!;

            user1.Name = char.ToUpper(user1.Name[0]) + user1.Name.Substring(1);
            Console.WriteLine($"Приятно познакомиться, {user1.Name}.");

            Console.WriteLine("Напишите номер того, что вас интересует.");
            Console.WriteLine("1)Играть 2)Результаты 3)Удалить/Добавить");
            int userAnswer = Convert.ToInt32(Console.ReadLine());

            if (userAnswer == 2)
            {
                Console.WriteLine("Результаты прошлых игр");
                string[] fileData = File.ReadAllLines("..\\..\\..\\гений идиот.txt");
                for (int i = 0; i < fileData.Length; i++)
                {
                    string line = fileData[i];
                    string[] data = line.Split(' ');
                    Console.WriteLine($"имя пользователя - {data[0]}, кол-во прав ответов - {data[1]}, диагноз - {data[2]}");
                }
            }
            else if (userAnswer == 3)
            {
                Console.WriteLine("Уточните вы хотите Добавить/Удалить");
                string UserCreateQuestion = Console.ReadLine()!;
                DeleteOrAddQuestions(UserCreateQuestion, questions);
                SaveQuestions(questions);
            }
            user1.CorrectAnswers = 0;
            int questionsCount = questions.Count;

            while (PlayAgain(user1.Name))
            {
                for (int i = 0; i < questionsCount; i++)
                {
                    Random rnd = new Random();
                    int randomIndex = rnd.Next(questions.Count);
                    Console.WriteLine(questions[randomIndex].Text);

                    string QuestionAnswer = Console.ReadLine()!;
                    QuestionAnswer = QuestionAnswer.ToLower();
                    if (QuestionAnswer == questions[randomIndex].Answer)
                    {
                        user1.CorrectAnswers++;
                    }
                    questions.RemoveAt(randomIndex);
                }
                user1.Diagnos = MakeADiagnos(questionsCount, user1.CorrectAnswers);
                user1.CorrectAnswers = 0;
                GamingResults(user1.CorrectAnswers, user1.Diagnos, user1.Name);
                Console.WriteLine($"Ваш диагноз - {user1.Diagnos}");
                if (questionsCount == 0)
                {
                    questions = CreateQuestions();
                }
            }

        }
        public static string MakeADiagnos(int questionsCount, int correctCount)
        {
            List<string> diagnosises = new List<string>() { "Идиот", "Бездарь", "Живчик", "Нормис", "Сигмантей", "Гений" };
            double correctPercent = (double)correctCount / questionsCount * 100;
            if (correctPercent == 0)
                return diagnosises[0];
            else if (correctPercent < 20)
                return diagnosises[1];
            else if (correctPercent < 40)
                return diagnosises[2];
            else if (correctPercent < 60)
                return diagnosises[3];
            else if (correctPercent < 80)
                return diagnosises[4];
            return diagnosises[5];
        }
        static List<Question> CreateQuestions()
        {
            List<Question> questions = new List<Question>();

            Question question1 = new Question();
            question1.Text = "1)Где храниться суета";
            question1.Answer = "в барсетке";
            questions.Add(question1);

            Question question2 = new Question();
            question2.Text = "2)Мужское есть";
            question2.Answer = "жи есть";
            questions.Add(question2);

            Question question3 = new Question();
            question3.Text = "3)Как зовут кошку";
            question3.Answer = "бонтик";
            questions.Add(question3);
            return questions;
        }
        static bool PlayAgain(string userName)
        {
            Console.WriteLine($"{userName}, готов сыграть в игру? Введи ответ: Да или Нет.");
            bool end = false;
            while (end != true)
            {
                string userAgreed = Console.ReadLine()!;
                userAgreed = userAgreed.ToLower();
                if (userAgreed == "да")
                {
                    return true;
                }
                if (userAgreed == "нет")
                {
                    return false;
                }
                Console.WriteLine("Введите: Да или Нет");
            }
            return false;
        }
        static void GamingResults(int cnt, string diagnos, string userName)
        {
            string results = ($"{userName}#{cnt}#{diagnos}");
            File.AppendAllText("..\\..\\..\\гений идиот.txt", results + Environment.NewLine);
        }
        static void DeleteOrAddQuestions(string userDesision, List<Question> questions)
        {

            if (userDesision.Equals("добавить", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Введите вопрос, а после ответ на него:");
                string newQuestionText = Console.ReadLine()!;
                string newQuestionAnswer = Console.ReadLine()!;

                Question newQuestion = new Question();
                newQuestion.Text = newQuestionText;
                newQuestion.Answer = newQuestionAnswer;

                questions.Add(newQuestion);
            }
            else if (userDesision.Equals("удалить", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Напишите номер вопроса который хотите удалить");
                int questonIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                questions.RemoveAt(questonIndex);
            }
        }
        static void SaveQuestions(List<Question> questions)
        {
            List<string> questionsTexts = new List<string>();
            List<string> questionsAnswers = new List<string>();
            for (int i = 0; i < questions.Count; i++)
            {
                questionsTexts.Add(questions[i].Text);
                questionsAnswers.Add(questions[i].Answer);
            }

            File.WriteAllLines("..\\..\\..\\Questions.txt", questionsTexts);
            File.WriteAllLines("..\\..\\..\\Answers.txt", questionsAnswers);
        }
    }
}
