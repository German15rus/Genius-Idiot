using Genius___Idiot;
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
    public partial class AskName : Form
    {
        User user;

        public AskName()
        {
            InitializeComponent();
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameButton_Click(object sender, EventArgs e)
        {
            user.Name = UserName.Text;
            while (true)
            {
                if ((int.TryParse(user.Name, out _)) && (user.Name != null))
                {
                    Hide();
                    break;
                }
                MessageBox.Show("Неверный ввод");
                UserName.Text = "";
            }
        }

        private void AskName_Load(object sender, EventArgs e)
        {

        }
    }
}
