namespace ResultForm
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.passwordValidator1 = new MyFirstControl.PasswordValidator();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(204, 336);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // passwordValidator1
            // 
            this.passwordValidator1.Bigletters = 10;
            this.passwordValidator1.charList = new char[] {
        '/',
        '?',
        '!',
        '#',
        '@',
        '%'};
            this.passwordValidator1.Location = new System.Drawing.Point(172, 23);
            this.passwordValidator1.Name = "passwordValidator1";
            this.passwordValidator1.ShowCapitalLetters = false;
            this.passwordValidator1.ShowDigit = true;
            this.passwordValidator1.ShowMinNumbers = true;
            this.passwordValidator1.ShowSpecialChars = false;
            this.passwordValidator1.Size = new System.Drawing.Size(431, 307);
            this.passwordValidator1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.passwordValidator1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyFirstControl.PasswordValidator passwordValidator1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

