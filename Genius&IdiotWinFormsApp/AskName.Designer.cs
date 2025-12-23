namespace Genius_IdiotWinFormsApp
{
	partial class AskName
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            UserName = new TextBox();
            NameButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(255, 93);
            label1.Name = "label1";
            label1.Size = new Size(448, 62);
            label1.TabIndex = 0;
            label1.Text = "Введите свое имя:";
            // 
            // UserName
            // 
            UserName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserName.Location = new Point(282, 206);
            UserName.Margin = new Padding(3, 4, 3, 4);
            UserName.Name = "UserName";
            UserName.Size = new Size(398, 47);
            UserName.TabIndex = 1;
            UserName.TextChanged += UserName_TextChanged;
            // 
            // NameButton
            // 
            NameButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            NameButton.Location = new Point(391, 290);
            NameButton.Margin = new Padding(3, 4, 3, 4);
            NameButton.Name = "NameButton";
            NameButton.Size = new Size(192, 71);
            NameButton.TabIndex = 2;
            NameButton.Text = "Отправить";
            NameButton.UseVisualStyleBackColor = true;
            NameButton.Click += NameButton_Click;
            // 
            // AskName
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(942, 397);
            Controls.Add(NameButton);
            Controls.Add(UserName);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AskName";
            Text = "AskName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
		private TextBox UserName;
		private Button NameButton;
	}
}