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
			SuspendLayout();
			// 
			// NumberQuestionLabel
			// 
			NumberQuestionLabel.AutoSize = true;
			NumberQuestionLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			NumberQuestionLabel.Location = new Point(28, 19);
			NumberQuestionLabel.Name = "NumberQuestionLabel";
			NumberQuestionLabel.Size = new Size(123, 30);
			NumberQuestionLabel.TabIndex = 0;
			NumberQuestionLabel.Text = "№ вопроса";
			// 
			// QuestionLabel
			// 
			QuestionLabel.AutoSize = true;
			QuestionLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			QuestionLabel.Location = new Point(316, 152);
			QuestionLabel.Name = "QuestionLabel";
			QuestionLabel.Size = new Size(122, 37);
			QuestionLabel.TabIndex = 1;
			QuestionLabel.Text = "Вопроса";
			// 
			// AnswerButton
			// 
			AnswerButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			AnswerButton.Location = new Point(203, 351);
			AnswerButton.Name = "AnswerButton";
			AnswerButton.Size = new Size(401, 79);
			AnswerButton.TabIndex = 2;
			AnswerButton.Text = "ОТВЕТИТЬ";
			AnswerButton.UseVisualStyleBackColor = true;
			AnswerButton.Click += AnswerButton_Click;
			// 
			// UserAnswerTextBox
			// 
			UserAnswerTextBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
			UserAnswerTextBox.Location = new Point(145, 277);
			UserAnswerTextBox.Name = "UserAnswerTextBox";
			UserAnswerTextBox.Size = new Size(517, 39);
			UserAnswerTextBox.TabIndex = 3;
			// 
			// PlayingGameForms
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.GradientActiveCaption;
			ClientSize = new Size(851, 475);
			Controls.Add(UserAnswerTextBox);
			Controls.Add(AnswerButton);
			Controls.Add(QuestionLabel);
			Controls.Add(NumberQuestionLabel);
			Name = "PlayingGameForms";
			Text = "PlayingGameForms";
			Load += PlayingGameForms_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label NumberQuestionLabel;
		private Label QuestionLabel;
		private Button AnswerButton;
		private TextBox UserAnswerTextBox;
	}
}