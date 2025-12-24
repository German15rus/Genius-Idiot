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
    public partial class AddDelQuestions : Form
    {
        public AddDelQuestions()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 menu = new Form1();
            menu.Show();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Hide();
            AddQuestion addMenu = new AddQuestion();
            addMenu.Show();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            Hide();
            DelQuestion delMenu = new DelQuestion();
            delMenu.Show();
        }
    }
}
