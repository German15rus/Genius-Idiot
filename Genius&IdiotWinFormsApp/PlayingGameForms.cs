using Genius___Idiot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genius_IdiotWinFormsApp
{
    public partial class PlayingGameForms : Form
    {
        User1 user = new User1();
        UsersStorage userStorage = new UsersStorage();
        QuestionsStorage questionsStorage = new QuestionsStorage();
        List<Question> questions = new List<Question>();
        Question question = new Question();

        Random rnd = new Random();

        int numberQuestion = 0;

        int rndIndex = 0;
        public PlayingGameForms()
        {
            InitializeComponent();

        }

        private void PlayingGameForms_Load(object sender, EventArgs e)
        {
            numberQuestion++;
            questions = questionsStorage.GetAll();

            rndIndex = rnd.Next(questions.Count);
            question = (questions[rndIndex]);

            questions.RemoveAt(rndIndex);

            NumberQuestionLabel.Text = $"Вопрос №{numberQuestion}";
            QuestionLabel.Text = question.Text;
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (UserAnswerTextBox.Text == question.Answer)
            {
                user.CorrectAnswers++;
            }

            UserAnswerTextBox.Text = "";

            

            rndIndex = rnd.Next(questions.Count);

            if (questions.Count == 0)
            {
                questions = questionsStorage.GetAll();
            }    
            
            question = questions[rndIndex];
            questions.RemoveAt(rndIndex);

            numberQuestion++;

            NumberQuestionLabel.Text = $"Вопрос №{numberQuestion}";
            QuestionLabel.Text = question.Text;


            if (numberQuestion > 5)
            {
                Hide();
                AskName name = new AskName();
                name.ShowDialog();
                user.Name = name.user.Name;

                user.Diagnosis = DiagnosCalculator.Make(questions.Count, user.CorrectAnswers);
                userStorage.Add(user);

                Hide();
                Form1 menu = new Form1();
                menu.Show();

            }
        }

        private void UserAnswerTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuestionLabel_Click(object sender, EventArgs e)
        {

        }

        private void NumberQuestionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
