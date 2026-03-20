using Telegram.Bot;
using Telegram.Bot.Types;

namespace Genius_Idiot.TgBot
{
    public class StartPage : Page
    {
        public override string[][] Buttons()
        {
            string[][] buttons = { ["Начать игру", "Результаты"], ["Добавить вопрос", "Удалить вопрос"] };
            return buttons;
        }

        public override async Task Handle(Update update, TelegramBotClient bot)
        {
            if (update.CallbackQuery.Message.Text == "Начать игру")
            {
                GamePage gamePage = new GamePage();
                await gamePage.View(update, bot);
                //CREATE PAGE GAME
            }

            if (update.CallbackQuery.Message.Text == "Результаты")
            {
                //CREATE PAGE RESULTS
            }

            if (update.CallbackQuery.Message.Text == "Добавить вопрос")
            {
                //CREATE PAGE ADDQUESTION
            }

            if (update.CallbackQuery.Message.Text == "Удалить вопрос")
            {
                //CREATE PAGE DELQUESTION
            }

            else if (update.Message.Text != null)
            {
                await bot.SendMessage(update.Message.Chat.Id, "друг, я для кого кнопки делал???");
            }

            throw new NotImplementedException();
        }

        public override string Text()
        {
            string text = "Добро пожаловать! Выбирайте интересующий вас функционал";
            return text;
        }
    }
}
