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
    public abstract class Page
    {
        public abstract string Text();

        public abstract string[][] Buttons();

        public abstract Task Handle(Update update, TelegramBotClient bot);

        public async Task View(Update update, TelegramBotClient bot)
        {
            var buttonsString = Buttons();
            var keyboardButtons = new List<List<InlineKeyboardButton>>();

            foreach (var row in buttonsString)
            {
                var buttonRow = new List<InlineKeyboardButton>();
                foreach (var text in row)
                {
                    string callbackData = text.Replace(" ", "_");
                    buttonRow.Add(InlineKeyboardButton.WithCallbackData(text, callbackData));
                }
                keyboardButtons.Add(buttonRow);
            }

            if (update.CallbackQuery != null)
            {
                long chatId = update.CallbackQuery.From.Id;
                await bot.SendMessage(chatId, Text(), replyMarkup: new InlineKeyboardMarkup(keyboardButtons));
            }
            else
            {
                long chatId = update.Message.Chat.Id;
                await bot.SendMessage(chatId, Text(), replyMarkup: new InlineKeyboardMarkup(keyboardButtons));
            }
        }
    }
}
