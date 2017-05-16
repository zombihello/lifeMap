namespace lifeMap.src
{
    partial class AddConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label_enterConfigurationName = new System.Windows.Forms.Label();
            this.textBox_enterConfigurationName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(116, 63);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(197, 63);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label_enterConfigurationName
            // 
            this.label_enterConfigurationName.AutoSize = true;
            this.label_enterConfigurationName.Location = new System.Drawing.Point(12, 21);
            this.label_enterConfigurationName.Name = "label_enterConfigurationName";
            this.label_enterConfigurationName.Size = new System.Drawing.Size(128, 13);
            this.label_enterConfigurationName.TabIndex = 2;
            this.label_enterConfigurationName.Text = "Enter Configuration Name";
            // 
            // textBox_enterConfigurationName
            // 
            this.textBox_enterConfigurationName.Location = new System.Drawing.Point(12, 37);
            this.textBox_enterConfigurationName.Name = "textBox_enterConfigurationName";
            this.textBox_enterConfigurationName.Size = new System.Drawing.Size(260, 20);
            this.textBox_enterConfigurationName.TabIndex = 3;
            // 
            // AddConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 95);
            this.Controls.Add(this.textBox_enterConfigurationName);
            this.Controls.Add(this.label_enterConfigurationName);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_enterConfigurationName;
        private System.Windows.Forms.TextBox textBox_enterConfigurationName;
    }
}