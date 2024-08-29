namespace WinFormsApp1.UI.Views.Forms.VoteCheckers
{
    partial class VoteCheckerForm
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
            this._passportTextbox = new System.Windows.Forms.TextBox();
            this._inputText = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._textResult = new System.Windows.Forms.TextBox();
            this._checkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PassportTextbox
            // 
            this._passportTextbox.Location = new System.Drawing.Point(30, 96);
            this._passportTextbox.Name = "_passportTextbox";
            this._passportTextbox.Size = new System.Drawing.Size(303, 20);
            this._passportTextbox.TabIndex = 0;
            // 
            // InputText
            // 
            this._inputText.Location = new System.Drawing.Point(30, 55);
            this._inputText.Name = "_inputText";
            this._inputText.Size = new System.Drawing.Size(192, 26);
            this._inputText.TabIndex = 1;
            this._inputText.Text = "Input Text";
            // 
            // label2
            // 
            this._label2.Location = new System.Drawing.Point(30, 198);
            this._label2.Name = "_label2";
            this._label2.Size = new System.Drawing.Size(192, 26);
            this._label2.TabIndex = 3;
            this._label2.Text = "Output Text";
            // 
            // TextResult
            // 
            this._textResult.Location = new System.Drawing.Point(30, 239);
            this._textResult.Name = "_textResult";
            this._textResult.Size = new System.Drawing.Size(303, 20);
            this._textResult.TabIndex = 2;
            // 
            // СheckButton
            // 
            this._checkButton.Location = new System.Drawing.Point(443, 80);
            this._checkButton.Name = "_checkButton";
            this._checkButton.Size = new System.Drawing.Size(315, 202);
            this._checkButton.TabIndex = 4;
            this._checkButton.Text = "button1";
            this._checkButton.UseVisualStyleBackColor = true;
            this._checkButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._checkButton);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._textResult);
            this.Controls.Add(this._inputText);
            this.Controls.Add(this._passportTextbox);
            this.Name = "VoteCheckerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button _checkButton;

        private System.Windows.Forms.TextBox _textResult;
        private System.Windows.Forms.TextBox _passportTextbox;
        private System.Windows.Forms.Label _inputText;
        private System.Windows.Forms.Label _label2;

        #endregion
    }
}