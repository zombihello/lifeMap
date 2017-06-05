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
    public partial class EntityProperties : Form
    {
        //-------------------------------------------------------------------------//

        public EntityProperties( string NameEntity, Dictionary<string, string> Values )
        {
            InitializeComponent();
            label_entityName.Text = NameEntity;
            mValues = Values;

            for ( int i = 0; i < mValues.Keys.Count; i++ )
                TableProperties.Rows.Add( mValues.Keys.ToList()[i],mValues[mValues.Keys.ToList()[i]] );
        }

        //-------------------------------------------------------------------------//

        public Dictionary<string, string> GetValues()
        {
            return mValues;
        }

        //-------------------------------------------------------------------------//

        private void button_ok_Click( object sender, EventArgs e )
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;

            for ( int i = 0; i < TableProperties.Rows.Count; i++ )
                mValues[ TableProperties.Rows[ i ].Cells[ "PropertyName" ].Value.ToString() ] = TableProperties.Rows[ i ].Cells[ "Value" ].Value.ToString();

            Close();          
        }

        //-------------------------------------------------------------------------//
   
        private void button_cancel_Click( object sender, EventArgs e )
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        //-------------------------------------------------------------------------//

        private void TableProperties_SelectionChanged( object sender, EventArgs e )
        {
            TableProperties.ClearSelection();
        }

        //-------------------------------------------------------------------------//

        private Dictionary<string, string> mValues;
    }
}
