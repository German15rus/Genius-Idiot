using Genius___Idiot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genius_Idiot.TgBot
{
    
    public static class UserStateStorage
    {
        private static string path = "usersStates.json";
        public static List<UserState> usersStates = new List<UserState>();

        public static UserState Get(long chatId)
        {
            //ADDED CHANGES-----------

            string jsonString = File.ReadAllText(path);
            if (jsonString != null)
            {
                usersStates = JsonConvert.DeserializeObject<List<UserState>>(jsonString);
            }

            //-------------------------------------------

            if (usersStates != null)
            {
                foreach (var userState in usersStates)
                {
                    if (userState.ChatId == chatId)
                    {
                        return userState;
                    }
                }
            }
            
            return null;
        }

        //ADDED CHANGES------------

        public static void Add(UserState userState) 
        {
            usersStates.Add(userState);
            //TODO: DONE ??????
            string jsonString = JsonConvert.SerializeObject(usersStates, Formatting.Indented);

            File.WriteAllText(path, jsonString);
        }
    }
}
