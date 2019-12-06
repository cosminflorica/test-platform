namespace test
{
    partial class Recovery
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
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton_Submit = new MetroFramework.Controls.MetroButton();
            this.metroButton_Back = new MetroFramework.Controls.MetroButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your email address!\r\nWe\'ll email your account username and password." +
    "\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // metroButton_Submit
            // 
            this.metroButton_Submit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.metroButton_Submit.Location = new System.Drawing.Point(297, 134);
            this.metroButton_Submit.Name = "metroButton_Submit";
            this.metroButton_Submit.Size = new System.Drawing.Size(103, 29);
            this.metroButton_Submit.TabIndex = 6;
            this.metroButton_Submit.Text = "Submit";
            this.metroButton_Submit.UseCustomBackColor = true;
            this.metroButton_Submit.UseSelectable = true;
            this.metroButton_Submit.Click += new System.EventHandler(this.metroButton_Submit_Click);
            // 
            // metroButton_Back
            // 
            this.metroButton_Back.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.metroButton_Back.Location = new System.Drawing.Point(155, 134);
            this.metroButton_Back.Name = "metroButton_Back";
            this.metroButton_Back.Size = new System.Drawing.Size(103, 29);
            this.metroButton_Back.TabIndex = 7;
            this.metroButton_Back.Text = "Back";
            this.metroButton_Back.UseCustomBackColor = true;
            this.metroButton_Back.UseSelectable = true;
            this.metroButton_Back.Click += new System.EventHandler(this.metroButton_Back_Click);
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(223, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(155, 75);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(245, 23);
            this.metroTextBox1.TabIndex = 8;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox1.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // Recovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 186);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroButton_Back);
            this.Controls.Add(this.metroButton_Submit);
            this.Controls.Add(this.label1);
            this.Name = "Recovery";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Email_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton_Submit;
        private MetroFramework.Controls.MetroButton metroButton_Back;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
    }
}