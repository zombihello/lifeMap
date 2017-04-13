using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src;

namespace lifeMap
{
    //-------------------------------------------------------------------------//

    public partial class MainForm : Form
    {
        //-------------------------------------------------------------------------//

        public MainForm()
        {
            InitializeComponent();
            
            Viewport1 = new Viewport( view1, Viewport.TypeViewport.Textured_3D );
            Viewport1.bEnabled = false;

            Viewport2 = new Viewport( view2, Viewport.TypeViewport.Top_2D_xy );
            Viewport2.bEnabled = false;

            Viewport3 = new Viewport( view3, Viewport.TypeViewport.Front_2D_yz );
            Viewport3.bEnabled = false;

            Viewport4 = new Viewport( view4, Viewport.TypeViewport.Side_2D_xz );
            Viewport4.bEnabled = false;
        }

        //-------------------------------------------------------------------------//

        private void MainForm_Load( object sender, EventArgs e )
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode( Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH );

            Gl.glEnable( Gl.GL_TEXTURE_2D );
            Gl.glEnable( Gl.GL_DEPTH_TEST );

            Gl.glDepthMask( Gl.GL_TRUE );
            Gl.glClearDepth( 1.0f );
        }

        //-------------------------------------------------------------------------//

        private void view1_Paint( object sender, PaintEventArgs e )
        {
           Viewport1.UpdateViewport();
        }

        //-------------------------------------------------------------------------//

        private void view2_Paint( object sender, PaintEventArgs e )
        {
            Viewport2.UpdateViewport();
        }

        //-------------------------------------------------------------------------//

        private void view3_Paint( object sender, PaintEventArgs e )
        {
            Viewport3.UpdateViewport();
        }

        //-------------------------------------------------------------------------//

        private void view4_Paint( object sender, PaintEventArgs e )
        {
            Viewport4.UpdateViewport();        
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem10_Click( object sender, EventArgs e )
        {
            About about = new About();
            about.ShowDialog();
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem8_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem2_Click( object sender, EventArgs e )
        {
            menuBar_File.DropDownItems[3].Enabled = true; // Save Map
            menuBar_File.DropDownItems[4].Enabled = true; // Save as...
            menuBar_File.DropDownItems[6].Enabled = true; // Export
            menuBar_File.DropDownItems[8].Enabled = true; // Close Map

            button_cursor.Enabled = true;
            button_camera.Enabled = true;
            button_entitytool.Enabled = true;
            button_boxtool.Enabled = true;

            Viewport1.bEnabled = true;
            Viewport2.bEnabled = true;
            Viewport3.bEnabled = true;
            Viewport4.bEnabled = true;
            
            panel_entitytool.Enabled = true;
            panel_textureView.Enabled = true;

            Refresh();
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem7_Click( object sender, EventArgs e )
        {
            menuBar_File.DropDownItems[3].Enabled = false; // Save Map
            menuBar_File.DropDownItems[4].Enabled = false; // Save as...
            menuBar_File.DropDownItems[6].Enabled = false; // Export
            menuBar_File.DropDownItems[8].Enabled = false; // Close Map

            button_cursor.Enabled = false;
            button_camera.Enabled = false;
            button_entitytool.Enabled = false;
            button_boxtool.Enabled = false;

            Viewport1.bEnabled = false;       
            Viewport2.bEnabled = false;
            Viewport3.bEnabled = false;
            Viewport4.bEnabled = false;

            panel_entitytool.Enabled = false;
            panel_textureView.Enabled = false;
           
            Refresh();
        }

        //-------------------------------------------------------------------------//

        private Viewport Viewport1;
        private Viewport Viewport2;
        private Viewport Viewport3;
        private Viewport Viewport4;

    }

    //-------------------------------------------------------------------------//
}
