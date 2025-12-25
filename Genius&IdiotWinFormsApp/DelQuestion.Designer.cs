namespace Genius_IdiotWinFormsApp
{
    partial class DelQuestion
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
			button1 = new Button();
			label1 = new Label();
			numOfQuestionTextBox = new TextBox();
			button2 = new Button();
			SuspendLayout();
			// 
			// button1
			// 
			button1.BackColor = Color.OrangeRed;
			button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
			button1.Location = new Point(571, 29);
			button1.Margin = new Padding(3, 2, 3, 2);
			button1.Name = "button1";
			button1.Size = new Size(105, 65);
			button1.TabIndex = 0;
			button1.Text = "Выход";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
			label1.Location = new Point(94, 127);
			label1.Name = "label1";
			label1.Size = new Size(524, 32);
			label1.TabIndex = 1;
			label1.Text = "Напишите вопрос который хотите удалить";
			label1.Click += label1_Click;
			// 
			// numOfQuestionTextBox
			// 
			numOfQuestionTextBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
			numOfQuestionTextBox.Location = new Point(142, 195);
			numOfQuestionTextBox.Margin = new Padding(3, 2, 3, 2);
			numOfQuestionTextBox.Name = "numOfQuestionTextBox";
			numOfQuestionTextBox.Size = new Size(412, 39);
			numOfQuestionTextBox.TabIndex = 2;
			// 
			// button2
			// 
			button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
			button2.Location = new Point(285, 249);
			button2.Name = "button2";
			button2.Size = new Size(134, 54);
			button2.TabIndex = 3;
			button2.Text = "Отправить";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// DelQuestion
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 128, 0);
			ClientSize = new Size(700, 338);
			Controls.Add(button2);
			Controls.Add(numOfQuestionTextBox);
			Controls.Add(label1);
			Controls.Add(button1);
			Margin = new Padding(3, 2, 3, 2);
			Name = "DelQuestion";
			Text = "DelQuestion";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
        private Label label1;
        private TextBox numOfQuestionTextBox;
		private Button button2;
	}
}