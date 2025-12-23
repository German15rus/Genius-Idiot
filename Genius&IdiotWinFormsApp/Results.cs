using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            if (File.Exists("..\\..\\..\\гений идиот.txt"))
            {
                string[] lines = File.ReadAllLines("..\\..\\..\\гений идиот.txt");
                resulterLabel.Text = string.Join(Environment.NewLine, lines);
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
            
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 menu = new Form1();
            menu.Show();
        }
    }
}
