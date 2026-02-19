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
    internal class Program
    {

        static void Main(string[] args)
        {
            UsersStorage res = new UsersStorage();

            QuestionsStorage questionsRepository = new QuestionsStorage();
            List<Question> questions = questionsRepository.GetAll();

            questionsRepository.Save(questions);

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
                List<User> fileData = res.ReturnList();
                foreach (User userRes in fileData)
                {
                    Console.WriteLine($"Имя пользователя - {userRes.Name}, Кол-во прав ответов - {userRes.CorrectAnswers}, Диагноз - {userRes.Diagnos}");
                }
            }
            else if (userAnswer == 3)
            {
                Console.WriteLine("Уточните вы хотите Добавить/Удалить");
                string UserCreateQuestion = Console.ReadLine()!;
                DeleteOrAddQuestions(UserCreateQuestion, questions);
                questionsRepository.Save(questions);
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

                res.Finish(user1);

                Console.WriteLine($"Ваш диагноз - {user1.Diagnos}");
                if (questionsCount == 0)
                {
                    questions = questionsRepository.GetAll();
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
    }
}

