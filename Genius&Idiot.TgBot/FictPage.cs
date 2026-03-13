using Telegram.Bot;
using Telegram.Bot.Types;

namespace Genius_Idiot.TgBot
{
    public class FictPage : Page
    {
        public override string[][] Buttons()
        {
            return new string[0][];
        }

        public override async Task Handle(Update update, TelegramBotClient bot)
        {
            StartPage startPage = new StartPage();

            await startPage.View(update, bot);
        }

        public override string Text()
        {
            string text = "";
            return text;
        }
    }
}
