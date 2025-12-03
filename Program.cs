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
			string diagnos = "Не установлен";
			Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
			string userName = Console.ReadLine()!;
			userName = char.ToUpper(userName[0]) + userName.Substring(1);
			Console.WriteLine($"Приятно познакомиться, {userName}.");

			Console.WriteLine("Напишите номер того, что вас интересует.");
			Console.WriteLine("1)Играть 2)Результаты 3)Удалить/Добавить");
			string userAnswer = Console.ReadLine()!;
			userAnswer = userAnswer.ToLower();

			int cnt = 0;
			(List<string> questions, List<string> answers) = CreateQuestions();
			while (WannaPlay(userName))
			{
				List<string> simillarQuestions = new List<string>(questions);
				List<string> simillarAnswers = new List<string>(answers);
				for (int i = 0; i != questions.Count; i++)
				{
					Random rnd = new Random();
					int randomIndex = rnd.Next(simillarQuestions.Count);
					Console.WriteLine(simillarQuestions[randomIndex]);

					string QuestionAnswer = Console.ReadLine()!;
					QuestionAnswer = QuestionAnswer.ToLower();

					if (QuestionAnswer == simillarAnswers[randomIndex])
					{
						cnt++;
					}
					simillarQuestions.RemoveAt(randomIndex);
					simillarAnswers.RemoveAt(randomIndex);
				}//подбор вопрос

				diagnos = MakeADiagnos(questions, cnt);
				cnt = 0;
				GamingResults(cnt, diagnos, userName);
				Console.WriteLine($"Ваш диагноз - {diagnos}");
			}
		}
		public static string MakeADiagnos(List<string> questions, int cnt)
		{
			List<string> diagnosises = new List<string>() { "Идиот", "Бездарь", "Кретин", "Нормис", "Сигмантей", "Гений" };
			double rightAns = cnt;
			double countQuestions = questions.Count;
			double procent = rightAns / countQuestions * 100;
			if (procent == 0)
				return diagnosises[0];
			else if (procent < 20)
				return diagnosises[1];
			else if (procent < 40)
				return diagnosises[2];
			else if (procent < 60)
				return diagnosises[3];
			else if (procent < 80)
				return diagnosises[4];
			else if (procent <= 100)
				return diagnosises[5];
			return "0";
		}
		static (List<string>, List<string>) CreateQuestions()//TODO Разобраться с вопросами почему так они тупо работают
		{
			Random rnd = new Random();
			List<string> questionsBank = new List<string>() { "1)Где нужно хранить суету", "2)Сколько позиций в доте", "3)3", "4)4", "5)5", "6)6", "7)7", "8)8", "9)9", "10)10" };
			List<string> answersBank = new List<string>() { "1)в барсетке", "2)2", "3)3", "4)4", "5)5", "6)6", "7)7", "8)8", "9)9", "10)10" };

			File.AppendAllLines("гений идиот.txt", questionsBank);
			

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
		static bool WannaPlay(string userName)
		{
			Console.WriteLine($"{userName}, готов сыграть в игру?");
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

				Console.WriteLine("такого варианта нет");
			}

			return false;
		}
		static void GamingResults(int cnt, string diagnos, string userName) //TODO: Сделать дописывание в файл
		{
			List<string> results = new List<string>();
			results.Add($"Данные пользователя - {userName}");
			results.Add(Convert.ToString(cnt));
			results.Add(diagnos);
			File.WriteAllLines("гений идиот.txt", results);
		}
		static void DeleteOrAddQuestions(string UserCreateQuestion)
		{
			if (UserCreateQuestion.Equals("добавить", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Введите вопрос, а после ответ на него");
				string newUserQuestion = Console.ReadLine()!;
				string newUserAnswer = Console.ReadLine()!;
				
			}
			else if (UserCreateQuestion.Equals("удалить", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Напишите номер вопроса который хотите удалить");
			}
		}
	}
}
