using System.IO.Pipes;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Genius___Idiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool delete = false;
            string newUserQuestion = "";
            string newUserAnswer = "";
            Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
            string userName = Console.ReadLine()!;
			Console.WriteLine($"Приятно познакомиться, {userName}.");
            
            WannaPlay(userName);
            
            string userAgreed = "";
            bool stop = true;
            
            PlayAgain(stop,userAgreed);
            int cnt = 0;
            while (stop != true)
			{
                (List<string> questions, List<string> answers) = CreateQuestions(newUserQuestion,newUserAnswer,delete);
                List<string> simillarQuestions = new List<string>(questions);
                List<string> simillarAnswers = new List<string>(answers);
                Console.WriteLine("Если вы захотите удалить вопрос напишите - Удалить");
                for (int i = 0; i != questions.Count; i++)
                {
                    Random rnd = new Random();
                    int randomIndex = rnd.Next(simillarQuestions.Count);
                    Console.WriteLine(simillarQuestions[randomIndex]);
                    
                    string userAnswer = Console.ReadLine()!;
                    
                    if (userAnswer == simillarAnswers[randomIndex])
                    {
                        cnt++;
                    }
                    if (userAnswer == "Удалить")
                    {
                        delete = true;
                        newUserAnswer = simillarAnswers[randomIndex];
                        newUserQuestion = simillarQuestions[randomIndex];
                        CreateQuestions(newUserQuestion,newUserAnswer, delete);
                        delete = false;
                    }
                    simillarQuestions.RemoveAt(randomIndex);
                    simillarAnswers.RemoveAt(randomIndex);
                }//подбор вопроса И убрали вопрос и ответ который был

                MakeADiagnos(questions,cnt, userName);
                Console.WriteLine("Вы хотите создать новый вопрос?");
                string createQuestion = Console.ReadLine()!;
                if (createQuestion.Equals("да", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Введите вопрос, а после ответ на него");
                     newUserQuestion = Console.ReadLine()!;
                    newUserAnswer = Console.ReadLine()!;
                    CreateQuestions(newUserQuestion,newUserAnswer, delete);  
                }
                cnt = 0;
                WannaPlay(userName);//спрашиваем играть будет
                PlayAgain(stop,userAgreed);//и снова ес че
                GamingResults(cnt , MakeADiagnos(questions,cnt,userName), userName);    //ПРОВЕРЬ ЭТУ ФУНКЦИЮ ЖБ ТАМ ЧЕ ТО НЕСЕРЬЁЗНОЕ
            }
            Console.WriteLine("Результаты предыдущих попыток");
        }
        public static string MakeADiagnos(List<string> questions, int cnt, string userName)
        {
            string diagnos = "";
            if (((questions.Count) / 4 >= cnt) && (cnt >= 0))
                diagnos = $"{userName}, вы - Идиот";
            else if (((questions.Count) / 2 >= cnt) && (cnt > (questions.Count) / 4))
                diagnos = $"{userName}, вы - Кретин";
            else if (((questions.Count) / 4 < cnt) && ((questions.Count) / 2 >= cnt))
                diagnos = $"{userName}, вы - Нормальный";
            else if ((((questions.Count) / 2 > cnt)) && ((questions.Count) >= cnt))
                diagnos = $"{userName}, вы - Гений";
            return diagnos;

                //switch (cnt)
                //{
                //    case 0: Console.WriteLine($"{userName}, вы - Идиот"); break;
                //    case 1: Console.WriteLine($"{userName}, вы - Кретин"); break;
                //    case 2: Console.WriteLine($"{userName}, вы - Дурак"); break;
                //    case 3: Console.WriteLine($"{userName}, вы - Нормальный"); break;
                //    case 4: Console.WriteLine($"{userName}, вы - Талант"); break;
                //    case 5: Console.WriteLine($"{userName}, вы - Гений"); break;
                //}
        }
        static (List<string>, List<string>) CreateQuestions(string newUserQuestion, string newUserAnswer,bool delete)
        {
            Random rnd = new Random();
            List<string> questionsBank = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            List<string> answersBank = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            if (delete ==  false)
            {
                if ((newUserQuestion != null) && (newUserAnswer != null))
                {
                    questionsBank.Add(newUserQuestion);
                    answersBank.Add(newUserAnswer);
                }
            }
            else
            {
                questionsBank.Remove(newUserQuestion);
                answersBank.Remove(newUserAnswer);
            }

                List<string> questions = new List<string>();
            List<string> answers = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                int rndIndex = rnd.Next(questionsBank.Count);

                questions.Add(questionsBank[rndIndex]);
                answers.Add(answersBank[rndIndex]);

                questionsBank.RemoveAt(rndIndex);
                answersBank.RemoveAt(rndIndex);
            }
            return (questions, answers);
        }
        static bool PlayAgain(bool stop,string userAgreed)
        {
            stop = false;

            if (userAgreed.Equals("да", StringComparison.CurrentCultureIgnoreCase))
            {
                stop = false;
            }
            else
                stop = true;
            return stop;
		}
        static string WannaPlay(string userName)
        {
			Console.WriteLine($"{userName}, готов сыграть в игру?");
            string userAgreed = Console.ReadLine()!;
            bool end = false;
            while (end != true)
            {
                if (userAgreed.Equals("да", StringComparison.CurrentCultureIgnoreCase))
                {
                    end = true;
                }
                else if (userAgreed.Equals("нет", StringComparison.CurrentCultureIgnoreCase))
                {
                    end = true;
                }
                else
                {
                    Console.WriteLine("такого варианта нет");
				}
			}
            return userAgreed;
		}
        static void GamingResults(int cnt,string diagnos, string userName)
        {
            List<string> results = new List<string>();
            results.Add(userName);
            results.Add(Convert.ToString(cnt));
            results.Add(diagnos);
        }
    }
}
