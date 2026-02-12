using System.IO.Pipes;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Genius___Idiot
{
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
			//List<string> questionsBank = new List<string>() { "1)Где храниться суета", "2)Мужское есть", "3)Как зовут кошку",
			//	"4)", "5)5", "6)6", "7)7", "8)8", "9)9", "10)10" };
			//List<string> answersBank = new List<string>() { "в барсетке", "жи есть", "бонтик", "4", "5", "6", "7", "8", "9", "10" };
			
			SavingQuestions(questions);

			string diagnos = "Не установлен";
			Console.WriteLine("Добро пожаловать на игру! Введите своё имя:");
			string userName = Console.ReadLine()!;
			userName = char.ToUpper(userName[0]) + userName.Substring(1);
			Console.WriteLine($"Приятно познакомиться, {userName}.");

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
					string[] data = line.Split('#');
					Console.WriteLine($"имя пользователя - {data[0]}, кол-во прав ответов - {data[1]}, диагноз - {data[2]}");
				}
			}
			else if (userAnswer == 3)
			{
				Console.WriteLine("Уточните вы хотите Добавить/Удалить");
				string UserCreateQuestion = Console.ReadLine()!;
				DeleteOrAddQuestions(UserCreateQuestion, questions);
				SavingQuestions(questions);

			}
			int cnt = 0;
			int gameLength = questions.Count;
			while (PlayAgain(userName))
			{
                List<Question> gameQuestions = CreateQuestions();
                for (int i = 0; i < gameLength; i++)
				{
					Random rnd = new Random();
					int randomIndex = rnd.Next(gameQuestions.Count);
					Console.WriteLine(gameQuestions[randomIndex].Text);

					string QuestionAnswer = Console.ReadLine()!;
					QuestionAnswer = QuestionAnswer.ToLower();
					if (QuestionAnswer == gameQuestions[randomIndex].Answer)
					{
						cnt++;
					}
					gameQuestions.RemoveAt(randomIndex);
				}
				diagnos = MakeADiagnos(questions, cnt);
				cnt = 0;
				GamingResults(cnt, diagnos, userName);
				Console.WriteLine($"Ваш диагноз - {diagnos}");
			}
		}
		public static string MakeADiagnos(List<Question> questions, int cnt)
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
			Random rnd = new Random();
			//List<string> questions1 = new List<string>();
			//List<string> answer1 = new List<string>();

			//for (int i = 0; i < questions.Count; i++)
			//{
			//	int rndIndex = rnd.Next(questions.Count);
			//	questions1.Add(questions[rndIndex].Text);
			//	answer1.Add(questions[rndIndex].Answer);
			//	questions.RemoveAt(rndIndex);
			//}
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
		static void DeleteOrAddQuestions(string UserCreateQuestion, List<Question> questions)
		{
			Question newQuestion = new Question();
			if (UserCreateQuestion.Equals("добавить", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Введите вопрос, а после ответ на него:");
				
				string newQuestionText = Console.ReadLine()!;
				string newQuestionAnswer = Console.ReadLine()!;
				newQuestion.Text = newQuestionText;
				newQuestion.Answer = newQuestionAnswer;
				questions.Add(newQuestion);
			}
			else if (UserCreateQuestion.Equals("удалить", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Напишите номер вопроса который хотите удалить");
				int numberQueston = Convert.ToInt32(Console.ReadLine()) - 1;
				questions.RemoveAt(numberQueston);
			}
		}
		static void SavingQuestions(List<Question> questions)
		{
			List<string> fileQuestion = new List<string>();
			List<string> fileAnswer = new List<string>();
			for (int i = 0; i < questions.Count; i++)
			{
				fileQuestion.Add(questions[i].Text);
				fileAnswer.Add(questions[i].Answer);
			}
			File.WriteAllLines("..\\..\\..\\Questions.txt", fileQuestion);
			File.WriteAllLines("..\\..\\..\\Answers.txt", fileAnswer);
		}
	}
}
