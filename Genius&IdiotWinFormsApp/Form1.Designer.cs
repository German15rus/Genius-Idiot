namespace Genius_IdiotWinFormsApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			MenuLabel = new Label();
			ResultButton = new Button();
			PlayButton = new Button();
			AddDelQuestionButton = new Button();
			menuPictureBox = new PictureBox();
			((System.ComponentModel.ISupportInitialize)menuPictureBox).BeginInit();
			SuspendLayout();
			// 
			// MenuLabel
			// 
			MenuLabel.AutoSize = true;
			MenuLabel.Font = new Font("Segoe UI", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
			MenuLabel.Location = new Point(422, 26);
			MenuLabel.Name = "MenuLabel";
			MenuLabel.Size = new Size(164, 65);
			MenuLabel.TabIndex = 0;
			MenuLabel.Text = "Меню";
			MenuLabel.Click += label1_Click;
			// 
			// ResultButton
			// 
			ResultButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			ResultButton.Location = new Point(127, 317);
			ResultButton.Name = "ResultButton";
			ResultButton.Size = new Size(170, 85);
			ResultButton.TabIndex = 1;
			ResultButton.Text = "Результаты прошлых игр";
			ResultButton.UseVisualStyleBackColor = true;
			ResultButton.Click += ResultButton_Click;
			// 
			// PlayButton
			// 
			PlayButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			PlayButton.Location = new Point(396, 317);
			PlayButton.Name = "PlayButton";
			PlayButton.Size = new Size(191, 85);
			PlayButton.TabIndex = 2;
			PlayButton.Text = "Играть";
			PlayButton.UseVisualStyleBackColor = true;
			PlayButton.Click += PlayButton_Click;
			// 
			// AddDelQuestionButton
			// 
			AddDelQuestionButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
			AddDelQuestionButton.Location = new Point(696, 317);
			AddDelQuestionButton.Name = "AddDelQuestionButton";
			AddDelQuestionButton.Size = new Size(180, 85);
			AddDelQuestionButton.TabIndex = 3;
			AddDelQuestionButton.Text = "Удалить/Добавить Вопрос";
			AddDelQuestionButton.UseVisualStyleBackColor = true;
			// 
			// menuPictureBox
			// 
			menuPictureBox.BackColor = SystemColors.ActiveBorder;
			menuPictureBox.Image = Properties.Resources._5cda79fb2c21e;
			menuPictureBox.Location = new Point(353, 107);
			menuPictureBox.Name = "menuPictureBox";
			menuPictureBox.Size = new Size(285, 142);
			menuPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			menuPictureBox.TabIndex = 4;
			menuPictureBox.TabStop = false;
			menuPictureBox.Click += pictureBox1_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 128, 0);
			ClientSize = new Size(1028, 499);
			Controls.Add(menuPictureBox);
			Controls.Add(AddDelQuestionButton);
			Controls.Add(PlayButton);
			Controls.Add(ResultButton);
			Controls.Add(MenuLabel);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)menuPictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label MenuLabel;
		private Button ResultButton;
		private Button PlayButton;
		private Button AddDelQuestionButton;
		private PictureBox menuPictureBox;
	}
}
