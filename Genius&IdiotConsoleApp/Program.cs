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
			List<string> questionsBank = new List<string>() { "1)Где храниться суета", "2)Мужское есть", "3)Как зовут кошку",
				"4)", "5)5", "6)6", "7)7", "8)8", "9)9", "10)10" };
			List<string> answersBank = new List<string>() { "в барсетке", "жи есть", "бонтик", "4", "5", "6", "7", "8", "9", "10" };
			//questionsBank = File.ReadAllLines("..\\..\\..\\Questions.txt").ToList();
			//questionsBank = File.ReadAllLines("..\\..\\..\\Answers.txt").ToList();
			
			SavingQuestions(questionsBank, answersBank);


			string diagnos = "Не установлен";
			Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
			string userName = Console.ReadLine()!;
			userName = char.ToUpper(userName[0]) + userName.Substring(1);
			Console.WriteLine($"Приятно познакомиться, {userName}.");

			Console.WriteLine("Напишите номер того, что вас интересует.");
			Console.WriteLine("1)Играть 2)Результаты 3)Удалить/Добавить");//File.Append - добавляет
			int userAnswer = Convert.ToInt32(Console.ReadLine());
			
			if (userAnswer == 2)
			{

				Console.WriteLine("Результаты прошлых игр");
				string[] fileData = File.ReadAllLines("..\\..\\..\\гений идиот.txt");
				for (int i = 0; i < fileData.Length; i++)
				{
					string line = fileData[i];
					string[] data = line.Split('#');
					Console.WriteLine($"имя пользователя - {data[0]}, кол-во прав ответов - {data[1]}, диагноз - {data[2]}");
				}
			}
			else if (userAnswer == 3)
			{
				Console.WriteLine("Уточните вы хотите Добавить/Удалить");
				string UserCreateQuestion = Console.ReadLine()!;
				DeleteOrAddQuestions(UserCreateQuestion, questionsBank, answersBank);
				SavingQuestions(questionsBank, answersBank);

			}
			int cnt = 0;
			
			(List<string> questions, List<string> answers) = CreateQuestions(questionsBank, answersBank);
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
				}//подбор

				diagnos = MakeADiagnos(questions, cnt);
				cnt = 0;
				GamingResults(cnt, diagnos, userName);
				Console.WriteLine($"Ваш диагноз - {diagnos}");
			}
		}
		public static string MakeADiagnos(List<string> questions, int cnt)
		{
			List<string> diagnosises = new List<string>() { "Идиот", "Бездарь", "Живчик", "Нормис", "Сигмантей", "Гений" };
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
		static (List<string>, List<string>) CreateQuestions(List<string> questionsBank, List<string> answersBank)
		{
			Random rnd = new Random();

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
		static void GamingResults(int cnt, string diagnos, string userName)
		{

			string results = ($"{userName}#{cnt}#{diagnos}");
			
			File.AppendAllText("..\\..\\..\\гений идиот.txt", results + Environment.NewLine);
		}
		static void DeleteOrAddQuestions(string UserCreateQuestion, List<string> questionsBank, List<string>answersBank)
		{
			if (UserCreateQuestion.Equals("добавить", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Введите вопрос, а после ответ на него:");
				
				string newUserQuestion = Console.ReadLine()!;
				string newUserAnswer = Console.ReadLine()!;
				
				questionsBank.Add($"{questionsBank.Count + 1}){newUserQuestion}");
				answersBank.Add(newUserAnswer);
				
			}
			else if (UserCreateQuestion.Equals("удалить", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Напишите номер вопроса который хотите удалить");
				int numberQueston = Convert.ToInt32(Console.ReadLine()) - 1;
				questionsBank.RemoveAt(numberQueston);
				answersBank.RemoveAt(numberQueston);
			}
		}
		static void SavingQuestions(List<string> questionsBank, List<string> answersBank)
		{
			File.WriteAllLines("..\\..\\..\\Questions.txt", questionsBank);
			File.WriteAllLines("..\\..\\..\\Answers.txt", answersBank);
		}
	}
}
