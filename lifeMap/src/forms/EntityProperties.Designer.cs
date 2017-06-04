namespace lifeMap.src.forms
{
    partial class EntityProperties
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_ok = new System.Windows.Forms.Button();
            this.TableProperties = new System.Windows.Forms.DataGridView();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_entityClass = new System.Windows.Forms.Label();
            this.label_entityName = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(276, 254);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // TableProperties
            // 
            this.TableProperties.AllowUserToAddRows = false;
            this.TableProperties.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableProperties.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TableProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableProperties.BackgroundColor = System.Drawing.Color.White;
            this.TableProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TableProperties.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.TableProperties.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.TableProperties.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableProperties.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TableProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyName,
            this.Value});
            this.TableProperties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.TableProperties.GridColor = System.Drawing.Color.White;
            this.TableProperties.Location = new System.Drawing.Point(15, 33);
            this.TableProperties.MultiSelect = false;
            this.TableProperties.Name = "TableProperties";
            this.TableProperties.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.TableProperties.RowHeadersVisible = false;
            this.TableProperties.RowHeadersWidth = 5;
            this.TableProperties.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TableProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TableProperties.ShowCellErrors = false;
            this.TableProperties.ShowCellToolTips = false;
            this.TableProperties.Size = new System.Drawing.Size(417, 216);
            this.TableProperties.TabIndex = 2;
            this.TableProperties.SelectionChanged += new System.EventHandler(this.TableProperties_SelectionChanged);
            // 
            // PropertyName
            // 
            this.PropertyName.DataPropertyName = "(нет)";
            this.PropertyName.HeaderText = "Property Name";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.ReadOnly = true;
            this.PropertyName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PropertyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyName.Width = 150;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label_entityClass
            // 
            this.label_entityClass.AutoSize = true;
            this.label_entityClass.Location = new System.Drawing.Point(12, 10);
            this.label_entityClass.Name = "label_entityClass";
            this.label_entityClass.Size = new System.Drawing.Size(64, 13);
            this.label_entityClass.TabIndex = 4;
            this.label_entityClass.Text = "Entity Class:";
            // 
            // label_entityName
            // 
            this.label_entityName.AutoSize = true;
            this.label_entityName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_entityName.Location = new System.Drawing.Point(82, 10);
            this.label_entityName.Name = "label_entityName";
            this.label_entityName.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label_entityName.Size = new System.Drawing.Size(46, 15);
            this.label_entityName.TabIndex = 5;
            this.label_entityName.Text = "NONE";
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(357, 254);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // EntityProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 289);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.label_entityName);
            this.Controls.Add(this.label_entityClass);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.TableProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntityProperties";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entity Properties";
            ((System.ComponentModel.ISupportInitialize)(this.TableProperties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.DataGridView TableProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label label_entityClass;
        private System.Windows.Forms.Label label_entityName;
        private System.Windows.Forms.Button button_cancel;
    }
}