using Genius___Idiot;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Genius_Idiot.TgBot
{
	internal class ProgramTG
	{
		static UsersStorage usersStorage = new UsersStorage();
		static QuestionsStorage questionsStorage = new QuestionsStorage();
		static TelegramBotClient bot = new TelegramBotClient("8519487868:AAG89J-nRMF1hOeeiYCL2bb7nHi7O5JEqmY");
		static int randomIndex;
		static bool GameOn = false;
		static async Task Main(string[] args)
		{

			var me = await bot.GetMe();
			Console.WriteLine($"Bot Name - {me.FirstName}.");

			bot.OnUpdate += Bot_OnUpdate;

			Console.ReadKey();
		}

		private static async Task Bot_OnUpdate(Telegram.Bot.Types.Update update)
		{
			List<Question> questions = questionsStorage.GetAll();
			Random rnd = new Random();



			if (update.Message.Text == "/start")
			{
				await bot.SendMessage(update.Message.Chat.Id, "Выберите :",
					replyMarkup: new KeyboardButton[][] { ["Начать игру", "Результаты"], ["Добавить вопрос"] });

			}

			if (update.Message.Text == "Начать игру")
			{
				GameOn = true;
				
				if (GameOn = true)
				{
					if (GameOn == true)
						randomIndex = rnd.Next(questions.Count);
					await bot.SendMessage(update.Message.Chat.Id, $"{questions[randomIndex].Text}");



					if (update.Message.Text == $"{questions[randomIndex].Answer}")
					{
						await bot.SendMessage(update.Message.Chat.Id, "Правильно");
					}

					else
					{
						bot.SendMessage(update.Message.Chat.Id, $"правильный ответ - {questions[randomIndex].Answer}");
						await bot.SendMessage(update.Message.Chat.Id, "Неправильно");
					}
				}
			}

			if (update.Message.Text == "Результаты")
			{
				var ress = "<pre>";
				ress += $"{"Имя",-30}{"Процент %",-30}{"Диагноз",-30}\n";

				foreach (var user in questionsStorage.GetAll())
				{

				}

			}
		}
	}
}
