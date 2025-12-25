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
			resulterLabel = new Label();
			SuspendLayout();
			// 
			// QuitButton
			// 
			QuitButton.BackColor = Color.OrangeRed;
			QuitButton.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
			QuitButton.Location = new Point(662, 21);
			QuitButton.Name = "QuitButton";
			QuitButton.Size = new Size(114, 84);
			QuitButton.TabIndex = 1;
			QuitButton.Text = "Выйти";
			QuitButton.UseVisualStyleBackColor = false;
			QuitButton.Click += QuitButton_Click;
			// 
			// resultsLabel
			// 
			resultsLabel.Location = new Point(0, 0);
			resultsLabel.Name = "resultsLabel";
			resultsLabel.Size = new Size(88, 17);
			resultsLabel.TabIndex = 0;
			// 
			// resulterLabel
			// 
			resulterLabel.AutoSize = true;
			resulterLabel.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
			resulterLabel.Location = new Point(296, 31);
			resulterLabel.Name = "resulterLabel";
			resulterLabel.Size = new Size(96, 37);
			resulterLabel.TabIndex = 3;
			resulterLabel.Text = "label1";
			resulterLabel.Click += resulterLabel_Click;
			// 
			// Results
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(255, 128, 0);
			ClientSize = new Size(800, 450);
			Controls.Add(resulterLabel);
			Controls.Add(resultsLabel);
			Controls.Add(QuitButton);
			Name = "Results";
			Text = "Results";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button QuitButton;
        private Label resultsLabel;
        private Label resulterLabel;
    }
}