using System.Runtime.Intrinsics.X86;
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
        static bool AddQuestion = false;
        static bool AddAnswer = false;
        static bool GameOn = false;
        static List<Question> questions;
        static int questionsCount;
        static int correctAnswers;
        static Question newQuestion = new Question();

        static Random rnd = new Random();
        static async Task Main(string[] args)
        {

            var me = await bot.GetMe();
            Console.WriteLine($"Bot Name - {me.FirstName}.");

            bot.OnUpdate += Bot_OnUpdate;

            Console.ReadKey();
        }

        private static async Task Bot_OnUpdate(Telegram.Bot.Types.Update update)
        {
            if (update.Message.Text == "Результаты")
            {
                var ress = "<pre>";
                ress += $"{"Имя",-30}{"Кол-во правильных ответов",-30}{"Диагноз",-30}\n";

                foreach (var user in usersStorage.GetAll())
                {
                    ress += $"{user.Name,-30}{user.CorrectAnswers,-30}{user.Diagnosis,-30}\n";
                }

                ress += "</pre>";

                await bot.SendMessage(update.Message.Chat.Id, ress, Telegram.Bot.Types.Enums.ParseMode.Html);

                return;
            }

            if (update.Message.Text == "Добавить вопрос")
            {
                await bot.SendMessage(update.Message.Chat.Id, "Напишите текст вопроса");

                AddQuestion = true;

                return;
            }

            if (update.Message.Text == "Удалить вопрос")
            {
				var delQuestion = "<pre>";
				delQuestion += $"{"Текст вопроса - ",-30}\n";

				List<Question> delQuestions = questionsStorage.GetAll();

                foreach (var quest in delQuestions)
                {
                    delQuestion = 
                }
            }

            if (update.Message.Text == "/start")
            {
                await bot.SendMessage(update.Message.Chat.Id, "Выберите :",
                    replyMarkup: new KeyboardButton[][] { ["Начать игру", "Результаты"], ["Добавить вопрос", "Удалить вопрос"] });

                return;
            }

            if (update.Message.Text == "Начать игру")
            {
                GameOn = true;
                
                questions = questionsStorage.GetAll();
                questionsCount = questions.Count;

                randomIndex = rnd.Next(questions.Count);
                await bot.SendMessage(update.Message.Chat.Id, $"{questions[randomIndex].Text}");

                return;
            }


            if (GameOn)
            {
                if (update.Message.Text == $"{questions[randomIndex].Answer}")
                {
                    correctAnswers++;
                    await bot.SendMessage(update.Message.Chat.Id, "Правильно");
                }
                else
                {
                    await bot.SendMessage(update.Message.Chat.Id, $"Неправильно. Правильный ответ - {questions[randomIndex].Answer}");
                }

                questions.RemoveAt(randomIndex);

                if (questions.Count == 0)
                {
                    Genius___Idiot.User user = new Genius___Idiot.User();
                    user.Name = update.Message.From.Username;
                    user.CorrectAnswers = correctAnswers;
                    user.Diagnosis = DiagnosCalculator.Make(questionsCount, correctAnswers);
                    usersStorage.Add(user);

                    Console.WriteLine($"Ваш диагноз - {user.Diagnosis}");

                    return;
                }

                randomIndex = rnd.Next(questions.Count);
                await bot.SendMessage(update.Message.Chat.Id, $"{questions[randomIndex].Text}");
            }

            if (AddQuestion)
            { 
                newQuestion.Text = update.Message.Text;

                AddQuestion = false;
                AddAnswer = true;
                await bot.SendMessage(update.Message.Chat.Id, "Вопрос принят. Напишите ответ");

                return;
            }

            if (AddAnswer)
            {
                newQuestion.Answer = update.Message.Text;

                AddAnswer = false;

                questionsStorage.Add(newQuestion);
                await bot.SendMessage(update.Message.Chat.Id, "Вопрос добавлен");
            }
        }
    }
}
