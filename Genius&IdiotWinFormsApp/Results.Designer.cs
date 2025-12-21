namespace Genius_IdiotWinFormsApp
{
	partial class Results
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
            QuitButton = new Button();
            resultsLabel = new Label();
            textBoxResults = new TextBox();
            SuspendLayout();
            // 
            // QuitButton
            // 
            QuitButton.BackColor = Color.OrangeRed;
            QuitButton.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            QuitButton.Location = new Point(756, 28);
            QuitButton.Margin = new Padding(3, 4, 3, 4);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(130, 112);
            QuitButton.TabIndex = 1;
            QuitButton.Text = "Выйти";
            QuitButton.UseVisualStyleBackColor = false;
            QuitButton.Click += QuitButton_Click;
            // 
            // resultsLabel
            // 
            resultsLabel.Location = new Point(0, 0);
            resultsLabel.Name = "resultsLabel";
            resultsLabel.Size = new Size(100, 23);
            resultsLabel.TabIndex = 0;
            // 
            // textBoxResults
            // 
            textBoxResults.Location = new Point(360, 64);
            textBoxResults.Name = "textBoxResults";
            textBoxResults.Size = new Size(125, 27);
            textBoxResults.TabIndex = 2;
            textBoxResults.TextChanged += textBoxResults_TextChanged;
            // 
            // Results
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(914, 600);
            Controls.Add(textBoxResults);
            Controls.Add(resultsLabel);
            Controls.Add(QuitButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Results";
            Text = "Results";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button QuitButton;
        private Label resultsLabel;
        private TextBox textBoxResults;
    }
}