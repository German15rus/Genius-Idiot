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
		public string userName = "";
		public AskName()
		{
			InitializeComponent();
		}

		private void UserName_TextChanged(object sender, EventArgs e)
		{
			userName = UserName.Text;
		}

		private void NameButton_Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
