using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
            throw new NotImplementedException();
        }

        public override string Text()
        {
            string text = "Добро пожаловать";
            return text;
        }
    }
}
