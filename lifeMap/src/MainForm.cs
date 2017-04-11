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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            view1.InitializeContexts();
            view2.InitializeContexts();
            view3.InitializeContexts();
            view4.InitializeContexts();
        }

        private void MainForm_Load( object sender, EventArgs e )
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode( Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH );

            Gl.glMatrixMode( Gl.GL_PROJECTION );
            Gl.glLoadIdentity();
            Gl.glOrtho( -view1.Width, view1.Width, -view1.Height, view1.Height, -view1.Width, view1.Width );
            Gl.glMatrixMode( Gl.GL_MODELVIEW );
            Gl.glLoadIdentity();

            Gl.glEnable( Gl.GL_DEPTH_TEST );
        }

        // ///////////////
        //VIEW PORT
        // ///////////////

        private void view1_Paint( object sender, PaintEventArgs e )
        {
            view1.MakeCurrent();

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );
            Gl.glOrtho( -view1.Width, view1.Width, -view1.Height, view1.Height, -view1.Width, view1.Width );
            Gl.glBegin( Gl.GL_LINES );
            Gl.glColor3f( 0, 1, 0 );

            for ( int i = -1; i < view1.Width; i++ )
            {
                Gl.glVertex2f( i*32, 0 );
                Gl.glVertex2f( i * 32, view1.Height );
               
            }
            Gl.glEnd();
        }

        private void view2_Paint( object sender, PaintEventArgs e )
        {
            view2.MakeCurrent();

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );
        }

        private void view3_Paint( object sender, PaintEventArgs e )
        {
            view3.MakeCurrent();

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );
        }

        private void view4_Paint( object sender, PaintEventArgs e )
        {
            view4.MakeCurrent();

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT );
        }

        // ///////////////
        //MENU BAR
        // ///////////////

        private void toolStripMenuItem10_Click( object sender, EventArgs e )
        {
            About about = new About();
            about.ShowDialog();
        }

        private void toolStripMenuItem8_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }

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

            panel_entitytool.Enabled = true;
            panel_textureView.Enabled = true;
        }

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

            panel_entitytool.Enabled = false;
            panel_textureView.Enabled = false;
        }
    }
}
