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
		List<string> userQuestion = new List<string>() { };
		int cnt = 0;
        
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
            
            userQuestion.Add(newQuestionTextBox.Text);
            newQuestionTextBox.Text = "";
            
            cnt++;
            if (cnt == 2)
            {
                string g =(userQuestion[0]);
                string z =(userQuestion[1]);
                File.AppendAllText("..\\..\\..\\Questions.txt",g + Environment.NewLine);
                File.AppendAllText("..\\..\\..\\Answers.txt", z+ Environment.NewLine);
                MessageBox.Show("Вопрос добавлен");
                Hide();
                Form1 menu = new Form1();
                menu.Show();
            }
        }
    }
}
