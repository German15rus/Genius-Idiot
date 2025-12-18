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
			resultsLabel = new Label();
			QuitButton = new Button();
			SuspendLayout();
			// 
			// resultsLabel
			// 
			resultsLabel.AutoSize = true;
			resultsLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			resultsLabel.Location = new Point(221, 21);
			resultsLabel.Name = "resultsLabel";
			resultsLabel.Size = new Size(155, 30);
			resultsLabel.TabIndex = 0;
			resultsLabel.Text = "результаты тут";
			// 
			// QuitButton
			// 
			QuitButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
			QuitButton.Location = new Point(656, 21);
			QuitButton.Name = "QuitButton";
			QuitButton.Size = new Size(119, 94);
			QuitButton.TabIndex = 1;
			QuitButton.Text = "button1";
			QuitButton.UseVisualStyleBackColor = true;
			// 
			// Results
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(QuitButton);
			Controls.Add(resultsLabel);
			Name = "Results";
			Text = "Results";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label resultsLabel;
		private Button QuitButton;
	}
}