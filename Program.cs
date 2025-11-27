using System.IO.Pipes;
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
            Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
            string userName = Console.ReadLine()!;
			Console.WriteLine($"Приятно познакомиться, {userName}.");
            
            WannaPlay(userName);
            
            string userAgreed = "";
            bool stop = true;
            
            PlayAgain(stop,userAgreed);
			
            while (stop != true)
			{
                int cnt = 0;
                (List<string> questions, List<string> answers) = CreateQuestions();
                List<string> simillarQuestions = new List<string>(questions);
                List<string> simillarAnswers = new List<string>(answers);
                for (int i = 0; i != questions.Count; i++)
                {
                    Random rnd = new Random();
                    int randomIndex = rnd.Next(simillarQuestions.Count);//подбор вопроса
                    Console.WriteLine(simillarQuestions[randomIndex]);
                    
                    string userAnswer = Console.ReadLine()!;
                    
                    if (userAnswer == simillarAnswers[randomIndex])
                    {
                        cnt++;
                    }
                    simillarQuestions.RemoveAt(randomIndex);//убрали вопрос и ответ который был
                    simillarAnswers.RemoveAt(randomIndex);
                }

                MakeADiagnos(cnt, userName);

                cnt = 0;
                WannaPlay(userName);//спрашиваем играть будет
                PlayAgain(stop,userAgreed);//и снова ес че
            }
        }
        public static void MakeADiagnos(int cnt, string userName)
        {
            switch (cnt)
            {
                case 0: Console.WriteLine($"{userName}, вы - Идиот"); break;
                case 1: Console.WriteLine($"{userName}, вы - Кретин"); break;
                case 2: Console.WriteLine($"{userName}, вы - Дурак"); break;
                case 3: Console.WriteLine($"{userName}, вы - Нормальный"); break;
                case 4: Console.WriteLine($"{userName}, вы - Талант"); break;
                case 5: Console.WriteLine($"{userName}, вы - Гений"); break;
            }
        }

        static (List<string>, List<string>) CreateQuestions()
        {
            Random rnd = new Random();
            List<string> questionsBank = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            List<string> answersBank = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

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
    }
}
