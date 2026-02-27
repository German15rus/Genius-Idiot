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
            button1.Location = new Point(653, 39);
            button1.Name = "button1";
            button1.Size = new Size(120, 87);
            button1.TabIndex = 0;
            button1.Text = "Выход";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(107, 169);
            label1.Name = "label1";
            label1.Size = new Size(650, 41);
            label1.TabIndex = 1;
            label1.Text = "Напишите вопрос который хотите удалить";
            label1.Click += label1_Click;
            // 
            // numOfQuestionTextBox
            // 
            numOfQuestionTextBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            numOfQuestionTextBox.Location = new Point(162, 260);
            numOfQuestionTextBox.Name = "numOfQuestionTextBox";
            numOfQuestionTextBox.Size = new Size(470, 47);
            numOfQuestionTextBox.TabIndex = 2;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button2.Location = new Point(326, 332);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(176, 72);
            button2.TabIndex = 3;
            button2.Text = "Отправить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DelQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(800, 451);
            Controls.Add(button2);
            Controls.Add(numOfQuestionTextBox);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "DelQuestion";
            Text = "DelQuestion";
            Load += DelQuestion_Load;
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