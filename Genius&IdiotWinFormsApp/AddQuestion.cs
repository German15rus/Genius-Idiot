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
    public partial class AddQuestion : Form
    {
        public AddQuestion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 menu = new Form1();
            menu.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<string> userQuestion = new List<string>() { };
            userQuestion.Add(newQuestionTextBox.Text);
            newQuestionTextBox.Text = "";
            int cnt = 0;
            cnt++;
            if (cnt == 2)
            {
                questionsBank.Add(userQuestion[0]);
                answersBank.Add(userQuestion[1]);
                File.WriteAllLines("..\\..\\..\\Questions.txt", questionsBank);
                File.WriteAllLines("..\\..\\..\\Answers.txt", answersBank);
                Hide();
                Form1 menu = new Form1();
                menu.Show();
            }
        }
    }
}
