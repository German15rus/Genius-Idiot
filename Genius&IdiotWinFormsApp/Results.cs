using Genius___Idiot;

namespace Genius_IdiotWinFormsApp
{
    public partial class Results : Form
    {
        UsersStorage usersStorage = new UsersStorage();
        public Results()
        {
            InitializeComponent();
            var users = usersStorage.GetAll();
            resulterLabel.Text = "";
            foreach (User1 user in users)
            {
                resulterLabel.Text += $"Имя - {user.Name}, Правильный ответ - {user.CorrectAnswers}, Диагноз - {user.Diagnosis}" + Environment.NewLine;
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 menu = new Form1();
            menu.Show();
        }

        private void resulterLabel_Click(object sender, EventArgs e)
        {

        }

        private void Results_Load(object sender, EventArgs e)
        {

        }
    }
}
