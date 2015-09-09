namespace VaultUtilities_CSharp
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
            this.VaultsLabel = new System.Windows.Forms.Label();
            this.VaultsComboBox = new System.Windows.Forms.ComboBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button7 = new System.Windows.Forms.Button();
            this.Button8 = new System.Windows.Forms.Button();
            this.Button9 = new System.Windows.Forms.Button();
            this.Button10 = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            //
            //VaultsLabel
            //
            this.VaultsLabel.AutoSize = true;
            this.VaultsLabel.Location = new System.Drawing.Point(13, 26);
            this.VaultsLabel.Name = "VaultsLabel";
            this.VaultsLabel.Size = new System.Drawing.Size(94, 13);
            this.VaultsLabel.TabIndex = 0;
            this.VaultsLabel.Text = " Select vault view:";
            //
            //VaultsComboBox
            //
            this.VaultsComboBox.FormattingEnabled = true;
            this.VaultsComboBox.Location = new System.Drawing.Point(16, 42);
            this.VaultsComboBox.Name = "VaultsComboBox";
            this.VaultsComboBox.Size = new System.Drawing.Size(121, 21);
            this.VaultsComboBox.TabIndex = 1;
            //
            //Button1
            //
            this.Button1.Location = new System.Drawing.Point(16, 223);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(91, 23);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "Copy file...";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(Button1_Click);
            //
            //Button2
            //
            this.Button2.Location = new System.Drawing.Point(113, 223);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(96, 23);
            this.Button2.TabIndex = 7;
            this.Button2.Text = "Delete file...";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(Button2_Click);
            //
            //Button3
            //
            this.Button3.Location = new System.Drawing.Point(69, 281);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(96, 23);
            this.Button3.TabIndex = 8;
            this.Button3.Text = "Delete folder...";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(Button3_Click);
            //
            //Button4
            //
            this.Button4.Location = new System.Drawing.Point(43, 252);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(156, 23);
            this.Button4.TabIndex = 9;
            this.Button4.Text = "Check-out permission...";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(Button4_Click);
            //
            //Button5
            //
            this.Button5.Location = new System.Drawing.Point(16, 83);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(233, 23);
            this.Button5.TabIndex = 10;
            this.Button5.Text = "Verify SOLIDWORKS Enterprise PDM 5.3";
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(Button5_Click);
            //
            //Button6
            //
            this.Button6.Location = new System.Drawing.Point(16, 121);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(233, 23);
            this.Button6.TabIndex = 11;
            this.Button6.Text = "Get SOLIDWORKS Enterprise PDM licenses";
            this.Button6.UseVisualStyleBackColor = true;
            this.Button6.Click += new System.EventHandler(Button6_Click);
            //
            //Button7
            //
            this.Button7.Location = new System.Drawing.Point(16, 165);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(91, 23);
            this.Button7.TabIndex = 12;
            this.Button7.Text = "Add group";
            this.Button7.UseVisualStyleBackColor = true;
            this.Button7.Click += new System.EventHandler(Button7_Click);
            //
            //Button8
            //
            this.Button8.Location = new System.Drawing.Point(16, 194);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(91, 23);
            this.Button8.TabIndex = 13;
            this.Button8.Text = "Remove group";
            this.Button8.UseVisualStyleBackColor = true;
            this.Button8.Click += new System.EventHandler(Button8_Click);
            //
            //Button9
            //
            this.Button9.Location = new System.Drawing.Point(113, 165);
            this.Button9.Name = "Button9";
            this.Button9.Size = new System.Drawing.Size(96, 23);
            this.Button9.TabIndex = 14;
            this.Button9.Text = "Add user";
            this.Button9.UseVisualStyleBackColor = true;
            this.Button9.Click += new System.EventHandler(Button9_Click);
            //
            //Button10
            //
            this.Button10.Location = new System.Drawing.Point(113, 194);
            this.Button10.Name = "Button10";
            this.Button10.Size = new System.Drawing.Size(96, 23);
            this.Button10.TabIndex = 15;
            this.Button10.Text = "Remove user";
            this.Button10.UseVisualStyleBackColor = true;
            this.Button10.Click += new System.EventHandler(Button10_Click);
            //
            //OpenFileDialog1
            //
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            //
            //Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 330);
            this.Controls.Add(this.Button10);
            this.Controls.Add(this.Button9);
            this.Controls.Add(this.Button8);
            this.Controls.Add(this.Button7);
            this.Controls.Add(this.Button6);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.VaultsComboBox);
            this.Controls.Add(this.VaultsLabel);
            this.Name = "Form1";
            this.Text = "Vault utilities";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label VaultsLabel;
        internal System.Windows.Forms.ComboBox VaultsComboBox;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button6;
        internal System.Windows.Forms.Button Button7;
        internal System.Windows.Forms.Button Button8;
        internal System.Windows.Forms.Button Button9;
        internal System.Windows.Forms.Button Button10;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
    }
}