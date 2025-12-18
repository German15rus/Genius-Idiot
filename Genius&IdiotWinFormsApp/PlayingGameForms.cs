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
		string diagnos = "";
		string userName = "";


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
	
					Hide();
					AskName name = new AskName();
					name.ShowDialog();
					userName = name.userName;
				if (userName != null)
				{
					diagnos = MakeADiagnos(CountRightAnswers, userName);
					WritingResults(diagnos, userName);
					Hide();
					Form1 menu = new Form1();
					menu.Show();
				}
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
		private string MakeADiagnos(int CountRightAnswers,string userName)
		{
			List<string> diagnosises = new List<string>() { "Идиот", "Бездарь", "Живчик", "Нормис", "Сигмантей", "Гений" };
			double rightAns = CountRightAnswers;
			double countQuestions = 5;
			string diagnos = "";
			double procent = rightAns / countQuestions * 100;
			if (procent == 0)
			{
				MessageBox.Show($"{userName}, Ваш диагноз - {diagnosises[0]}");
				return (diagnos = diagnosises[0]);
			}
			else if (procent < 20)
			{
				MessageBox.Show($"{userName}, Ваш диагноз - {diagnosises[1]}");
				return (diagnos = diagnosises[1]);
			}
			else if (procent < 40)
			{
				MessageBox.Show($"{userName}, Ваш диагноз - {diagnosises[2]}");
				return (diagnos = diagnosises[2]);
			}
			else if (procent < 60)
			{
				MessageBox.Show($"{userName}, Ваш диагноз - {diagnosises[3]}");
				return (diagnos = diagnosises[3]);
			}
			else if (procent < 80)
			{
				MessageBox.Show($"{userName}, Ваш диагноз - {diagnosises[4]}");
				return (diagnos = diagnosises[4]);
			}
			else if (procent <= 100)
			{
				MessageBox.Show($"{userName}, Ваш диагноз - {diagnosises[5]}");
				return (diagnos = diagnosises[5]);
			}
			return (diagnos = diagnosises[0]);
		}
		private void WritingResults(string diagnos,string userName)
		{
			string results = ($"{userName}#{diagnos}");

			File.AppendAllText("..\\..\\..\\гений идиот.txt", results + Environment.NewLine);
		}

		private void UserAnswerTextBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
