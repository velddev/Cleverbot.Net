namespace Cleverbot.Net.Example.Forms
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
            this.Textbox_Input = new System.Windows.Forms.TextBox();
            this.Textbox_MessageLog = new System.Windows.Forms.TextBox();
            this.Label_Status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Textbox_Input
            // 
            this.Textbox_Input.Location = new System.Drawing.Point(12, 228);
            this.Textbox_Input.Name = "Textbox_Input";
            this.Textbox_Input.Size = new System.Drawing.Size(306, 20);
            this.Textbox_Input.TabIndex = 0;
            // 
            // Textbox_MessageLog
            // 
            this.Textbox_MessageLog.BackColor = System.Drawing.Color.White;
            this.Textbox_MessageLog.Location = new System.Drawing.Point(12, 12);
            this.Textbox_MessageLog.Multiline = true;
            this.Textbox_MessageLog.Name = "Textbox_MessageLog";
            this.Textbox_MessageLog.ReadOnly = true;
            this.Textbox_MessageLog.Size = new System.Drawing.Size(306, 210);
            this.Textbox_MessageLog.TabIndex = 1;
            // 
            // Label_Status
            // 
            this.Label_Status.AutoSize = true;
            this.Label_Status.Location = new System.Drawing.Point(12, 251);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(102, 13);
            this.Label_Status.TabIndex = 2;
            this.Label_Status.Text = "Cleverbot is typing...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 270);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.Textbox_MessageLog);
            this.Controls.Add(this.Textbox_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Textbox_Input;
        private System.Windows.Forms.TextBox Textbox_MessageLog;
        private System.Windows.Forms.Label Label_Status;
    }
}

