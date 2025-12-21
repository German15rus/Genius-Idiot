using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Genius_IdiotWinFormsApp
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
            if (File.Exists("гений идиот.txt"))
            {
                textBoxResults.Text = File.ReadAllText("гений идиот.txt");
                textBoxResults.ScrollBars = ScrollBars.Both;
                textBoxResults.Multiline = true;
                textBoxResults.WordWrap = false;
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxResults_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Вы не можете редактировать файл!");
        }
    }
}
