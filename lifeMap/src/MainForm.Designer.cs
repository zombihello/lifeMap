namespace lifeMap
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.view1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.view2 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.view3 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.view4 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_textureView = new System.Windows.Forms.ComboBox();
            this.label_texturePreview = new System.Windows.Forms.Label();
            this.button_texturePreview = new System.Windows.Forms.Button();
            this.panel_textureView = new System.Windows.Forms.Panel();
            this.panel_entitytool = new System.Windows.Forms.Panel();
            this.label_entitytool_categories = new System.Windows.Forms.Label();
            this.comboBox_CategEntity = new System.Windows.Forms.ComboBox();
            this.label_entitytool_objects = new System.Windows.Forms.Label();
            this.comboBox_ObjEntity = new System.Windows.Forms.ComboBox();
            this.button_createPrefab = new System.Windows.Forms.Button();
            this.menuBar = new System.Windows.Forms.ToolStrip();
            this.menuBar_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.image_previewTexture = new System.Windows.Forms.PictureBox();
            this.button_boxtool = new System.Windows.Forms.Button();
            this.button_entitytool = new System.Windows.Forms.Button();
            this.button_camera = new System.Windows.Forms.Button();
            this.button_cursor = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_textureView.SuspendLayout();
            this.panel_entitytool.SuspendLayout();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_previewTexture)).BeginInit();
            this.SuspendLayout();
            // 
            // view1
            // 
            this.view1.AccumBits = ((byte)(0));
            this.view1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view1.AutoCheckErrors = false;
            this.view1.AutoFinish = false;
            this.view1.AutoMakeCurrent = true;
            this.view1.AutoSwapBuffers = true;
            this.view1.BackColor = System.Drawing.Color.Black;
            this.view1.ColorBits = ((byte)(32));
            this.view1.DepthBits = ((byte)(16));
            this.view1.Location = new System.Drawing.Point(6, 6);
            this.view1.Name = "view1";
            this.view1.Size = new System.Drawing.Size(358, 279);
            this.view1.StencilBits = ((byte)(0));
            this.view1.TabIndex = 0;
            this.view1.Paint += new System.Windows.Forms.PaintEventHandler(this.view1_Paint);
            // 
            // view2
            // 
            this.view2.AccumBits = ((byte)(0));
            this.view2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view2.AutoCheckErrors = false;
            this.view2.AutoFinish = false;
            this.view2.AutoMakeCurrent = true;
            this.view2.AutoSwapBuffers = true;
            this.view2.BackColor = System.Drawing.Color.Black;
            this.view2.ColorBits = ((byte)(32));
            this.view2.DepthBits = ((byte)(16));
            this.view2.Location = new System.Drawing.Point(373, 294);
            this.view2.Name = "view2";
            this.view2.Size = new System.Drawing.Size(345, 280);
            this.view2.StencilBits = ((byte)(0));
            this.view2.TabIndex = 1;
            this.view2.Paint += new System.Windows.Forms.PaintEventHandler(this.view2_Paint);
            // 
            // view3
            // 
            this.view3.AccumBits = ((byte)(0));
            this.view3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view3.AutoCheckErrors = false;
            this.view3.AutoFinish = false;
            this.view3.AutoMakeCurrent = true;
            this.view3.AutoSwapBuffers = true;
            this.view3.BackColor = System.Drawing.Color.Black;
            this.view3.ColorBits = ((byte)(32));
            this.view3.DepthBits = ((byte)(16));
            this.view3.Location = new System.Drawing.Point(373, 6);
            this.view3.Name = "view3";
            this.view3.Size = new System.Drawing.Size(345, 279);
            this.view3.StencilBits = ((byte)(0));
            this.view3.TabIndex = 2;
            this.view3.Paint += new System.Windows.Forms.PaintEventHandler(this.view3_Paint);
            // 
            // view4
            // 
            this.view4.AccumBits = ((byte)(0));
            this.view4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view4.AutoCheckErrors = false;
            this.view4.AutoFinish = false;
            this.view4.AutoMakeCurrent = true;
            this.view4.AutoSwapBuffers = true;
            this.view4.BackColor = System.Drawing.Color.Black;
            this.view4.ColorBits = ((byte)(32));
            this.view4.DepthBits = ((byte)(16));
            this.view4.Location = new System.Drawing.Point(6, 294);
            this.view4.Name = "view4";
            this.view4.Size = new System.Drawing.Size(358, 280);
            this.view4.StencilBits = ((byte)(0));
            this.view4.TabIndex = 3;
            this.view4.Paint += new System.Windows.Forms.PaintEventHandler(this.view4_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.0288F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.9712F));
            this.tableLayoutPanel1.Controls.Add(this.view1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.view4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.view3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.view2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(51, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 580);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // comboBox_textureView
            // 
            this.comboBox_textureView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_textureView.FormattingEnabled = true;
            this.comboBox_textureView.Location = new System.Drawing.Point(3, 21);
            this.comboBox_textureView.Name = "comboBox_textureView";
            this.comboBox_textureView.Size = new System.Drawing.Size(121, 21);
            this.comboBox_textureView.TabIndex = 11;
            // 
            // label_texturePreview
            // 
            this.label_texturePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_texturePreview.AutoSize = true;
            this.label_texturePreview.Location = new System.Drawing.Point(3, 5);
            this.label_texturePreview.Name = "label_texturePreview";
            this.label_texturePreview.Size = new System.Drawing.Size(80, 13);
            this.label_texturePreview.TabIndex = 12;
            this.label_texturePreview.Text = "Current Texture";
            // 
            // button_texturePreview
            // 
            this.button_texturePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_texturePreview.Location = new System.Drawing.Point(31, 157);
            this.button_texturePreview.Name = "button_texturePreview";
            this.button_texturePreview.Size = new System.Drawing.Size(75, 23);
            this.button_texturePreview.TabIndex = 13;
            this.button_texturePreview.Text = "Browse..";
            this.button_texturePreview.UseVisualStyleBackColor = true;
            // 
            // panel_textureView
            // 
            this.panel_textureView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_textureView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_textureView.Controls.Add(this.image_previewTexture);
            this.panel_textureView.Controls.Add(this.button_texturePreview);
            this.panel_textureView.Controls.Add(this.comboBox_textureView);
            this.panel_textureView.Controls.Add(this.label_texturePreview);
            this.panel_textureView.Enabled = false;
            this.panel_textureView.Location = new System.Drawing.Point(781, 27);
            this.panel_textureView.Name = "panel_textureView";
            this.panel_textureView.Size = new System.Drawing.Size(130, 195);
            this.panel_textureView.TabIndex = 14;
            // 
            // panel_entitytool
            // 
            this.panel_entitytool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_entitytool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_entitytool.Controls.Add(this.button_createPrefab);
            this.panel_entitytool.Controls.Add(this.comboBox_ObjEntity);
            this.panel_entitytool.Controls.Add(this.label_entitytool_objects);
            this.panel_entitytool.Controls.Add(this.comboBox_CategEntity);
            this.panel_entitytool.Controls.Add(this.label_entitytool_categories);
            this.panel_entitytool.Enabled = false;
            this.panel_entitytool.Location = new System.Drawing.Point(781, 219);
            this.panel_entitytool.Name = "panel_entitytool";
            this.panel_entitytool.Size = new System.Drawing.Size(130, 123);
            this.panel_entitytool.TabIndex = 15;
            // 
            // label_entitytool_categories
            // 
            this.label_entitytool_categories.AutoSize = true;
            this.label_entitytool_categories.Location = new System.Drawing.Point(4, 4);
            this.label_entitytool_categories.Name = "label_entitytool_categories";
            this.label_entitytool_categories.Size = new System.Drawing.Size(60, 13);
            this.label_entitytool_categories.TabIndex = 0;
            this.label_entitytool_categories.Text = "Categories:";
            // 
            // comboBox_CategEntity
            // 
            this.comboBox_CategEntity.FormattingEnabled = true;
            this.comboBox_CategEntity.Location = new System.Drawing.Point(3, 20);
            this.comboBox_CategEntity.Name = "comboBox_CategEntity";
            this.comboBox_CategEntity.Size = new System.Drawing.Size(117, 21);
            this.comboBox_CategEntity.TabIndex = 1;
            // 
            // label_entitytool_objects
            // 
            this.label_entitytool_objects.AutoSize = true;
            this.label_entitytool_objects.Location = new System.Drawing.Point(3, 44);
            this.label_entitytool_objects.Name = "label_entitytool_objects";
            this.label_entitytool_objects.Size = new System.Drawing.Size(46, 13);
            this.label_entitytool_objects.TabIndex = 2;
            this.label_entitytool_objects.Text = "Objects:";
            // 
            // comboBox_ObjEntity
            // 
            this.comboBox_ObjEntity.FormattingEnabled = true;
            this.comboBox_ObjEntity.Location = new System.Drawing.Point(4, 61);
            this.comboBox_ObjEntity.Name = "comboBox_ObjEntity";
            this.comboBox_ObjEntity.Size = new System.Drawing.Size(116, 21);
            this.comboBox_ObjEntity.TabIndex = 3;
            // 
            // button_createPrefab
            // 
            this.button_createPrefab.Location = new System.Drawing.Point(21, 88);
            this.button_createPrefab.Name = "button_createPrefab";
            this.button_createPrefab.Size = new System.Drawing.Size(99, 23);
            this.button_createPrefab.TabIndex = 4;
            this.button_createPrefab.Text = "Create Prefab";
            this.button_createPrefab.UseVisualStyleBackColor = true;
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBar_File,
            this.menuBar_Help});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(914, 25);
            this.menuBar.TabIndex = 16;
            this.menuBar.Text = "menuBar";
            // 
            // menuBar_File
            // 
            this.menuBar_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripSeparator4,
            this.toolStripMenuItem6,
            this.toolStripSeparator5,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.menuBar_File.Name = "menuBar_File";
            this.menuBar_File.Size = new System.Drawing.Size(37, 25);
            this.menuBar_File.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem2.Text = "&New Map";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem3.Text = "&Open Map";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem4.Text = "&Save Map";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem5.Text = "Save As..";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Enabled = false;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.toolStripMenuItem6.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem6.Text = "&Export";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(170, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Enabled = false;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem7.Text = "Close Map";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem8.Text = "Exit";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // menuBar_Help
            // 
            this.menuBar_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10});
            this.menuBar_Help.Name = "menuBar_Help";
            this.menuBar_Help.Size = new System.Drawing.Size(44, 25);
            this.menuBar_Help.Text = "Help";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem10.Text = "About...";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // image_previewTexture
            // 
            this.image_previewTexture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.image_previewTexture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.image_previewTexture.Location = new System.Drawing.Point(7, 48);
            this.image_previewTexture.Name = "image_previewTexture";
            this.image_previewTexture.Size = new System.Drawing.Size(113, 103);
            this.image_previewTexture.TabIndex = 10;
            this.image_previewTexture.TabStop = false;
            // 
            // button_boxtool
            // 
            this.button_boxtool.Enabled = false;
            this.button_boxtool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_boxtool.Image = global::lifeMap.Properties.Resources.block;
            this.button_boxtool.Location = new System.Drawing.Point(8, 163);
            this.button_boxtool.Name = "button_boxtool";
            this.button_boxtool.Size = new System.Drawing.Size(37, 36);
            this.button_boxtool.TabIndex = 9;
            this.button_boxtool.UseVisualStyleBackColor = true;
            // 
            // button_entitytool
            // 
            this.button_entitytool.Enabled = false;
            this.button_entitytool.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_entitytool.Image = global::lifeMap.Properties.Resources.entity;
            this.button_entitytool.Location = new System.Drawing.Point(8, 119);
            this.button_entitytool.Name = "button_entitytool";
            this.button_entitytool.Size = new System.Drawing.Size(37, 38);
            this.button_entitytool.TabIndex = 8;
            this.button_entitytool.UseVisualStyleBackColor = true;
            // 
            // button_camera
            // 
            this.button_camera.Enabled = false;
            this.button_camera.FlatAppearance.BorderSize = 0;
            this.button_camera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_camera.Image = global::lifeMap.Properties.Resources.camera;
            this.button_camera.Location = new System.Drawing.Point(8, 76);
            this.button_camera.Name = "button_camera";
            this.button_camera.Size = new System.Drawing.Size(37, 37);
            this.button_camera.TabIndex = 7;
            this.button_camera.UseVisualStyleBackColor = true;
            // 
            // button_cursor
            // 
            this.button_cursor.Enabled = false;
            this.button_cursor.FlatAppearance.BorderSize = 0;
            this.button_cursor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_cursor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_cursor.Image = global::lifeMap.Properties.Resources.cursor;
            this.button_cursor.Location = new System.Drawing.Point(8, 33);
            this.button_cursor.Name = "button_cursor";
            this.button_cursor.Size = new System.Drawing.Size(37, 37);
            this.button_cursor.TabIndex = 6;
            this.button_cursor.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 619);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.panel_entitytool);
            this.Controls.Add(this.panel_textureView);
            this.Controls.Add(this.button_boxtool);
            this.Controls.Add(this.button_entitytool);
            this.Controls.Add(this.button_camera);
            this.Controls.Add(this.button_cursor);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "lifeMap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_textureView.ResumeLayout(false);
            this.panel_textureView.PerformLayout();
            this.panel_entitytool.ResumeLayout(false);
            this.panel_entitytool.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_previewTexture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl view1;
        private Tao.Platform.Windows.SimpleOpenGlControl view2;
        private Tao.Platform.Windows.SimpleOpenGlControl view3;
        private Tao.Platform.Windows.SimpleOpenGlControl view4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_cursor;
        private System.Windows.Forms.Button button_camera;
        private System.Windows.Forms.Button button_entitytool;
        private System.Windows.Forms.Button button_boxtool;
        private System.Windows.Forms.PictureBox image_previewTexture;
        private System.Windows.Forms.ComboBox comboBox_textureView;
        private System.Windows.Forms.Label label_texturePreview;
        private System.Windows.Forms.Button button_texturePreview;
        private System.Windows.Forms.Panel panel_textureView;
        private System.Windows.Forms.Panel panel_entitytool;
        private System.Windows.Forms.Label label_entitytool_objects;
        private System.Windows.Forms.ComboBox comboBox_CategEntity;
        private System.Windows.Forms.Label label_entitytool_categories;
        private System.Windows.Forms.ComboBox comboBox_ObjEntity;
        private System.Windows.Forms.Button button_createPrefab;
        private System.Windows.Forms.ToolStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem menuBar_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem menuBar_Help;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
    }
}

