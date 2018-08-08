using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lifeMap.src.forms
{
    public partial class RunMap : Form
    {
        //-------------------------------------------------------------------------//

        public RunMap()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------//

        private void button_ok_Click( object sender, EventArgs e ) // OK
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        //-------------------------------------------------------------------------//

        private void button_cancel_Click( object sender, EventArgs e ) // CANCEL
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        //-------------------------------------------------------------------------//

        public bool IsStartGame()
        {
            return checkBox_startGame.Checked;
        }

        //-------------------------------------------------------------------------//

        public bool IsNoShadows()
        {
            return checkBox_noshadows.Checked;
        }

        //-------------------------------------------------------------------------//

        public bool IsNoRadiosity()
        {
            return checkBox_noradiosity.Checked;
        }

        //-------------------------------------------------------------------------//

        public string GetParametesGame()
        {
            return textBox_additionalGamePar.Text;
        }

        //-------------------------------------------------------------------------//
    }
}
