using Genius___Idiot;

namespace Genius_IdiotWinFormsApp
{
    public partial class AddQuestion : Form
    {
        QuestionsStorage questionsStorage;
        Question question;
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
            var questions = questionsStorage.GetAll();

            userQuestion.Add(newQuestionTextBox.Text);
            newQuestionTextBox.Text = "";

            cnt++;
            if (cnt == 2)
            {
                question.Text = (userQuestion[0]);
                question.Answer = (userQuestion[1]);

                questionsStorage.Add(question);
                questionsStorage.Save(questions);

                MessageBox.Show("Вопрос добавлен");

                Hide();
                Form1 menu = new Form1();
                menu.Show();
            }
        }

        private void AddQuestion_Load(object sender, EventArgs e)
        {

        }
    }
}
