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
		public List<string> questionsBank = new List<string>() { "Где храниться суета", "Мужское есть", "Как зовут кошку",
				"Когда вы играете в покер играете", "Что бывает во вторник в 14:20 по МСК?",
			"Что тебе нужно если у тебя очень много проблем в жизни?", "7", "8", "9", "10" };
		public List<string> answersBank = new List<string>() { "в барсетке", "жи есть", "бонтик", "между парами", "олимпиадка",
			"отладка", "7", "8", "9", "10" };
		public DelQuestion()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			string n = numOfQuestionTextBox.Text;
			for (int t = 0; t < questionsBank.Count; t++)
			{
				if (n == questionsBank[t])
				{
					questionsBank.Remove(n);
					answersBank.Remove(n);
					MessageBox.Show("Вопрос удален");
					Hide();
					AddDelQuestions menu = new AddDelQuestions();
					menu.Show();
					break;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Hide();
			AddDelQuestions menu = new AddDelQuestions();
			menu.Show();
		}
	}
}
