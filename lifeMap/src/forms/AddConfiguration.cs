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
    public partial class AddConfiguration : Form
    {
        //-------------------------------------------------------------------------//

        public AddConfiguration()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------//

        private void button_cancel_Click( object sender, EventArgs e ) // CANCEL
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        //-------------------------------------------------------------------------//

        private void button_ok_Click( object sender, EventArgs e ) // OK
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        //-------------------------------------------------------------------------//

        public string GetNameConfiguration()
        {
            return textBox_enterConfigurationName.Text;
        }

        //-------------------------------------------------------------------------//
    }
}
