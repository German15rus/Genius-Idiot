using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Genius___Idiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
            string userName = Console.ReadLine();
            int cnt = 0;
            (List<string> questions, List<string> answers) = CreateQuestions();
            List<string> simillarQuestions = new List<string>(questions);
            List<string> simillarAnswers = new List<string>(answers);
            bool stop = false;
            while (stop != true)
            {
                for (int i = 0; i != questions.Count; i++)
                {
                    Random rnd = new Random();
                    int randomIndex = rnd.Next(simillarQuestions.Count);
                    Console.WriteLine(simillarQuestions[randomIndex]);
                    string userAnswer = Console.ReadLine();
                    if (userAnswer == simillarAnswers[randomIndex])
                    {
                        cnt++;
                    }
                    simillarQuestions.RemoveAt(randomIndex);
                    simillarAnswers.RemoveAt(randomIndex);
                }
                MakeADiagnos(cnt, userName);
                cnt = 0;
                Console.WriteLine("Хотите начать снова?");
                string playAgain = Console.ReadLine();
                if (playAgain == "нет")
                    break;
                else if (playAgain == "да");
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
            List<string> questionsBank = new List<string>() {"1","2","3","4","5","6","7","8","9","10"};
            List<string> answerBank = new List<string>() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
            List<string> questions = new List<string>();
            List<string> simillarQuestions = new List<string>(questionsBank);//копия банка вопросов
            List<string> simillarQuestions1 = new List<string>(answerBank);//копия банка ответов
            List<string> answers = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                int rndIndex = rnd.Next(simillarQuestions.Count);
                questions.Add(simillarQuestions[rndIndex]);
                answers.Add(simillarQuestions1[rndIndex]);
                simillarQuestions.RemoveAt(rndIndex);
                simillarQuestions1.RemoveAt(rndIndex);
            }
            return (questions, answers);
        }
    }
}
