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
    public partial class MapProperties : Form
    {
        //-------------------------------------------------------------------------//

        public MapProperties()
        {
            InitializeComponent();

            TableProperties.Rows.Add( "Name Map", "" );
            TableProperties.Rows.Add( "Description Map", "" );
            TableProperties.Rows.Add( "SkyBox Name", "" );
          
        }

        //-------------------------------------------------------------------------//

        private void button_ok_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        //-------------------------------------------------------------------------//

        public string GetValue( string propertyName )
        {
            for ( int i = 0; i < TableProperties.Rows.Count; i++ )
            {
                if ( TableProperties.Rows[ i ].Cells[ "PropertyName" ].Value.ToString() == propertyName )
                    return TableProperties.Rows[ i ].Cells[ "Value" ].Value.ToString();
            }

            return "";
        }

        //-------------------------------------------------------------------------//

        public void SetValue( string propertyName, string value )
        {
            for ( int i = 0; i < TableProperties.Rows.Count; i++ )
            {
                if ( TableProperties.Rows[ i ].Cells[ "PropertyName" ].Value.ToString() == propertyName )
                    TableProperties.Rows[ i ].Cells[ "Value" ].Value = value;
            }
        }

        //-------------------------------------------------------------------------//
    }
}
