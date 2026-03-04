namespace Genius___Idiot
{
	public class QuestionsStorage
	{
		private string questionsBankPath = "..\\..\\..\\questionsBank.json";

  //      private string textsPath = "..\\..\\..\\Questions.txt";
		//private string answersPath = "..\\..\\..\\Answers.txt";

		public List<Question> GetAll()
		{
			string jsonContent = File.ReadAllText(questionsBankPath);
			return System.Text.Json.JsonSerializer.Deserialize<List<Question>>(jsonContent) ?? new List<Question>();



            //string[] questionsTexts = File.ReadAllLines(textsPath);
            //string[] questionsAnswers = File.ReadAllLines(answersPath);
            //List<Question> questions = new List<Question>();
            //for (int i = 0; i < questionsTexts.Length; i++)
            //{
            //	Question question = new Question();
            //	question.Text = questionsTexts[i];
            //	question.Answer = questionsAnswers[i];
            //	questions.Add(question);
            //}
            //return questions;
        }

		public void Add(Question question)
		{
            var questions = GetAll();
            questions.Add(question);
            Save(questions);
		}

		public void Remove(int questionIndex)
		{
            var questions = GetAll();
            questionIndex = questionIndex - 1;

            if (questionIndex >= 0 && questionIndex < questions.Count)
            {
                questions.RemoveAt(questionIndex);
                Save(questions);
            }

            questionIndex = questionIndex - 1;
            
   //         var withoutDel = File.ReadAllLines(textsPath).ToList();
			//withoutDel.RemoveAt(questionIndex);
			//File.WriteAllLines(textsPath, withoutDel);
			
			//withoutDel = File.ReadAllLines(answersPath).ToList();
			//withoutDel.RemoveAt(questionIndex);
			//File.WriteAllLines(answersPath, withoutDel);
		}

		public void Save(List<Question> questions)
		{
            string jsonContent = System.Text.Json.JsonSerializer.Serialize(questions, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(questionsBankPath, jsonContent);

   //         List<string> questionsTexts = new List<string>();
			//List<string> questionsAnswers = new List<string>();
			//for (int i = 0; i < questions.Count; i++)
			//{
			//	questionsTexts.Add(questions[i].Text);
			//	questionsAnswers.Add(questions[i].Answer);
			//}

			//File.WriteAllLines(textsPath, questionsTexts);
			//File.WriteAllLines(answersPath, questionsAnswers);
		}
	}
}
