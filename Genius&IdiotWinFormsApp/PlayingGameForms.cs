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
		List<string> questionsBank = new List<string>() { "Где храниться суета", "Мужское есть", "Как зовут кошку",
				"Когда вы играете в покер играете", "5", "6", "7", "8", "9", "10" };
		List<string> answersBank = new List<string>() { "в барсетке", "жи есть", "бонтик", "между парами", "5", "6", "7", "8", "9", "10" };
		Random rnd = new Random();
		string questions = "";
		string answers = "";
		int numberQuestion = 1;
		int CountRightAnswers = 0;
		int cnt = 0;



		public PlayingGameForms()
		{
			InitializeComponent();
		}

		private void PlayingGameForms_Load(object sender, EventArgs e)
		{

			int rndIndex = rnd.Next(questionsBank.Count);
			questions = (questionsBank[rndIndex]);
			answers = (answersBank[rndIndex]);
			questionsBank.RemoveAt(rndIndex);
			answersBank.RemoveAt(rndIndex);


			NumberQuestionLabel.Text = $"Вопрос №{numberQuestion}";
			QuestionLabel.Text = questions;

			if (UserAnswerTextBox.Text == answers)
			{
				CountRightAnswers++;
			}
			numberQuestion++;
			cnt++;
		}

		private void AnswerButton_Click(object sender, EventArgs e)
		{
			cnt++;
			if (UserAnswerTextBox.Text == answers)
			{
				CountRightAnswers++;
			}
			UserAnswerTextBox.Text = "";
			if (cnt > 5)
			{
				MakeADiagnos(CountRightAnswers);
			}
			int rndIndex = rnd.Next(questionsBank.Count);
			questions = (questionsBank[rndIndex]);
			answers = (answersBank[rndIndex]);
			questionsBank.RemoveAt(rndIndex);
			answersBank.RemoveAt(rndIndex);
			
			NumberQuestionLabel.Text = $"Вопрос №{numberQuestion}";
			QuestionLabel.Text = questions;
			if (UserAnswerTextBox.Text == answers)
			{
				CountRightAnswers++;
			}
			numberQuestion++;
		}
		private void MakeADiagnos(int CountRightAnswers)
		{
			List<string> diagnosises = new List<string>() { "Идиот", "Бездарь", "Живчик", "Нормис", "Сигмантей", "Гений" };
			double rightAns = CountRightAnswers;
			double countQuestions = 5;
			double procent = rightAns / countQuestions * 100;
			if (procent == 0)
				 MessageBox.Show(diagnosises[0]);
			else if (procent < 20)
				MessageBox.Show(diagnosises[1]);
			else if (procent < 40)
				MessageBox.Show(diagnosises[2]);
			else if (procent < 60)
				MessageBox.Show(diagnosises[3]);
			else if (procent < 80)
				MessageBox.Show(diagnosises[4]);
			else if (procent <= 100)
				MessageBox.Show(diagnosises[5]);
		}
	}
}
