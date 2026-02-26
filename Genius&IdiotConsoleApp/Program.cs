using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

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

			user1.UserName(user1);

			Console.WriteLine($"Приятно познакомиться, {user1.Name}.");

			while (PlayAgain(user1.Name))
			{
				Console.WriteLine("Напишите номер того, что вас интересует.");
				Console.WriteLine("1) Играть 2) Результаты 3) Удалить/Добавить 4) Выйти");

				int userAnswer = CheckAnswer();

				if (userAnswer <= 0 || userAnswer > 4)
				{
					Console.WriteLine("Данные некорректные. Введите номер интересующего вас варианта повторно");
					continue;
				}

				if (userAnswer == 1) //TODO function на срочняках
				{
					user1.CorrectAnswers = 0;

					List<Question> questions = questionsRepository.GetAll();
					int questionsCount = questions.Count;

					Console.WriteLine("Выберите уровень сложности:");
					Console.WriteLine("1) 5 вопросов 2) 10 вопросов 3) все вопросы");
					while (true)
					{
						int userMode = CheckAnswer();
						if (userMode == 1)
						{
							questionsCount = 5;
							break;
						}
						if (userMode == 2)
						{
							questionsCount = 10;
							break;
						}
						if (userMode == 3)
						{
							questionsCount = questions.Count;
							break;
						}
						else
						{
							Console.WriteLine("Введены не корректные данные. Повторите ввод.");
						}
					}

					for (int i = 0; i < questionsCount; i++)
					{
						Random rnd = new Random();
						int randomIndex = rnd.Next(questions.Count);
						Console.WriteLine(questions[randomIndex].Text);

						string questionAnswer = Console.ReadLine()!.ToLower();
						if (questionAnswer == questions[randomIndex].Answer)
						{
							user1.CorrectAnswers++;
						}
						questions.RemoveAt(randomIndex);
					}
                    (int sa, int ca) = PlayingGame(user1, questionsRepository);

					user1.Diagnos = MakeADiagnos(questionsCount, user1.CorrectAnswers);
					res.Add(user1);

					Console.WriteLine($"Ваш диагноз - {user1.Diagnos}");

					continue;
				}

				if (userAnswer == 2)
				{
					ShowResutls(res);
					continue;
				}

				if (userAnswer == 3)
				{
					DeleteOrAddQuestions();
					continue;
				}

				if (userAnswer == 4)
				{
					break;
				}
			}
		}
		
		public (int,int) PlayingGame(User user1, QuestionsStorage questionsRepository)
		{
            user1.CorrectAnswers = 0;

            List<Question> questions = questionsRepository.GetAll();
            int questionsCount = questions.Count;

            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1)5 вопросов 2)10 вопросов 3)Все вопросы");
            while (true)
            {
                int userMode = CheckAnswer();
                if (userMode == 1)
                {
                    questionsCount = 5;
                    break;
                }
                if (userMode == 2)
                {
                    questionsCount = 10;
                    break;
                }
                if (userMode == 3)
                {
                    questionsCount = questions.Count;
                    break;
                }
                else
                {
                    Console.WriteLine("Введены не корректные данные. Повторите ввод.");
                }
            }

            for (int i = 0; i < questionsCount; i++)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(questions.Count);
                Console.WriteLine(questions[randomIndex].Text);

                string questionAnswer = Console.ReadLine()!.ToLower();
                if (questionAnswer == questions[randomIndex].Answer)
                {
                    user1.CorrectAnswers++;
                }
                questions.RemoveAt(randomIndex);
            }
			int correctAns = user1.CorrectAnswers;

			return (correctAns, questionsCount);
        }
		
		private static void ShowResutls(UsersStorage res)
		{
			Console.WriteLine("Результаты прошлых игр");
			List<User> users = res.GetAll();

			Console.WriteLine("--------------------------------------");

			foreach (User user in users)
			{
				Console.WriteLine($"Имя пользователя - {user.Name}, Кол-во прав ответов - {user.CorrectAnswers}, Диагноз - {user.Diagnos}");
			}

			Console.WriteLine("--------------------------------------");
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
			Console.WriteLine($"{userName}, заходите в меню? Введи ответ: Да или Нет.");

			while (true)
			{
				string userAgreed = Console.ReadLine()!.ToLower();
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
		}

		static void DeleteOrAddQuestions()
		{
			string userDecision = "";

			while (true)
			{
				Console.WriteLine("Уточните вы хотите Добавить/Удалить");

				userDecision = Console.ReadLine()!.ToLower();
				if ((userDecision != "добавить") || (userDecision != "удалить"))
				{
					break;
				}
			}
			QuestionsStorage questionsStorage = new QuestionsStorage();

			if (userDecision.Equals("добавить", StringComparison.CurrentCultureIgnoreCase))
			{
				Console.WriteLine("Введите вопрос, а после ответ на него:");

				Question newQuestion = new Question();
				newQuestion.Text = Console.ReadLine()!;
				newQuestion.Answer = Console.ReadLine()!;

				questionsStorage.Add(newQuestion);
			}

			else if (userDecision.Equals("удалить", StringComparison.CurrentCultureIgnoreCase))
			{
				var questions = questionsStorage.GetAll();

				int number = 0;
				foreach (Question question in questions)
				{
					number++;
					Console.WriteLine(number + " " + question.Text);
				}

				Console.WriteLine("Напишите номер вопроса который хотите удалить");

				while (true)
				{
					int questionIndex = CheckAnswer();

					if ((questionIndex <= questions.Count) && (questionIndex > 0))
					{
						questionsStorage.Remove(questionIndex);
						break;
					}

					Console.WriteLine("Введите номер который представлен в списке вопросов!");
				}
			}
		}

		static int CheckAnswer()
		{
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int n))
				{
					return n;
				}

				Console.WriteLine("Введите число!");
			}
		}
	}
}

