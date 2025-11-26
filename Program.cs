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
            List <string> questions = new List <string>() { "1", "2", "3", "4", "5" };
            List <string> answers = new List <string>() { "1", "2", "3", "4", "5" };
			for (int i = 0; i != questions.Count; i++)
			{
				Random rnd = new Random();
				int n = rnd.Next(questions.Count);
				Console.WriteLine(questions[n]);
				string userAnswer = Console.ReadLine();
				if (userAnswer == answers[n])
				{
					cnt++;
				}
				questions.Remove(n);
			}
			if (cnt == 0)
                Console.WriteLine($"{userName}, вы - Идиот");
            else if (cnt == 2)
                Console.WriteLine($"{userName}, вы - Дурак");
            else if (cnt == 4)
                Console.WriteLine($"{userName}, вы - Талант");
            else if (cnt == 1)
				Console.WriteLine($"{userName}, вы - Кретин");
            else if (cnt == 3)
                Console.WriteLine($"{userName}, вы - Нормальный");
            else
                Console.WriteLine($"{userName}, вы - Гений");
        }
        static string CreateQuestions()
        {
			List<string> questions = new List<string>() { "1", "2", "3", "4", "5" };
			List<string> answers = new List<string>() { "1", "2", "3", "4", "5" };
		}
    }
}
