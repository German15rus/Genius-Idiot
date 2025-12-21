namespace Genius_IdiotWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {

            Hide();
            PlayingGameForms play = new PlayingGameForms();
            play.Show();
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            Hide();
            Results res = new Results();
            res.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
