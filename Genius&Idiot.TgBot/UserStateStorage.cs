using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genius_Idiot.TgBot
{
    public static class UserStateStorage
    {
        public static List<UserState> usersStates = new List<UserState>();
        public static UserState Get(long chatId)
        {
            foreach (var userState in usersStates)
            {
                if (userState.ChatId == chatId)
                {
                    return userState;
                }
            }

            return null;
        }
    }
}
