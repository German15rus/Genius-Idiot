using System.Collections.Generic;

namespace Genius___Idiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsersStorage res = new UsersStorage();
            QuestionsStorage questionsRepository = new QuestionsStorage();
            User user1 = new User();

            Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
            user1.Name = Console.ReadLine()!;

            user1.Name = char.ToUpper(user1.Name[0]) + user1.Name.Substring(1);
            Console.WriteLine($"Приятно познакомиться, {user1.Name}.");

            while (PlayAgain(user1.Name))
            {

                List<Question> questions = questionsRepository.GetAll();

                string userAns = "";
                Console.WriteLine("Напишите номер того, что вас интересует.");
                Console.WriteLine("1)Играть 2)Результаты 3)Удалить/Добавить 4) Выйти");

                userAns = Console.ReadLine()!;
                int userAnswer = CheckAnswer(userAns);

                if ((userAnswer > 0) && (userAnswer <= 4))
                {
                    if (userAnswer == 2)
                    {
                        Console.WriteLine("Результаты прошлых игр");
                        List<User> fileData = res.ReturnList();
                        foreach (User userRes in fileData)
                        {
                            Console.WriteLine($"Имя пользователя - {userRes.Name}, Кол-во прав ответов - {userRes.CorrectAnswers}, Диагноз - {userRes.Diagnos}");
                        }
                    }

                    if (userAnswer == 3)
                    {
                        string UserCreateQuestion = "";
                        
                        while (true)
                        {
                            
                            Console.WriteLine("Уточните вы хотите Добавить/Удалить");

                            UserCreateQuestion = Console.ReadLine()!;
                            if ((UserCreateQuestion != "добавить") || (UserCreateQuestion != "удалить"))
                            {
                                break;
                            }
                        }
                        
                        DeleteOrAddQuestions(UserCreateQuestion, questions);
                    }

                    user1.CorrectAnswers = 0;
                    int questionsCount = questions.Count;

                    if (userAnswer == 1)
                    {
                        int hardLvl = 0;
                        Console.WriteLine("Выберите уровень сложности:");
                        Console.WriteLine("1) 5 вопросов" +
                            "2) 10 вопросов" +
                            "3) все вопросы");
                        while (true)
                        {
                            string hardMode = Console.ReadLine()!;
                            int userMode = CheckAnswer(hardMode);
                            if (userMode == 1)
                            {
                                hardLvl = 5;
                                break;
                            }
                            if (userMode == 2)
                            {
                                hardLvl = 10;
                                break;
                            }
                            if (userMode == 3)
                            {
                                hardLvl = questions.Count;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Введены не корректные данные. Повторите ввод.");
                            }
                        }
                        int GameLvl = hardLvl;
                        while (hardLvl > 0)
                        {
                            for (int i = 0; i < GameLvl; i++)
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
                                hardLvl--;
                            }
                            user1.Diagnos = MakeADiagnos(questionsCount, user1.CorrectAnswers);
                            res.Finish(user1);

                            user1.CorrectAnswers = 0;

                            Console.WriteLine($"Ваш диагноз - {user1.Diagnos}");
                        }
                        if (questions.Count == 0)
                        {
                            questions = questionsRepository.GetAll();
                        }
                    }

                    if (userAnswer == 4)
                    {
                        break;
                    }
                }

                else
                {
                    Console.WriteLine("Данные некорректные. Введите номер интересующего вас варианта повторно");
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
            QuestionsStorage questionsStorage = new QuestionsStorage();
            List < Question > newList = new List < Question >();

            if (userDesision.Equals("добавить", StringComparison.CurrentCultureIgnoreCase))
            {

                Console.WriteLine("Введите вопрос, а после ответ на него:");

                Question newQuestion = new Question();
                newQuestion.Text = Console.ReadLine()!;
                newQuestion.Answer = Console.ReadLine()!;

                questionsStorage.Add(newQuestion);

                newList = questionsStorage.GetAll();
                questionsStorage.Save(newList);

            }

            else if (userDesision.Equals("удалить", StringComparison.CurrentCultureIgnoreCase))
            {
                int number = 0;
                foreach (Question question in questions)
                {
                    number++;
                    Console.WriteLine(number + " " + question.Text);
                }

                Console.WriteLine("Напишите номер вопроса который хотите удалить");

                while (true)
                {
                    string delQuestion = Console.ReadLine()!;

                    int questionIndex = CheckAnswer(delQuestion);

                    if ((questionIndex <= questions.Count) && (questionIndex > 0))
                    {
                        questionsStorage.Remove(questionIndex);
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Введите номер который представлен в списке вопросов!");
                    }
                }
            }

        }
        static int CheckAnswer(string answer)
        {
            int n;

            while (true)
            {
                
                if (int.TryParse(answer, out n) == true)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Введите число!");
                    answer = Console.ReadLine()!;
                }
            }
            return n;
        }
    }
}

