using Genius___Idiot;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Genius_Idiot.TgBot
{
    public class GamePage : Page
    {
        string userText = "";
        int random;
        int questionsCount;
        bool stopGame = false;
        bool CheckHandle = false;
        int cnt = 0;

        User1 user = new User1();
        GamePage gamePage = new GamePage();
        QuestionsStorage questionsStorage = new QuestionsStorage();
        List<Question> questions = new List<Question>();
        Question question = new Question();
        UserState userState = new UserState();
        
        public override string[][] Buttons()
        {
            //string[][] buttons = { ["Начать игру", "Результаты"], ["Добавить вопрос", "Удалить вопрос"] };
            //return buttons;
            throw new NotImplementedException();
        }

        public override async Task Handle(Update update, TelegramBotClient bot)
        {
            userState = UserStateStorage.Get(update.Id);

            CheckHandle = true;

            userText = update.Message.Text;

            if (stopGame)
            {
                userState.CurrentPage = new StartPage();
                StartPage startPage = new StartPage();
                await startPage.View(update, bot);
            }


            throw new NotImplementedException();
        }

        public override string Text() //TODO:
        {
            string text = PlayingGame();

            if (text == null)
            {
                return null;
            }

            return text;
        }

        public string PlayingGame() // Незнаю, после этого кода мне руки оторвать надо и подальше от общества отправить
        {
            string text = "";

            if (userText == question.Answer)
            {
                user.CorrectAnswers++;
                questions.Remove(question);
            }
            
            if (questions.Count == 0)
            {
                questions = questionsStorage.GetAll();

                questionsCount = questions.Count;
            }

            if (CheckHandle)
            {
                CheckHandle = false;

                Random rnd = new Random(questions.Count);
                random = Convert.ToInt32(rnd);

                question = questions[random];

                text = question.Text;
                cnt++;
                userState.CurrentPage = gamePage;
                return text;
            }

            if (cnt == 5)
            {
                user.Diagnosis = DiagnosCalculator.Make(questionsCount, user.CorrectAnswers);
                text = $"Ваш диагноз - {user.Diagnosis}";

                UsersStorage usersStorage = new UsersStorage();
                usersStorage.Add(user);

                stopGame = true;
            }

            return text;
        }
    }
}
