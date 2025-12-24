namespace Genius_IdiotWinFormsApp
{
    partial class AddDelQuestions
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
            ChoiseLabel = new Label();
            AddButton = new Button();
            delButton = new Button();
            QuitButton = new Button();
            SuspendLayout();
            // 
            // ChoiseLabel
            // 
            ChoiseLabel.AutoSize = true;
            ChoiseLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ChoiseLabel.Location = new Point(58, 183);
            ChoiseLabel.Name = "ChoiseLabel";
            ChoiseLabel.Size = new Size(710, 46);
            ChoiseLabel.TabIndex = 0;
            ChoiseLabel.Text = "Вы хотите добавить или удалить вопрос?";
            // 
            // AddButton
            // 
            AddButton.Cursor = Cursors.Hand;
            AddButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AddButton.Location = new Point(73, 280);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(188, 90);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // delButton
            // 
            delButton.Cursor = Cursors.Hand;
            delButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            delButton.Location = new Point(558, 280);
            delButton.Name = "delButton";
            delButton.Size = new Size(193, 90);
            delButton.TabIndex = 2;
            delButton.Text = "Удалить";
            delButton.UseVisualStyleBackColor = true;
            delButton.Click += delButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.BackColor = Color.OrangeRed;
            QuitButton.Cursor = Cursors.Hand;
            QuitButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            QuitButton.Location = new Point(639, 24);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(149, 68);
            QuitButton.TabIndex = 3;
            QuitButton.Text = "Выйти";
            QuitButton.UseVisualStyleBackColor = false;
            QuitButton.Click += QuitButton_Click;
            // 
            // AddDelQuestions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(800, 450);
            Controls.Add(QuitButton);
            Controls.Add(delButton);
            Controls.Add(AddButton);
            Controls.Add(ChoiseLabel);
            Name = "AddDelQuestions";
            Text = "AddDelQuestions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ChoiseLabel;
        private Button AddButton;
        private Button delButton;
        private Button QuitButton;
    }
}