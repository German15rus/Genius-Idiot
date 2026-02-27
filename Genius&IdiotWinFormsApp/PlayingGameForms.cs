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
        User user;
        UsersStorage userStorage;
        QuestionsStorage questionsStorage;
        List<Question> questions;
        Question question;

        Random rnd = new Random();

        int numberQuestion = 0;

        public PlayingGameForms()
        {
            InitializeComponent();

        }

        private void PlayingGameForms_Load(object sender, EventArgs e)
        {
            numberQuestion++;

            questions = questionsStorage.GetAll();

            int rndIndex = rnd.Next(questions.Count);

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

            if (numberQuestion > 5)
            {
                Hide();
                AskName name = new AskName();
                name.ShowDialog();
                user.Name = name.Name;

                user.Diagnos = DiagnosCalculator.Make(questions.Count, user.CorrectAnswers);
                userStorage.Add(user);

                Hide();
                Form1 menu = new Form1();
                menu.Show();

            }

            int rndIndex = rnd.Next();

            question = questions[rndIndex];
            questions.RemoveAt(rndIndex);

            numberQuestion++;

            NumberQuestionLabel.Text = $"Вопрос №{numberQuestion}";
            QuestionLabel.Text = question.Text;
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
