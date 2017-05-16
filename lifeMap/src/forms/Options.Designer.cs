namespace lifeMap.src
{
    partial class Options
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_general = new System.Windows.Forms.TabPage();
            this.button_exportMapDirectory = new System.Windows.Forms.Button();
            this.textBox_exportMapDirectory = new System.Windows.Forms.TextBox();
            this.label_exportMapDirectory = new System.Windows.Forms.Label();
            this.button_browseSrcMapDirectory = new System.Windows.Forms.Button();
            this.textBox_srcMapDirectory = new System.Windows.Forms.TextBox();
            this.label_srcMapDirectory = new System.Windows.Forms.Label();
            this.button_browseTextureDirectory = new System.Windows.Forms.Button();
            this.textBox_texturesDirectory = new System.Windows.Forms.TextBox();
            this.label_texturesDirectory = new System.Windows.Forms.Label();
            this.button_browse = new System.Windows.Forms.Button();
            this.textBox_gameExecutable = new System.Windows.Forms.TextBox();
            this.label_gameExecutableDirectory = new System.Windows.Forms.Label();
            this.button_editConfiguration = new System.Windows.Forms.Button();
            this.comboBox_configuration = new System.Windows.Forms.ComboBox();
            this.label_configuration = new System.Windows.Forms.Label();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label_gameDataFiles = new System.Windows.Forms.Label();
            this.listBox_gameDataFiles = new System.Windows.Forms.ListBox();
            this.tabPage_views = new System.Windows.Forms.TabPage();
            this.groupBox_3dView = new System.Windows.Forms.GroupBox();
            this.checkBox_filterTextures = new System.Windows.Forms.CheckBox();
            this.textBox_cameraFOV = new System.Windows.Forms.TextBox();
            this.label_cameraFOV = new System.Windows.Forms.Label();
            this.label_maxRenderDistance = new System.Windows.Forms.Label();
            this.trackBar_renderDistance = new System.Windows.Forms.TrackBar();
            this.label_renderDistance = new System.Windows.Forms.Label();
            this.groupBox_2dView = new System.Windows.Forms.GroupBox();
            this.label_MaxIntensivity = new System.Windows.Forms.Label();
            this.label_SmallIntesivity = new System.Windows.Forms.Label();
            this.trackBar_intensity = new System.Windows.Forms.TrackBar();
            this.label_intensity = new System.Windows.Forms.Label();
            this.comboBox_sizeGrid = new System.Windows.Forms.ComboBox();
            this.label_sizeGrid = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_general.SuspendLayout();
            this.tabPage_views.SuspendLayout();
            this.groupBox_3dView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_renderDistance)).BeginInit();
            this.groupBox_2dView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_intensity)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_general);
            this.tabControl1.Controls.Add(this.tabPage_views);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(450, 381);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_general
            // 
            this.tabPage_general.BackColor = System.Drawing.Color.White;
            this.tabPage_general.Controls.Add(this.button_exportMapDirectory);
            this.tabPage_general.Controls.Add(this.textBox_exportMapDirectory);
            this.tabPage_general.Controls.Add(this.label_exportMapDirectory);
            this.tabPage_general.Controls.Add(this.button_browseSrcMapDirectory);
            this.tabPage_general.Controls.Add(this.textBox_srcMapDirectory);
            this.tabPage_general.Controls.Add(this.label_srcMapDirectory);
            this.tabPage_general.Controls.Add(this.button_browseTextureDirectory);
            this.tabPage_general.Controls.Add(this.textBox_texturesDirectory);
            this.tabPage_general.Controls.Add(this.label_texturesDirectory);
            this.tabPage_general.Controls.Add(this.button_browse);
            this.tabPage_general.Controls.Add(this.textBox_gameExecutable);
            this.tabPage_general.Controls.Add(this.label_gameExecutableDirectory);
            this.tabPage_general.Controls.Add(this.button_editConfiguration);
            this.tabPage_general.Controls.Add(this.comboBox_configuration);
            this.tabPage_general.Controls.Add(this.label_configuration);
            this.tabPage_general.Controls.Add(this.button_remove);
            this.tabPage_general.Controls.Add(this.button_edit);
            this.tabPage_general.Controls.Add(this.button_add);
            this.tabPage_general.Controls.Add(this.label_gameDataFiles);
            this.tabPage_general.Controls.Add(this.listBox_gameDataFiles);
            this.tabPage_general.Location = new System.Drawing.Point(4, 22);
            this.tabPage_general.Name = "tabPage_general";
            this.tabPage_general.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_general.Size = new System.Drawing.Size(442, 355);
            this.tabPage_general.TabIndex = 0;
            this.tabPage_general.Text = "General";
            // 
            // button_exportMapDirectory
            // 
            this.button_exportMapDirectory.Location = new System.Drawing.Point(353, 269);
            this.button_exportMapDirectory.Name = "button_exportMapDirectory";
            this.button_exportMapDirectory.Size = new System.Drawing.Size(81, 23);
            this.button_exportMapDirectory.TabIndex = 19;
            this.button_exportMapDirectory.Text = "Browse";
            this.button_exportMapDirectory.UseVisualStyleBackColor = true;
            this.button_exportMapDirectory.Click += new System.EventHandler(this.button_exportMapDirectory_Click);
            // 
            // textBox_exportMapDirectory
            // 
            this.textBox_exportMapDirectory.Location = new System.Drawing.Point(9, 269);
            this.textBox_exportMapDirectory.Name = "textBox_exportMapDirectory";
            this.textBox_exportMapDirectory.Size = new System.Drawing.Size(338, 20);
            this.textBox_exportMapDirectory.TabIndex = 18;
            // 
            // label_exportMapDirectory
            // 
            this.label_exportMapDirectory.AutoSize = true;
            this.label_exportMapDirectory.Location = new System.Drawing.Point(6, 253);
            this.label_exportMapDirectory.Name = "label_exportMapDirectory";
            this.label_exportMapDirectory.Size = new System.Drawing.Size(206, 13);
            this.label_exportMapDirectory.TabIndex = 17;
            this.label_exportMapDirectory.Text = "Export Map Directory (ex C:\\Game\\Maps):";
            // 
            // button_browseSrcMapDirectory
            // 
            this.button_browseSrcMapDirectory.Location = new System.Drawing.Point(353, 318);
            this.button_browseSrcMapDirectory.Name = "button_browseSrcMapDirectory";
            this.button_browseSrcMapDirectory.Size = new System.Drawing.Size(81, 23);
            this.button_browseSrcMapDirectory.TabIndex = 16;
            this.button_browseSrcMapDirectory.Text = "Browse";
            this.button_browseSrcMapDirectory.UseVisualStyleBackColor = true;
            this.button_browseSrcMapDirectory.Click += new System.EventHandler(this.button_browseSrcMapDirectory_Click);
            // 
            // textBox_srcMapDirectory
            // 
            this.textBox_srcMapDirectory.Location = new System.Drawing.Point(9, 321);
            this.textBox_srcMapDirectory.Name = "textBox_srcMapDirectory";
            this.textBox_srcMapDirectory.Size = new System.Drawing.Size(338, 20);
            this.textBox_srcMapDirectory.TabIndex = 15;
            // 
            // label_srcMapDirectory
            // 
            this.label_srcMapDirectory.AutoSize = true;
            this.label_srcMapDirectory.Location = new System.Drawing.Point(6, 305);
            this.label_srcMapDirectory.Name = "label_srcMapDirectory";
            this.label_srcMapDirectory.Size = new System.Drawing.Size(239, 13);
            this.label_srcMapDirectory.TabIndex = 14;
            this.label_srcMapDirectory.Text = "lifeMap MAP Directory (ex C:\\GameSrc\\MapSrc):";
            // 
            // button_browseTextureDirectory
            // 
            this.button_browseTextureDirectory.Location = new System.Drawing.Point(353, 222);
            this.button_browseTextureDirectory.Name = "button_browseTextureDirectory";
            this.button_browseTextureDirectory.Size = new System.Drawing.Size(81, 23);
            this.button_browseTextureDirectory.TabIndex = 13;
            this.button_browseTextureDirectory.Text = "Browse";
            this.button_browseTextureDirectory.UseVisualStyleBackColor = true;
            this.button_browseTextureDirectory.Click += new System.EventHandler(this.button_browseTextureDirectory_Click);
            // 
            // textBox_texturesDirectory
            // 
            this.textBox_texturesDirectory.Location = new System.Drawing.Point(9, 222);
            this.textBox_texturesDirectory.Name = "textBox_texturesDirectory";
            this.textBox_texturesDirectory.Size = new System.Drawing.Size(338, 20);
            this.textBox_texturesDirectory.TabIndex = 12;
            // 
            // label_texturesDirectory
            // 
            this.label_texturesDirectory.AutoSize = true;
            this.label_texturesDirectory.Location = new System.Drawing.Point(6, 206);
            this.label_texturesDirectory.Name = "label_texturesDirectory";
            this.label_texturesDirectory.Size = new System.Drawing.Size(208, 13);
            this.label_texturesDirectory.TabIndex = 11;
            this.label_texturesDirectory.Text = "Textures Directory (ex C:\\Game\\Textures):";
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(353, 166);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(81, 23);
            this.button_browse.TabIndex = 10;
            this.button_browse.Text = "Browse";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // textBox_gameExecutable
            // 
            this.textBox_gameExecutable.Location = new System.Drawing.Point(9, 169);
            this.textBox_gameExecutable.Name = "textBox_gameExecutable";
            this.textBox_gameExecutable.Size = new System.Drawing.Size(338, 20);
            this.textBox_gameExecutable.TabIndex = 9;
            // 
            // label_gameExecutableDirectory
            // 
            this.label_gameExecutableDirectory.AutoSize = true;
            this.label_gameExecutableDirectory.Location = new System.Drawing.Point(6, 153);
            this.label_gameExecutableDirectory.Name = "label_gameExecutableDirectory";
            this.label_gameExecutableDirectory.Size = new System.Drawing.Size(205, 13);
            this.label_gameExecutableDirectory.TabIndex = 8;
            this.label_gameExecutableDirectory.Text = "Game Executable Directory (ex C:\\Game):";
            // 
            // button_editConfiguration
            // 
            this.button_editConfiguration.Location = new System.Drawing.Point(353, 29);
            this.button_editConfiguration.Name = "button_editConfiguration";
            this.button_editConfiguration.Size = new System.Drawing.Size(81, 23);
            this.button_editConfiguration.TabIndex = 7;
            this.button_editConfiguration.Text = "Edit";
            this.button_editConfiguration.UseVisualStyleBackColor = true;
            this.button_editConfiguration.Click += new System.EventHandler(this.button_editConfiguration_Click);
            // 
            // comboBox_configuration
            // 
            this.comboBox_configuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_configuration.FormattingEnabled = true;
            this.comboBox_configuration.Location = new System.Drawing.Point(8, 29);
            this.comboBox_configuration.Name = "comboBox_configuration";
            this.comboBox_configuration.Size = new System.Drawing.Size(339, 21);
            this.comboBox_configuration.TabIndex = 6;
            this.comboBox_configuration.SelectedIndexChanged += new System.EventHandler(this.comboBox_configuration_SelectedIndexChanged);
            // 
            // label_configuration
            // 
            this.label_configuration.AutoSize = true;
            this.label_configuration.Location = new System.Drawing.Point(6, 13);
            this.label_configuration.Name = "label_configuration";
            this.label_configuration.Size = new System.Drawing.Size(72, 13);
            this.label_configuration.TabIndex = 5;
            this.label_configuration.Text = "Configuration:";
            // 
            // button_remove
            // 
            this.button_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_remove.Location = new System.Drawing.Point(353, 112);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(81, 23);
            this.button_remove.TabIndex = 4;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_edit
            // 
            this.button_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_edit.Location = new System.Drawing.Point(397, 83);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(37, 23);
            this.button_edit.TabIndex = 3;
            this.button_edit.Text = "Edit";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Location = new System.Drawing.Point(353, 83);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(38, 23);
            this.button_add.TabIndex = 2;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // label_gameDataFiles
            // 
            this.label_gameDataFiles.AutoSize = true;
            this.label_gameDataFiles.Location = new System.Drawing.Point(5, 65);
            this.label_gameDataFiles.Name = "label_gameDataFiles";
            this.label_gameDataFiles.Size = new System.Drawing.Size(123, 13);
            this.label_gameDataFiles.TabIndex = 1;
            this.label_gameDataFiles.Text = "Game Data Files (Entity):";
            // 
            // listBox_gameDataFiles
            // 
            this.listBox_gameDataFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_gameDataFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_gameDataFiles.FormattingEnabled = true;
            this.listBox_gameDataFiles.Location = new System.Drawing.Point(6, 83);
            this.listBox_gameDataFiles.Name = "listBox_gameDataFiles";
            this.listBox_gameDataFiles.Size = new System.Drawing.Size(341, 54);
            this.listBox_gameDataFiles.TabIndex = 0;
            // 
            // tabPage_views
            // 
            this.tabPage_views.Controls.Add(this.groupBox_3dView);
            this.tabPage_views.Controls.Add(this.groupBox_2dView);
            this.tabPage_views.Location = new System.Drawing.Point(4, 22);
            this.tabPage_views.Name = "tabPage_views";
            this.tabPage_views.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_views.Size = new System.Drawing.Size(442, 355);
            this.tabPage_views.TabIndex = 1;
            this.tabPage_views.Text = "Views";
            this.tabPage_views.UseVisualStyleBackColor = true;
            // 
            // groupBox_3dView
            // 
            this.groupBox_3dView.Controls.Add(this.checkBox_filterTextures);
            this.groupBox_3dView.Controls.Add(this.textBox_cameraFOV);
            this.groupBox_3dView.Controls.Add(this.label_cameraFOV);
            this.groupBox_3dView.Controls.Add(this.label_maxRenderDistance);
            this.groupBox_3dView.Controls.Add(this.trackBar_renderDistance);
            this.groupBox_3dView.Controls.Add(this.label_renderDistance);
            this.groupBox_3dView.Location = new System.Drawing.Point(7, 136);
            this.groupBox_3dView.Name = "groupBox_3dView";
            this.groupBox_3dView.Size = new System.Drawing.Size(429, 108);
            this.groupBox_3dView.TabIndex = 1;
            this.groupBox_3dView.TabStop = false;
            this.groupBox_3dView.Text = "3D View";
            // 
            // checkBox_filterTextures
            // 
            this.checkBox_filterTextures.AutoSize = true;
            this.checkBox_filterTextures.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox_filterTextures.Location = new System.Drawing.Point(9, 56);
            this.checkBox_filterTextures.Name = "checkBox_filterTextures";
            this.checkBox_filterTextures.Size = new System.Drawing.Size(92, 17);
            this.checkBox_filterTextures.TabIndex = 11;
            this.checkBox_filterTextures.Text = "Filter Textures";
            this.checkBox_filterTextures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_filterTextures.UseVisualStyleBackColor = true;
            // 
            // textBox_cameraFOV
            // 
            this.textBox_cameraFOV.Location = new System.Drawing.Point(301, 54);
            this.textBox_cameraFOV.Name = "textBox_cameraFOV";
            this.textBox_cameraFOV.Size = new System.Drawing.Size(100, 20);
            this.textBox_cameraFOV.TabIndex = 10;
            // 
            // label_cameraFOV
            // 
            this.label_cameraFOV.AutoSize = true;
            this.label_cameraFOV.Location = new System.Drawing.Point(183, 57);
            this.label_cameraFOV.Name = "label_cameraFOV";
            this.label_cameraFOV.Size = new System.Drawing.Size(112, 13);
            this.label_cameraFOV.TabIndex = 9;
            this.label_cameraFOV.Text = "Camera FOV (30-100):";
            // 
            // label_maxRenderDistance
            // 
            this.label_maxRenderDistance.AutoSize = true;
            this.label_maxRenderDistance.Location = new System.Drawing.Point(376, 22);
            this.label_maxRenderDistance.Name = "label_maxRenderDistance";
            this.label_maxRenderDistance.Size = new System.Drawing.Size(31, 13);
            this.label_maxRenderDistance.TabIndex = 8;
            this.label_maxRenderDistance.Text = "2000";
            // 
            // trackBar_renderDistance
            // 
            this.trackBar_renderDistance.BackColor = System.Drawing.Color.White;
            this.trackBar_renderDistance.Location = new System.Drawing.Point(102, 22);
            this.trackBar_renderDistance.Maximum = 2000;
            this.trackBar_renderDistance.Minimum = 500;
            this.trackBar_renderDistance.Name = "trackBar_renderDistance";
            this.trackBar_renderDistance.Size = new System.Drawing.Size(278, 45);
            this.trackBar_renderDistance.TabIndex = 6;
            this.trackBar_renderDistance.TickFrequency = 10;
            this.trackBar_renderDistance.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_renderDistance.Value = 500;
            // 
            // label_renderDistance
            // 
            this.label_renderDistance.AutoSize = true;
            this.label_renderDistance.Location = new System.Drawing.Point(6, 22);
            this.label_renderDistance.Name = "label_renderDistance";
            this.label_renderDistance.Size = new System.Drawing.Size(90, 13);
            this.label_renderDistance.TabIndex = 1;
            this.label_renderDistance.Text = "Render Distance:";
            // 
            // groupBox_2dView
            // 
            this.groupBox_2dView.Controls.Add(this.label_MaxIntensivity);
            this.groupBox_2dView.Controls.Add(this.label_SmallIntesivity);
            this.groupBox_2dView.Controls.Add(this.trackBar_intensity);
            this.groupBox_2dView.Controls.Add(this.label_intensity);
            this.groupBox_2dView.Controls.Add(this.comboBox_sizeGrid);
            this.groupBox_2dView.Controls.Add(this.label_sizeGrid);
            this.groupBox_2dView.Location = new System.Drawing.Point(6, 27);
            this.groupBox_2dView.Name = "groupBox_2dView";
            this.groupBox_2dView.Size = new System.Drawing.Size(430, 81);
            this.groupBox_2dView.TabIndex = 0;
            this.groupBox_2dView.TabStop = false;
            this.groupBox_2dView.Text = "2D View";
            // 
            // label_MaxIntensivity
            // 
            this.label_MaxIntensivity.AutoSize = true;
            this.label_MaxIntensivity.Location = new System.Drawing.Point(377, 28);
            this.label_MaxIntensivity.Name = "label_MaxIntensivity";
            this.label_MaxIntensivity.Size = new System.Drawing.Size(25, 13);
            this.label_MaxIntensivity.TabIndex = 5;
            this.label_MaxIntensivity.Text = "100";
            // 
            // label_SmallIntesivity
            // 
            this.label_SmallIntesivity.AutoSize = true;
            this.label_SmallIntesivity.Location = new System.Drawing.Point(229, 28);
            this.label_SmallIntesivity.Name = "label_SmallIntesivity";
            this.label_SmallIntesivity.Size = new System.Drawing.Size(13, 13);
            this.label_SmallIntesivity.TabIndex = 4;
            this.label_SmallIntesivity.Text = "0";
            // 
            // trackBar_intensity
            // 
            this.trackBar_intensity.BackColor = System.Drawing.Color.White;
            this.trackBar_intensity.Location = new System.Drawing.Point(240, 25);
            this.trackBar_intensity.Maximum = 100;
            this.trackBar_intensity.Name = "trackBar_intensity";
            this.trackBar_intensity.Size = new System.Drawing.Size(141, 45);
            this.trackBar_intensity.TabIndex = 2;
            this.trackBar_intensity.TickFrequency = 10;
            this.trackBar_intensity.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label_intensity
            // 
            this.label_intensity.AutoSize = true;
            this.label_intensity.Location = new System.Drawing.Point(174, 28);
            this.label_intensity.Name = "label_intensity";
            this.label_intensity.Size = new System.Drawing.Size(49, 13);
            this.label_intensity.TabIndex = 3;
            this.label_intensity.Text = "Intensity:";
            // 
            // comboBox_sizeGrid
            // 
            this.comboBox_sizeGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sizeGrid.FormattingEnabled = true;
            this.comboBox_sizeGrid.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256"});
            this.comboBox_sizeGrid.Location = new System.Drawing.Point(65, 25);
            this.comboBox_sizeGrid.Name = "comboBox_sizeGrid";
            this.comboBox_sizeGrid.Size = new System.Drawing.Size(98, 21);
            this.comboBox_sizeGrid.TabIndex = 1;
            // 
            // label_sizeGrid
            // 
            this.label_sizeGrid.AutoSize = true;
            this.label_sizeGrid.Location = new System.Drawing.Point(7, 28);
            this.label_sizeGrid.Name = "label_sizeGrid";
            this.label_sizeGrid.Size = new System.Drawing.Size(52, 13);
            this.label_sizeGrid.TabIndex = 0;
            this.label_sizeGrid.Text = "Size Grid:";
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(383, 399);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 434);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_general.ResumeLayout(false);
            this.tabPage_general.PerformLayout();
            this.tabPage_views.ResumeLayout(false);
            this.groupBox_3dView.ResumeLayout(false);
            this.groupBox_3dView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_renderDistance)).EndInit();
            this.groupBox_2dView.ResumeLayout(false);
            this.groupBox_2dView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_intensity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_general;
        private System.Windows.Forms.TabPage tabPage_views;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.ListBox listBox_gameDataFiles;
        private System.Windows.Forms.Label label_gameDataFiles;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ComboBox comboBox_configuration;
        private System.Windows.Forms.Label label_configuration;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.TextBox textBox_gameExecutable;
        private System.Windows.Forms.Label label_gameExecutableDirectory;
        private System.Windows.Forms.Button button_exportMapDirectory;
        private System.Windows.Forms.TextBox textBox_exportMapDirectory;
        private System.Windows.Forms.Label label_exportMapDirectory;
        private System.Windows.Forms.Button button_browseSrcMapDirectory;
        private System.Windows.Forms.TextBox textBox_srcMapDirectory;
        private System.Windows.Forms.Label label_srcMapDirectory;
        private System.Windows.Forms.Button button_browseTextureDirectory;
        private System.Windows.Forms.TextBox textBox_texturesDirectory;
        private System.Windows.Forms.Label label_texturesDirectory;
        private System.Windows.Forms.GroupBox groupBox_3dView;
        private System.Windows.Forms.GroupBox groupBox_2dView;
        private System.Windows.Forms.Label label_MaxIntensivity;
        private System.Windows.Forms.Label label_SmallIntesivity;
        private System.Windows.Forms.Label label_intensity;
        private System.Windows.Forms.TrackBar trackBar_intensity;
        private System.Windows.Forms.ComboBox comboBox_sizeGrid;
        private System.Windows.Forms.Label label_sizeGrid;
        private System.Windows.Forms.Label label_renderDistance;
        private System.Windows.Forms.CheckBox checkBox_filterTextures;
        private System.Windows.Forms.TextBox textBox_cameraFOV;
        private System.Windows.Forms.Label label_cameraFOV;
        private System.Windows.Forms.Label label_maxRenderDistance;
        private System.Windows.Forms.TrackBar trackBar_renderDistance;
        private System.Windows.Forms.Button button_editConfiguration;
    }
}