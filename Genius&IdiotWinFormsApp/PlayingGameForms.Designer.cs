namespace Genius_IdiotWinFormsApp
{
	partial class PlayingGameForms
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
            NumberQuestionLabel = new Label();
            QuestionLabel = new Label();
            AnswerButton = new Button();
            UserAnswerTextBox = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // NumberQuestionLabel
            // 
            NumberQuestionLabel.AutoSize = true;
            NumberQuestionLabel.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            NumberQuestionLabel.Location = new Point(28, 30);
            NumberQuestionLabel.Name = "NumberQuestionLabel";
            NumberQuestionLabel.Size = new Size(228, 50);
            NumberQuestionLabel.TabIndex = 0;
            NumberQuestionLabel.Text = "№ вопроса";
            // 
            // QuestionLabel
            // 
            QuestionLabel.AutoSize = true;
            QuestionLabel.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            QuestionLabel.Location = new Point(373, 239);
            QuestionLabel.Name = "QuestionLabel";
            QuestionLabel.Size = new Size(194, 54);
            QuestionLabel.TabIndex = 1;
            QuestionLabel.Text = "Вопроса";
            QuestionLabel.Click += QuestionLabel_Click;
            // 
            // AnswerButton
            // 
            AnswerButton.BackColor = Color.Gold;
            AnswerButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AnswerButton.Location = new Point(232, 468);
            AnswerButton.Margin = new Padding(3, 4, 3, 4);
            AnswerButton.Name = "AnswerButton";
            AnswerButton.Size = new Size(458, 105);
            AnswerButton.TabIndex = 2;
            AnswerButton.Text = "ОТВЕТИТЬ";
            AnswerButton.UseVisualStyleBackColor = false;
            AnswerButton.Click += AnswerButton_Click;
            // 
            // UserAnswerTextBox
            // 
            UserAnswerTextBox.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            UserAnswerTextBox.Location = new Point(166, 369);
            UserAnswerTextBox.Margin = new Padding(3, 4, 3, 4);
            UserAnswerTextBox.Name = "UserAnswerTextBox";
            UserAnswerTextBox.Size = new Size(601, 61);
            UserAnswerTextBox.TabIndex = 3;
            UserAnswerTextBox.TextChanged += UserAnswerTextBox_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.Question;
            pictureBox1.Location = new Point(616, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(306, 195);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // PlayingGameForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(973, 633);
            Controls.Add(pictureBox1);
            Controls.Add(UserAnswerTextBox);
            Controls.Add(AnswerButton);
            Controls.Add(QuestionLabel);
            Controls.Add(NumberQuestionLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlayingGameForms";
            Text = "PlayingGameForms";
            Load += PlayingGameForms_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NumberQuestionLabel;
		private Label QuestionLabel;
		private Button AnswerButton;
		private TextBox UserAnswerTextBox;
        private PictureBox pictureBox1;
    }
}