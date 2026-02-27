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
    public partial class DelQuestion : Form
    {
        QuestionsStorage questionsStorage;
        Question question;
        UsersStorage usersStorage;
        public DelQuestion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var questions = questionsStorage.GetAll();
            while (true)
            {
                string n = numOfQuestionTextBox.Text;

                if (int.TryParse(n, out int i))
                {
                    questionsStorage.Remove(int.Parse(n));
                    break;
                }
                else
                {
                    MessageBox.Show("Введите корректные данные");
                    numOfQuestionTextBox.Text = "";
                }
            }
            
            MessageBox.Show("Вопрос удален");
            Hide();
            AddDelQuestions menu = new AddDelQuestions();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AddDelQuestions menu = new AddDelQuestions();
            menu.Show();
        }

        private void DelQuestion_Load(object sender, EventArgs e)
        {

        }
    }
}
