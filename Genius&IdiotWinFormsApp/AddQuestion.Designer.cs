namespace Genius_IdiotWinFormsApp
{
    partial class AddQuestion
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
            addButton = new Button();
            newQuestionTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(52, 95);
            label1.Name = "label1";
            label1.Size = new Size(687, 38);
            label1.TabIndex = 0;
            label1.Text = "Сначала напишите вопрос, а затем ответ на него";
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addButton.Location = new Point(273, 332);
            addButton.Name = "addButton";
            addButton.Size = new Size(242, 70);
            addButton.TabIndex = 1;
            addButton.Text = "Отправить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // newQuestionTextBox
            // 
            newQuestionTextBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            newQuestionTextBox.Location = new Point(90, 222);
            newQuestionTextBox.Name = "newQuestionTextBox";
            newQuestionTextBox.Size = new Size(613, 47);
            newQuestionTextBox.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.OrangeRed;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(649, 20);
            button1.Name = "button1";
            button1.Size = new Size(139, 61);
            button1.TabIndex = 3;
            button1.Text = "Выход";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // AddQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(newQuestionTextBox);
            Controls.Add(addButton);
            Controls.Add(label1);
            Name = "AddQuestion";
            Text = "AddQuestion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button addButton;
        private TextBox newQuestionTextBox;
        private Button button1;
    }
}