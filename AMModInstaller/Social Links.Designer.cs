
namespace AMModInstaller
{
    partial class Social_Links
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
            this.YouTubeButton = new System.Windows.Forms.Button();
            this.TwitterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GithubButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // YouTubeButton
            // 
            this.YouTubeButton.Location = new System.Drawing.Point(12, 12);
            this.YouTubeButton.Name = "YouTubeButton";
            this.YouTubeButton.Size = new System.Drawing.Size(75, 23);
            this.YouTubeButton.TabIndex = 0;
            this.YouTubeButton.Text = "Open";
            this.YouTubeButton.UseVisualStyleBackColor = true;
            this.YouTubeButton.Click += new System.EventHandler(this.YouTubeButton_Click);
            // 
            // TwitterButton
            // 
            this.TwitterButton.Location = new System.Drawing.Point(12, 41);
            this.TwitterButton.Name = "TwitterButton";
            this.TwitterButton.Size = new System.Drawing.Size(75, 23);
            this.TwitterButton.TabIndex = 1;
            this.TwitterButton.Text = "Open";
            this.TwitterButton.UseVisualStyleBackColor = true;
            this.TwitterButton.Click += new System.EventHandler(this.TwitterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Youtube - TheSingleOne YT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Twitter - @TheSingleOneYT";
            // 
            // GithubButton
            // 
            this.GithubButton.Location = new System.Drawing.Point(12, 70);
            this.GithubButton.Name = "GithubButton";
            this.GithubButton.Size = new System.Drawing.Size(75, 23);
            this.GithubButton.TabIndex = 6;
            this.GithubButton.Text = "Open";
            this.GithubButton.UseVisualStyleBackColor = true;
            this.GithubButton.Click += new System.EventHandler(this.GithubButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Github - TheSingleOneYT";
            // 
            // Social_Links
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 105);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GithubButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TwitterButton);
            this.Controls.Add(this.YouTubeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Social_Links";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TS1\'s Socials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button YouTubeButton;
        private System.Windows.Forms.Button TwitterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GithubButton;
        private System.Windows.Forms.Label label3;
    }
}