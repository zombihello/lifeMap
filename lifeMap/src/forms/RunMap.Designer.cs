namespace lifeMap.src.forms
{
    partial class RunMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunMap));
            this.checkBox_startGame = new System.Windows.Forms.CheckBox();
            this.label_additionalGamePar = new System.Windows.Forms.Label();
            this.textBox_additionalGamePar = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox_startGame
            // 
            this.checkBox_startGame.AutoSize = true;
            this.checkBox_startGame.Checked = true;
            this.checkBox_startGame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_startGame.Location = new System.Drawing.Point(12, 12);
            this.checkBox_startGame.Name = "checkBox_startGame";
            this.checkBox_startGame.Size = new System.Drawing.Size(172, 17);
            this.checkBox_startGame.TabIndex = 0;
            this.checkBox_startGame.Text = "Run The Game After Compiling";
            this.checkBox_startGame.UseVisualStyleBackColor = true;
            // 
            // label_additionalGamePar
            // 
            this.label_additionalGamePar.AutoSize = true;
            this.label_additionalGamePar.Location = new System.Drawing.Point(12, 43);
            this.label_additionalGamePar.Name = "label_additionalGamePar";
            this.label_additionalGamePar.Size = new System.Drawing.Size(140, 13);
            this.label_additionalGamePar.TabIndex = 1;
            this.label_additionalGamePar.Text = "Additional Game Parametes:";
            // 
            // textBox_additionalGamePar
            // 
            this.textBox_additionalGamePar.Location = new System.Drawing.Point(12, 59);
            this.textBox_additionalGamePar.Name = "textBox_additionalGamePar";
            this.textBox_additionalGamePar.Size = new System.Drawing.Size(246, 20);
            this.textBox_additionalGamePar.TabIndex = 2;
            this.textBox_additionalGamePar.Text = "-window -width 800 -height 600";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(102, 85);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(183, 85);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // RunMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 116);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_additionalGamePar);
            this.Controls.Add(this.label_additionalGamePar);
            this.Controls.Add(this.checkBox_startGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunMap";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RunMap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_startGame;
        private System.Windows.Forms.Label label_additionalGamePar;
        private System.Windows.Forms.TextBox textBox_additionalGamePar;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}