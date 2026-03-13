using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Genius_Idiot.TgBot
{
    static public class UpdateHelper
    {
        public static long GetChatId(Update  update)
        {
            if (update.CallbackQuery != null)
            {
                long chatId = update.CallbackQuery.From.Id;
                return chatId;
            }
            else
            {
                long chatId = update.Message.Chat.Id;
                return chatId;
            }
        }
    }
}
