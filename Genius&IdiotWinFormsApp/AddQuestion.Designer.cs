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
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(151, 202);
            label1.Name = "label1";
            label1.Size = new Size(826, 46);
            label1.TabIndex = 0;
            label1.Text = "Сначала напишите вопрос, а затем ответ на него";
            label1.Click += label1_Click;
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addButton.Location = new Point(391, 477);
            addButton.Name = "addButton";
            addButton.Size = new Size(322, 122);
            addButton.TabIndex = 1;
            addButton.Text = "Отправить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // newQuestionTextBox
            // 
            newQuestionTextBox.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            newQuestionTextBox.Location = new Point(151, 342);
            newQuestionTextBox.Name = "newQuestionTextBox";
            newQuestionTextBox.Size = new Size(826, 57);
            newQuestionTextBox.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.OrangeRed;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(938, 31);
            button1.Name = "button1";
            button1.Size = new Size(199, 115);
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
            ClientSize = new Size(1175, 665);
            Controls.Add(button1);
            Controls.Add(newQuestionTextBox);
            Controls.Add(addButton);
            Controls.Add(label1);
            Name = "AddQuestion";
            Text = "AddQuestion";
            Load += AddQuestion_Load;
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