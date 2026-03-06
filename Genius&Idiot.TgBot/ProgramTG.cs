using Genius___Idiot;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Genius_Idiot.TgBot
{
    internal class ProgramTG
    {
        static QuestionsStorage questionsStorage = new QuestionsStorage();
        static TelegramBotClient bot = new TelegramBotClient("8519487868:AAG89J-nRMF1hOeeiYCL2bb7nHi7O5JEqmY");
        static int randomIndex;
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
                randomIndex = rnd.Next(questions.Count);

                await bot.SendMessage(update.Message.Chat.Id, $"{questions[randomIndex].Text}");
            }
            
            else
            {
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
    }
}
