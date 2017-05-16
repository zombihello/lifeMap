using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lifeMap.src
{
    public partial class EditConfiguration : Form
    {
        //-------------------------------------------------------------------------//

        public EditConfiguration()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------//

        private void button_add_Click( object sender, EventArgs e ) // ADD
        {
            AddConfiguration addConfiguration = new AddConfiguration();

            if ( addConfiguration.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                listBox_configuration.Items.Add( addConfiguration.GetNameConfiguration() );
        }

        //-------------------------------------------------------------------------//

        private void button_remove_Click( object sender, EventArgs e ) // REMOVE
        {
            if ( listBox_configuration.SelectedIndex > -1 )
                listBox_configuration.Items.RemoveAt( listBox_configuration.SelectedIndex );
        }

        //-------------------------------------------------------------------------//

        private void button_copy_Click( object sender, EventArgs e ) // COPY
        {
            if ( listBox_configuration.SelectedIndex > -1 )
                listBox_configuration.Items.Add( listBox_configuration.Items[listBox_configuration.SelectedIndex] );
        }

        //-------------------------------------------------------------------------//

        private void button_close_Click( object sender, EventArgs e ) // CLOSE
        {
            Close();
        }

        //-------------------------------------------------------------------------//

        public ListBox.ObjectCollection GetListConfigurations()
        {
            return listBox_configuration.Items;
        }

        //-------------------------------------------------------------------------//
    }
}
