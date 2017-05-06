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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.comboBox_textureView = new System.Windows.Forms.ComboBox();
            this.label_texturePreview = new System.Windows.Forms.Label();
            this.button_texturePreview = new System.Windows.Forms.Button();
            this.panel_textureView = new System.Windows.Forms.Panel();
            this.image_previewTexture = new System.Windows.Forms.PictureBox();
            this.panel_entitytool = new System.Windows.Forms.Panel();
            this.button_createPrefab = new System.Windows.Forms.Button();
            this.comboBox_ObjEntity = new System.Windows.Forms.ComboBox();
            this.label_entitytool_objects = new System.Windows.Forms.Label();
            this.comboBox_CategEntity = new System.Windows.Forms.ComboBox();
            this.label_entitytool_categories = new System.Windows.Forms.Label();
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
            this.button_boxtool = new System.Windows.Forms.Button();
            this.button_entitytool = new System.Windows.Forms.Button();
            this.button_camera = new System.Windows.Forms.Button();
            this.button_cursor = new System.Windows.Forms.Button();
            this.view4 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.view3 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.view1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.table_viewport = new System.Windows.Forms.TableLayoutPanel();
            this.panel_viewport4 = new System.Windows.Forms.Panel();
            this.vScrollBar_viewport4 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar_viewport4 = new System.Windows.Forms.HScrollBar();
            this.label_viewport4 = new System.Windows.Forms.Label();
            this.panel_viewport3 = new System.Windows.Forms.Panel();
            this.vScrollBar_viewport3 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar_viewport3 = new System.Windows.Forms.HScrollBar();
            this.label_viewport3 = new System.Windows.Forms.Label();
            this.panel_viewport2 = new System.Windows.Forms.Panel();
            this.label_viewport2 = new System.Windows.Forms.Label();
            this.vScrollBar__viewport2 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar_viewport2 = new System.Windows.Forms.HScrollBar();
            this.view2 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.panel_viewport1 = new System.Windows.Forms.Panel();
            this.vScrollBar_viewport1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar_viewport1 = new System.Windows.Forms.HScrollBar();
            this.label_viewport1 = new System.Windows.Forms.Label();
            this.menuTypeViewport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dFrontXYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dTopZYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dTexturedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel_textureView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_previewTexture)).BeginInit();
            this.panel_entitytool.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.table_viewport.SuspendLayout();
            this.panel_viewport4.SuspendLayout();
            this.panel_viewport3.SuspendLayout();
            this.panel_viewport2.SuspendLayout();
            this.panel_viewport1.SuspendLayout();
            this.menuTypeViewport.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_textureView
            // 
            this.comboBox_textureView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_textureView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_textureView.Location = new System.Drawing.Point(3, 21);
            this.comboBox_textureView.Name = "comboBox_textureView";
            this.comboBox_textureView.Size = new System.Drawing.Size(121, 21);
            this.comboBox_textureView.TabIndex = 11;
            this.comboBox_textureView.SelectionChangeCommitted += new System.EventHandler(this.comboBox_textureView_SelectionChangeCommitted);
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
            this.button_texturePreview.Click += new System.EventHandler(this.button_texturePreview_Click);
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
            // image_previewTexture
            // 
            this.image_previewTexture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.image_previewTexture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.image_previewTexture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.image_previewTexture.InitialImage = null;
            this.image_previewTexture.Location = new System.Drawing.Point(7, 48);
            this.image_previewTexture.Name = "image_previewTexture";
            this.image_previewTexture.Size = new System.Drawing.Size(113, 103);
            this.image_previewTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_previewTexture.TabIndex = 10;
            this.image_previewTexture.TabStop = false;
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
            // button_createPrefab
            // 
            this.button_createPrefab.Location = new System.Drawing.Point(21, 88);
            this.button_createPrefab.Name = "button_createPrefab";
            this.button_createPrefab.Size = new System.Drawing.Size(99, 23);
            this.button_createPrefab.TabIndex = 4;
            this.button_createPrefab.Text = "Create Prefab";
            this.button_createPrefab.UseVisualStyleBackColor = true;
            // 
            // comboBox_ObjEntity
            // 
            this.comboBox_ObjEntity.FormattingEnabled = true;
            this.comboBox_ObjEntity.Location = new System.Drawing.Point(4, 61);
            this.comboBox_ObjEntity.Name = "comboBox_ObjEntity";
            this.comboBox_ObjEntity.Size = new System.Drawing.Size(116, 21);
            this.comboBox_ObjEntity.TabIndex = 3;
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
            // comboBox_CategEntity
            // 
            this.comboBox_CategEntity.FormattingEnabled = true;
            this.comboBox_CategEntity.Location = new System.Drawing.Point(3, 20);
            this.comboBox_CategEntity.Name = "comboBox_CategEntity";
            this.comboBox_CategEntity.Size = new System.Drawing.Size(117, 21);
            this.comboBox_CategEntity.TabIndex = 1;
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
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBar_File,
            this.menuBar_Help,
            this.toolStripSeparator2});
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
            this.toolStripMenuItem10.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem10.Text = "About...";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // button_boxtool
            // 
            this.button_boxtool.Enabled = false;
            this.button_boxtool.FlatAppearance.BorderSize = 0;
            this.button_boxtool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_boxtool.Image = global::lifeMap.Properties.Resources.block;
            this.button_boxtool.Location = new System.Drawing.Point(8, 163);
            this.button_boxtool.Name = "button_boxtool";
            this.button_boxtool.Size = new System.Drawing.Size(37, 36);
            this.button_boxtool.TabIndex = 9;
            this.button_boxtool.UseVisualStyleBackColor = true;
            this.button_boxtool.Click += new System.EventHandler(this.button_boxtool_Click);
            // 
            // button_entitytool
            // 
            this.button_entitytool.Enabled = false;
            this.button_entitytool.FlatAppearance.BorderSize = 0;
            this.button_entitytool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_entitytool.Image = global::lifeMap.Properties.Resources.entity;
            this.button_entitytool.Location = new System.Drawing.Point(8, 119);
            this.button_entitytool.Name = "button_entitytool";
            this.button_entitytool.Size = new System.Drawing.Size(37, 38);
            this.button_entitytool.TabIndex = 8;
            this.button_entitytool.UseVisualStyleBackColor = true;
            this.button_entitytool.Click += new System.EventHandler(this.button_entitytool_Click);
            // 
            // button_camera
            // 
            this.button_camera.Enabled = false;
            this.button_camera.FlatAppearance.BorderSize = 0;
            this.button_camera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_camera.Image = global::lifeMap.Properties.Resources.camera;
            this.button_camera.Location = new System.Drawing.Point(8, 76);
            this.button_camera.Name = "button_camera";
            this.button_camera.Size = new System.Drawing.Size(37, 37);
            this.button_camera.TabIndex = 7;
            this.button_camera.UseVisualStyleBackColor = true;
            this.button_camera.Click += new System.EventHandler(this.button_camera_Click);
            // 
            // button_cursor
            // 
            this.button_cursor.Enabled = false;
            this.button_cursor.FlatAppearance.BorderSize = 0;
            this.button_cursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cursor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_cursor.Image = global::lifeMap.Properties.Resources.cursor;
            this.button_cursor.Location = new System.Drawing.Point(8, 33);
            this.button_cursor.Name = "button_cursor";
            this.button_cursor.Size = new System.Drawing.Size(37, 37);
            this.button_cursor.TabIndex = 6;
            this.button_cursor.UseVisualStyleBackColor = true;
            this.button_cursor.Click += new System.EventHandler(this.button_cursor_Click);
            // 
            // view4
            // 
            this.view4.AccumBits = ((byte)(0));
            this.view4.AutoCheckErrors = false;
            this.view4.AutoFinish = false;
            this.view4.AutoMakeCurrent = true;
            this.view4.AutoSwapBuffers = true;
            this.view4.BackColor = System.Drawing.Color.Black;
            this.view4.ColorBits = ((byte)(32));
            this.view4.DepthBits = ((byte)(24));
            this.view4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view4.Location = new System.Drawing.Point(0, 0);
            this.view4.Name = "view4";
            this.view4.Size = new System.Drawing.Size(352, 280);
            this.view4.StencilBits = ((byte)(0));
            this.view4.TabIndex = 23;
            this.view4.Paint += new System.Windows.Forms.PaintEventHandler(this.view4_Paint);
            this.view4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.view4_KeyDown);
            this.view4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.view4_MouseDoubleClick);
            this.view4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.view4_MouseDown);
            this.view4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.view4_MouseMove);
            this.view4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.view4_MouseUp);
            // 
            // view3
            // 
            this.view3.AccumBits = ((byte)(0));
            this.view3.AutoCheckErrors = false;
            this.view3.AutoFinish = false;
            this.view3.AutoMakeCurrent = true;
            this.view3.AutoSwapBuffers = true;
            this.view3.BackColor = System.Drawing.Color.Black;
            this.view3.ColorBits = ((byte)(32));
            this.view3.DepthBits = ((byte)(24));
            this.view3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view3.Location = new System.Drawing.Point(0, 0);
            this.view3.Name = "view3";
            this.view3.Size = new System.Drawing.Size(352, 280);
            this.view3.StencilBits = ((byte)(0));
            this.view3.TabIndex = 23;
            this.view3.Paint += new System.Windows.Forms.PaintEventHandler(this.view3_Paint);
            this.view3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.view3_KeyDown);
            this.view3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.view3_MouseDoubleClick);
            this.view3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.view3_MouseDown);
            this.view3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.view3_MouseMove);
            this.view3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.view3_MouseUp);
            // 
            // view1
            // 
            this.view1.AccumBits = ((byte)(0));
            this.view1.AutoCheckErrors = false;
            this.view1.AutoFinish = false;
            this.view1.AutoMakeCurrent = true;
            this.view1.AutoSwapBuffers = true;
            this.view1.BackColor = System.Drawing.Color.Black;
            this.view1.ColorBits = ((byte)(32));
            this.view1.DepthBits = ((byte)(24));
            this.view1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view1.Location = new System.Drawing.Point(0, 0);
            this.view1.Name = "view1";
            this.view1.Size = new System.Drawing.Size(352, 279);
            this.view1.StencilBits = ((byte)(0));
            this.view1.TabIndex = 23;
            this.view1.Paint += new System.Windows.Forms.PaintEventHandler(this.view1_Paint);
            this.view1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.view1_KeyDown);
            this.view1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.view1_MouseDoubleClick);
            this.view1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.view1_MouseDown);
            this.view1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.view1_MouseMove);
            this.view1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.view1_MouseUp);
            // 
            // table_viewport
            // 
            this.table_viewport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table_viewport.BackColor = System.Drawing.Color.Transparent;
            this.table_viewport.ColumnCount = 2;
            this.table_viewport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_viewport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_viewport.Controls.Add(this.panel_viewport4, 1, 1);
            this.table_viewport.Controls.Add(this.panel_viewport3, 0, 1);
            this.table_viewport.Controls.Add(this.panel_viewport2, 1, 0);
            this.table_viewport.Controls.Add(this.panel_viewport1, 0, 0);
            this.table_viewport.Location = new System.Drawing.Point(51, 28);
            this.table_viewport.Name = "table_viewport";
            this.table_viewport.RowCount = 2;
            this.table_viewport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_viewport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table_viewport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table_viewport.Size = new System.Drawing.Size(724, 579);
            this.table_viewport.TabIndex = 22;
            // 
            // panel_viewport4
            // 
            this.panel_viewport4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_viewport4.Controls.Add(this.vScrollBar_viewport4);
            this.panel_viewport4.Controls.Add(this.hScrollBar_viewport4);
            this.panel_viewport4.Controls.Add(this.label_viewport4);
            this.panel_viewport4.Controls.Add(this.view4);
            this.panel_viewport4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_viewport4.Location = new System.Drawing.Point(365, 292);
            this.panel_viewport4.Name = "panel_viewport4";
            this.panel_viewport4.Size = new System.Drawing.Size(356, 284);
            this.panel_viewport4.TabIndex = 3;
            // 
            // vScrollBar_viewport4
            // 
            this.vScrollBar_viewport4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar_viewport4.Location = new System.Drawing.Point(336, -5);
            this.vScrollBar_viewport4.Name = "vScrollBar_viewport4";
            this.vScrollBar_viewport4.Size = new System.Drawing.Size(17, 285);
            this.vScrollBar_viewport4.TabIndex = 3;
            this.vScrollBar_viewport4.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_viewport4_Scroll);
            this.vScrollBar_viewport4.ValueChanged += new System.EventHandler(this.vScrollBar_viewport4_ValueChanged);
            // 
            // hScrollBar_viewport4
            // 
            this.hScrollBar_viewport4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar_viewport4.Location = new System.Drawing.Point(0, 263);
            this.hScrollBar_viewport4.Name = "hScrollBar_viewport4";
            this.hScrollBar_viewport4.Size = new System.Drawing.Size(336, 17);
            this.hScrollBar_viewport4.TabIndex = 2;
            this.hScrollBar_viewport4.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_viewport4_Scroll);
            this.hScrollBar_viewport4.ValueChanged += new System.EventHandler(this.hScrollBar_viewport4_ValueChanged);
            // 
            // label_viewport4
            // 
            this.label_viewport4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_viewport4.AutoSize = true;
            this.label_viewport4.BackColor = System.Drawing.Color.Black;
            this.label_viewport4.ForeColor = System.Drawing.Color.White;
            this.label_viewport4.Location = new System.Drawing.Point(-2, 0);
            this.label_viewport4.Name = "label_viewport4";
            this.label_viewport4.Size = new System.Drawing.Size(35, 13);
            this.label_viewport4.TabIndex = 24;
            this.label_viewport4.Text = "label1";
            this.label_viewport4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_viewport4_MouseClick);
            // 
            // panel_viewport3
            // 
            this.panel_viewport3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_viewport3.Controls.Add(this.vScrollBar_viewport3);
            this.panel_viewport3.Controls.Add(this.hScrollBar_viewport3);
            this.panel_viewport3.Controls.Add(this.label_viewport3);
            this.panel_viewport3.Controls.Add(this.view3);
            this.panel_viewport3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_viewport3.Location = new System.Drawing.Point(3, 292);
            this.panel_viewport3.Name = "panel_viewport3";
            this.panel_viewport3.Size = new System.Drawing.Size(356, 284);
            this.panel_viewport3.TabIndex = 2;
            // 
            // vScrollBar_viewport3
            // 
            this.vScrollBar_viewport3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar_viewport3.Location = new System.Drawing.Point(336, -2);
            this.vScrollBar_viewport3.Name = "vScrollBar_viewport3";
            this.vScrollBar_viewport3.Size = new System.Drawing.Size(17, 282);
            this.vScrollBar_viewport3.TabIndex = 3;
            this.vScrollBar_viewport3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_viewport3_Scroll);
            this.vScrollBar_viewport3.ValueChanged += new System.EventHandler(this.vScrollBar_viewport3_ValueChanged);
            // 
            // hScrollBar_viewport3
            // 
            this.hScrollBar_viewport3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar_viewport3.LargeChange = 1;
            this.hScrollBar_viewport3.Location = new System.Drawing.Point(0, 263);
            this.hScrollBar_viewport3.Minimum = -400;
            this.hScrollBar_viewport3.Name = "hScrollBar_viewport3";
            this.hScrollBar_viewport3.Size = new System.Drawing.Size(336, 17);
            this.hScrollBar_viewport3.TabIndex = 2;
            this.hScrollBar_viewport3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_viewport3_Scroll);
            this.hScrollBar_viewport3.ValueChanged += new System.EventHandler(this.hScrollBar_viewport3_ValueChanged);
            // 
            // label_viewport3
            // 
            this.label_viewport3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_viewport3.AutoSize = true;
            this.label_viewport3.BackColor = System.Drawing.Color.Black;
            this.label_viewport3.ForeColor = System.Drawing.Color.White;
            this.label_viewport3.Location = new System.Drawing.Point(-3, 0);
            this.label_viewport3.Name = "label_viewport3";
            this.label_viewport3.Size = new System.Drawing.Size(35, 13);
            this.label_viewport3.TabIndex = 24;
            this.label_viewport3.Text = "label1";
            this.label_viewport3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_viewport3_MouseClick);
            // 
            // panel_viewport2
            // 
            this.panel_viewport2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_viewport2.Controls.Add(this.label_viewport2);
            this.panel_viewport2.Controls.Add(this.vScrollBar__viewport2);
            this.panel_viewport2.Controls.Add(this.hScrollBar_viewport2);
            this.panel_viewport2.Controls.Add(this.view2);
            this.panel_viewport2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_viewport2.Location = new System.Drawing.Point(365, 3);
            this.panel_viewport2.Name = "panel_viewport2";
            this.panel_viewport2.Size = new System.Drawing.Size(356, 283);
            this.panel_viewport2.TabIndex = 1;
            // 
            // label_viewport2
            // 
            this.label_viewport2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_viewport2.AutoSize = true;
            this.label_viewport2.BackColor = System.Drawing.Color.Black;
            this.label_viewport2.ForeColor = System.Drawing.Color.White;
            this.label_viewport2.Location = new System.Drawing.Point(-2, 0);
            this.label_viewport2.Name = "label_viewport2";
            this.label_viewport2.Size = new System.Drawing.Size(35, 13);
            this.label_viewport2.TabIndex = 23;
            this.label_viewport2.Text = "label1";
            this.label_viewport2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_viewport2_MouseClick);
            // 
            // vScrollBar__viewport2
            // 
            this.vScrollBar__viewport2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar__viewport2.Cursor = System.Windows.Forms.Cursors.Default;
            this.vScrollBar__viewport2.Location = new System.Drawing.Point(336, -2);
            this.vScrollBar__viewport2.Name = "vScrollBar__viewport2";
            this.vScrollBar__viewport2.Size = new System.Drawing.Size(17, 281);
            this.vScrollBar__viewport2.TabIndex = 1;
            this.vScrollBar__viewport2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar__viewport2_Scroll);
            this.vScrollBar__viewport2.ValueChanged += new System.EventHandler(this.vScrollBar__viewport2_ValueChanged);
            // 
            // hScrollBar_viewport2
            // 
            this.hScrollBar_viewport2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar_viewport2.LargeChange = 1;
            this.hScrollBar_viewport2.Location = new System.Drawing.Point(0, 262);
            this.hScrollBar_viewport2.Minimum = -100;
            this.hScrollBar_viewport2.Name = "hScrollBar_viewport2";
            this.hScrollBar_viewport2.Size = new System.Drawing.Size(336, 17);
            this.hScrollBar_viewport2.TabIndex = 0;
            this.hScrollBar_viewport2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_viewport2_Scroll);
            this.hScrollBar_viewport2.ValueChanged += new System.EventHandler(this.hScrollBar_viewport2_ValueChanged);
            // 
            // view2
            // 
            this.view2.AccumBits = ((byte)(0));
            this.view2.AutoCheckErrors = false;
            this.view2.AutoFinish = false;
            this.view2.AutoMakeCurrent = true;
            this.view2.AutoSwapBuffers = true;
            this.view2.BackColor = System.Drawing.Color.Black;
            this.view2.ColorBits = ((byte)(32));
            this.view2.DepthBits = ((byte)(24));
            this.view2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view2.Location = new System.Drawing.Point(0, 0);
            this.view2.Name = "view2";
            this.view2.Size = new System.Drawing.Size(352, 279);
            this.view2.StencilBits = ((byte)(0));
            this.view2.TabIndex = 23;
            this.view2.Paint += new System.Windows.Forms.PaintEventHandler(this.view2_Paint);
            this.view2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.view2_KeyDown);
            this.view2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.view2_MouseDoubleClick);
            this.view2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.view2_MouseDown);
            this.view2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.view2_MouseMove);
            this.view2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.view2_MouseUp);
            // 
            // panel_viewport1
            // 
            this.panel_viewport1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_viewport1.Controls.Add(this.vScrollBar_viewport1);
            this.panel_viewport1.Controls.Add(this.hScrollBar_viewport1);
            this.panel_viewport1.Controls.Add(this.label_viewport1);
            this.panel_viewport1.Controls.Add(this.view1);
            this.panel_viewport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_viewport1.Location = new System.Drawing.Point(3, 3);
            this.panel_viewport1.Name = "panel_viewport1";
            this.panel_viewport1.Size = new System.Drawing.Size(356, 283);
            this.panel_viewport1.TabIndex = 0;
            // 
            // vScrollBar_viewport1
            // 
            this.vScrollBar_viewport1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar_viewport1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vScrollBar_viewport1.Location = new System.Drawing.Point(336, -1);
            this.vScrollBar_viewport1.Name = "vScrollBar_viewport1";
            this.vScrollBar_viewport1.Size = new System.Drawing.Size(17, 280);
            this.vScrollBar_viewport1.TabIndex = 26;
            this.vScrollBar_viewport1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_viewport1_Scroll);
            this.vScrollBar_viewport1.ValueChanged += new System.EventHandler(this.vScrollBar_viewport1_ValueChanged);
            // 
            // hScrollBar_viewport1
            // 
            this.hScrollBar_viewport1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar_viewport1.Location = new System.Drawing.Point(0, 263);
            this.hScrollBar_viewport1.Name = "hScrollBar_viewport1";
            this.hScrollBar_viewport1.Size = new System.Drawing.Size(336, 17);
            this.hScrollBar_viewport1.TabIndex = 25;
            this.hScrollBar_viewport1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_viewport1_Scroll);
            this.hScrollBar_viewport1.ValueChanged += new System.EventHandler(this.hScrollBar_viewport1_ValueChanged);
            // 
            // label_viewport1
            // 
            this.label_viewport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_viewport1.AutoSize = true;
            this.label_viewport1.BackColor = System.Drawing.Color.Black;
            this.label_viewport1.ForeColor = System.Drawing.Color.White;
            this.label_viewport1.Location = new System.Drawing.Point(-3, 0);
            this.label_viewport1.Name = "label_viewport1";
            this.label_viewport1.Size = new System.Drawing.Size(35, 13);
            this.label_viewport1.TabIndex = 24;
            this.label_viewport1.Text = "label1";
            this.label_viewport1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label_viewport1_MouseClick);
            // 
            // menuTypeViewport
            // 
            this.menuTypeViewport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dFrontXYToolStripMenuItem,
            this.dSideToolStripMenuItem,
            this.dTopZYToolStripMenuItem,
            this.toolStripSeparator1,
            this.dTexturedToolStripMenuItem});
            this.menuTypeViewport.Name = "menuTypeViewport";
            this.menuTypeViewport.ShowImageMargin = false;
            this.menuTypeViewport.Size = new System.Drawing.Size(125, 98);
            // 
            // dFrontXYToolStripMenuItem
            // 
            this.dFrontXYToolStripMenuItem.Name = "dFrontXYToolStripMenuItem";
            this.dFrontXYToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dFrontXYToolStripMenuItem.Text = "2D Front (Y/Z)";
            this.dFrontXYToolStripMenuItem.Click += new System.EventHandler(this.dFrontXYToolStripMenuItem_Click);
            // 
            // dSideToolStripMenuItem
            // 
            this.dSideToolStripMenuItem.Name = "dSideToolStripMenuItem";
            this.dSideToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dSideToolStripMenuItem.Text = "2D Side (X/Z)";
            this.dSideToolStripMenuItem.Click += new System.EventHandler(this.dSideToolStripMenuItem_Click);
            // 
            // dTopZYToolStripMenuItem
            // 
            this.dTopZYToolStripMenuItem.Name = "dTopZYToolStripMenuItem";
            this.dTopZYToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dTopZYToolStripMenuItem.Text = "2D Top (X/Y)";
            this.dTopZYToolStripMenuItem.Click += new System.EventHandler(this.dTopZYToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // dTexturedToolStripMenuItem
            // 
            this.dTexturedToolStripMenuItem.Name = "dTexturedToolStripMenuItem";
            this.dTexturedToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dTexturedToolStripMenuItem.Text = "3D Textured";
            this.dTexturedToolStripMenuItem.Click += new System.EventHandler(this.dTexturedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 619);
            this.Controls.Add(this.table_viewport);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.panel_entitytool);
            this.Controls.Add(this.panel_textureView);
            this.Controls.Add(this.button_boxtool);
            this.Controls.Add(this.button_entitytool);
            this.Controls.Add(this.button_camera);
            this.Controls.Add(this.button_cursor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "lifeMap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel_textureView.ResumeLayout(false);
            this.panel_textureView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_previewTexture)).EndInit();
            this.panel_entitytool.ResumeLayout(false);
            this.panel_entitytool.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.table_viewport.ResumeLayout(false);
            this.panel_viewport4.ResumeLayout(false);
            this.panel_viewport4.PerformLayout();
            this.panel_viewport3.ResumeLayout(false);
            this.panel_viewport3.PerformLayout();
            this.panel_viewport2.ResumeLayout(false);
            this.panel_viewport2.PerformLayout();
            this.panel_viewport1.ResumeLayout(false);
            this.panel_viewport1.PerformLayout();
            this.menuTypeViewport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private Tao.Platform.Windows.SimpleOpenGlControl view3;
        private Tao.Platform.Windows.SimpleOpenGlControl view1;
        private Tao.Platform.Windows.SimpleOpenGlControl view4;
        private System.Windows.Forms.TableLayoutPanel table_viewport;
        private System.Windows.Forms.Panel panel_viewport4;
        private System.Windows.Forms.Panel panel_viewport3;
        private System.Windows.Forms.Panel panel_viewport2;
        private System.Windows.Forms.Panel panel_viewport1;
        private System.Windows.Forms.HScrollBar hScrollBar_viewport2;
        private System.Windows.Forms.VScrollBar vScrollBar__viewport2;
        private System.Windows.Forms.VScrollBar vScrollBar_viewport4;
        private System.Windows.Forms.HScrollBar hScrollBar_viewport4;
        private System.Windows.Forms.VScrollBar vScrollBar_viewport3;
        private System.Windows.Forms.HScrollBar hScrollBar_viewport3;
        private System.Windows.Forms.Label label_viewport2;
        private System.Windows.Forms.Label label_viewport4;
        private System.Windows.Forms.Label label_viewport3;
        private System.Windows.Forms.Label label_viewport1;
        private System.Windows.Forms.ContextMenuStrip menuTypeViewport;
        private System.Windows.Forms.ToolStripMenuItem dFrontXYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dSideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTopZYToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dTexturedToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScrollBar_viewport1;
        private System.Windows.Forms.HScrollBar hScrollBar_viewport1;
        private Tao.Platform.Windows.SimpleOpenGlControl view2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;        
    }
}

