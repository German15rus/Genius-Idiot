using Genius___Idiot;

namespace Genius_IdiotWinFormsApp
{
    public partial class Results : Form
    {
        UsersStorage usersStorage;

        public Results()
        {
            InitializeComponent();
            var users = usersStorage.GetAll();
            foreach (User user in users)
            {
                resulterLabel.Text = $"Имя - {user.Name}, Диагноз - {user.Diagnos}";
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
