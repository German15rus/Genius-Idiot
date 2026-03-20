using Telegram.Bot;

namespace Genius_Idiot.TgBot
{
    internal class ProgramTG
    {
        static TelegramBotClient bot = new TelegramBotClient("8519487868:AAG89J-nRMF1hOeeiYCL2bb7nHi7O5JEqmY");

        static async Task Main(string[] args)
        {
            var me = await bot.GetMe();


            Console.WriteLine($"Bot Name - {me.FirstName}.");

            bot.OnUpdate += Bot_OnUpdate;

            Console.ReadKey();
        }

        private static async Task Bot_OnUpdate(Telegram.Bot.Types.Update update)
        {

            long chatId = UpdateHelper.GetChatId(update);

            var userState = UserStateStorage.Get(chatId);

            if (userState == null)
            {
                userState = new UserState();

                userState.CurrentPage = new FictPage();
                userState.ChatId = chatId;

                UserStateStorage.Add(userState);
            }

            await userState.CurrentPage.Handle(update, bot);


            //if (usersDict.ContainsKey(chatId))
            //{
            //    User1 existingUser = usersDict[chatId];
            //}
            //else
            //{
            //    User1 newUser = new User1();
            //    newUser.Name = update.Message.From.Username;

            //    usersDict[chatId] = newUser;
            //    userStates[chatId] = "in_menu";
            //}

            //if ((text == "Результаты") && (userStates[chatId] == "in_menu"))
            //{
            //    var ress = "<pre>";
            //    ress += $"{"Имя",-30}{"Кол-во правильных ответов",-30}{"Диагноз",-30}\n";

            //    foreach (var user in usersStorage.GetAll())
            //    {
            //        ress += $"{user.Name,-30}{user.CorrectAnswers,-30}{user.Diagnosis,-30}\n";
            //    }

            //    ress += "</pre>";

            //    await bot.SendMessage(chatId, ress, Telegram.Bot.Types.Enums.ParseMode.Html);

            //    return;
            //}

            //if ((text == "Добавить вопрос") && (userStates[chatId] == "in_menu"))
            //{
            //    await bot.SendMessage(chatId, "Напишите текст вопроса");


            //    userStates[chatId] = "add_question";

            //    return;
            //}

            //if (text == "Удалить вопрос")
            //{
                
            //    var delQuestion = "<pre>";
            //    delQuestion += $"{cnt}){"Текст вопроса - ",-30}\n";

            //    List<Question> delQuestions = questionsStorage.GetAll();

            //    foreach (var quest in delQuestions)
            //    {
            //        delQuestion += $"{quest,-30}";
            //        cnt++;
            //    }
            //    userStates[chatId] = "del_question";
            //}

            //if ((text == "/start") && (userStates[chatId] == "in_menu"))
            //{
            //    await bot.SendMessage(chatId, "Выберите :",
            //            replyMarkup: new KeyboardButton[][] { ["Начать игру", "Результаты"], ["Добавить вопрос", "Удалить вопрос"] });

            //    return;
            //}

            //if (text == "Начать игру")
            //{
            //    Genius___Idiot.User1 currentUser = usersDict[chatId];
            //    userStates[chatId] = "playing_game";


            //    questions = questionsStorage.GetAll();
            //    questionsCount = questions.Count;

            //    randomIndex = rnd.Next(questions.Count);
            //    await bot.SendMessage(chatId, $"{questions[randomIndex].Text}");

            //    return;
            //}


            //if (userStates[chatId] == "playing_game")
            //{
            //    if (text == $"{questions[randomIndex].Answer}")
            //    {
            //        correctAnswers++;
            //        await bot.SendMessage(chatId, "Правильно");
            //    }
            //    else
            //    {
            //        await bot.SendMessage(chatId, $"Неправильно. Правильный ответ - {questions[randomIndex].Answer}");
            //    }

            //    questions.RemoveAt(randomIndex);

            //    if (questions.Count == 0)
            //    {
            //        Genius___Idiot.User1 user = new Genius___Idiot.User1();
            //        user.Name = update.Message.From.Username;
            //        user.CorrectAnswers = correctAnswers;
            //        user.Diagnosis = DiagnosCalculator.Make(questionsCount, correctAnswers);
            //        usersStorage.Add(user);

            //        await bot.SendMessage(chatId, $"Ваш диагноз - {user.Diagnosis}");

            //        userStates[chatId] = "in_menu";

            //        return;
            //    }

            //    randomIndex = rnd.Next(questions.Count);
            //    await bot.SendMessage(chatId, $"{questions[randomIndex].Text}");
            //}

            //if (userStates[chatId] == "add_question")
            //{
            //    newQuestion.Text = text;

            //    userStates[chatId] = "add_answer";

            //    await bot.SendMessage(chatId, "Вопрос принят. Напишите ответ");

            //    return;
            //}

            //if (userStates[chatId] == "add_answer")
            //{
            //    newQuestion.Answer = text;

            //    userStates[chatId] = "in_menu";

            //    questionsStorage.Add(newQuestion);
            //    await bot.SendMessage(chatId, "Вопрос добавлен");
            //}

            //if (userStates[chatId] == "del_question")
            //{
            //    questionsStorage.Remove(cnt);
            //    userStates[chatId] = "in_menu";
            //    await bot.SendMessage(chatId, "Вопрос удалён");
            //}
        }
    }
}
