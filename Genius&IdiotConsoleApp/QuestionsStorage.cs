namespace Genius___Idiot
{
	public class QuestionsStorage
	{
		private string textsPath = "..\\..\\..\\Questions.txt";
		private string answersPath = "..\\..\\..\\Answers.txt";

		public List<Question> GetAll()
		{
			string[] questionsTexts = File.ReadAllLines(textsPath);
			string[] questionsAnswers = File.ReadAllLines(answersPath);
			List<Question> questions = new List<Question>();
			for (int i = 0; i < questionsTexts.Length; i++)
			{
				Question question = new Question();
				question.Text = questionsTexts[i];
				question.Answer = questionsAnswers[i];
				questions.Add(question);
			}
			return questions;
		}

		public void Add(Question question)
		{
			File.AppendAllText(textsPath, question.Text + Environment.NewLine);
			File.AppendAllText(answersPath, question.Answer + Environment.NewLine);
		}

		public void Remove(int questionIndex)
		{
			//удаляю вопрос
			var withoutDel = File.ReadAllLines(textsPath).ToList();
			withoutDel.RemoveAt(questionIndex);
			File.WriteAllLines(textsPath, withoutDel);
			//удаляю ответ
			withoutDel = File.ReadAllLines(answersPath).ToList();
			withoutDel.RemoveAt(questionIndex);
			File.WriteAllLines(textsPath, withoutDel);
		}

		public void Save(List<Question> questions)
		{
			List<string> questionsTexts = new List<string>();
			List<string> questionsAnswers = new List<string>();
			for (int i = 0; i < questions.Count; i++)
			{
				questionsTexts.Add(questions[i].Text);
				questionsAnswers.Add(questions[i].Answer);
			}

			File.WriteAllLines(textsPath, questionsTexts);
			File.WriteAllLines(answersPath, questionsAnswers);
		}
	}
}
