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
using lifeMap.src.brushes;
using lifeMap.src.system;

namespace lifeMap
{
    //-------------------------------------------------------------------------//

    public partial class MainForm : Form
    {
        //-------------------------------------------------------------------------//

        public MainForm()
        {
            InitializeComponent();

            Viewport1 = new Viewport( view1, Viewport.TypeViewport.Textured_3D, label_viewport1, vScrollBar_viewport1, hScrollBar_viewport1 );
            Viewport1.bEnabled = false;

            Viewport2 = new Viewport( view2, Viewport.TypeViewport.Top_2D_xy, label_viewport2, vScrollBar__viewport2, hScrollBar_viewport2 );
            Viewport2.bEnabled = false;

            Viewport3 = new Viewport( view3, Viewport.TypeViewport.Front_2D_yz, label_viewport3, vScrollBar_viewport3, hScrollBar_viewport3 );
            Viewport3.bEnabled = false;

            Viewport4 = new Viewport( view4, Viewport.TypeViewport.Side_2D_xz, label_viewport4, vScrollBar_viewport4, hScrollBar_viewport4 );
            Viewport4.bEnabled = false;

            view1.MouseWheel += new MouseEventHandler( view1_MouseWheel );
            view2.MouseWheel += new MouseEventHandler( view2_MouseWheel );
            view3.MouseWheel += new MouseEventHandler( view3_MouseWheel );
            view4.MouseWheel += new MouseEventHandler( view4_MouseWheel );

            Scene.SetViewportWorldCamera( view1 );
            Scene.WorldCamera.SetPosition( new Vector3f( 0, 0, -300 ) );
            Viewport1.Camera.SetPosition( new Vector3f( view1.Width / 2, view1.Height / 2, 0 ) );
            Viewport2.Camera.SetPosition( new Vector3f( view2.Width / 2, view2.Height / 2, 0 ) );
            Viewport3.Camera.SetPosition( new Vector3f( view3.Width / 2, view3.Height / 2, 0 ) );
            Viewport4.Camera.SetPosition( new Vector3f( view4.Width / 2, view4.Height / 2, 0 ) );
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



        //-------------------------------------------------------------------------//
        //                             VIEWPORT 1                                  //
        //-------------------------------------------------------------------------//

        private void view1_Paint( object sender, PaintEventArgs e )
        {
            Viewport1.UpdateViewport();
        }

        //-------------------------------------------------------------------------//

        private void view1_Click( object sender, EventArgs e )
        {
            if ( Viewport1.bEnabled )
            {
                if ( !Mouse.IsClick )
                    Mouse.SetClick( Viewport1.type );
                else
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.CursorTool:
                            if ( Scene.GetBrushSelect() != null )
                                Scene.ClearBrushSelect();
                            break;

                        case Program.SelectTool.CameraTool: 
                            break;

                        case Program.SelectTool.EntityTool: 
                            break;

                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrush();                         
                            break;
                    }

                    Refresh();
                    Mouse.RemoveClick();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseMove( object sender, MouseEventArgs e )
        {
            if ( Viewport1.bEnabled )
            {
                Mouse.UpdatePosition( e.X, Math.Abs( e.Y - view1.Height ), Viewport.fSize );

                if ( Mouse.IsClick )
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.BoxTool:
                        case Program.SelectTool.CursorTool:
                            Scene.CreateBrushSelect( Viewport1.type, Viewport1.Camera );  
                            break;

                        case Program.SelectTool.CameraTool: break;

                        case Program.SelectTool.EntityTool: break;
                    }

                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void label_viewport1_MouseClick( object sender, MouseEventArgs e )
        {
            if ( Viewport1.bEnabled )
            {
                TmpViewport = Viewport1;
                menuTypeViewport.Show( Cursor.Position.X, Cursor.Position.Y );
            }
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseWheel( object sender, MouseEventArgs e )
        {
            if ( Viewport1.bEnabled && Viewport1.type != Viewport.TypeViewport.Textured_3D )
            {
                if ( e.Delta > 0 )
                {
                    if ( vScrollBar_viewport1.Value < vScrollBar_viewport1.Maximum )
                        vScrollBar_viewport1.Value += vScrollBar_viewport1.SmallChange;

                    if ( hScrollBar_viewport1.Value < hScrollBar_viewport1.Maximum )
                        hScrollBar_viewport1.Value += hScrollBar_viewport1.SmallChange;
                }
                else
                {
                    if ( hScrollBar_viewport1.Value > hScrollBar_viewport1.Minimum )
                        hScrollBar_viewport1.Value -= hScrollBar_viewport1.SmallChange;

                    if ( vScrollBar_viewport1.Value > vScrollBar_viewport1.Minimum )
                        vScrollBar_viewport1.Value -= vScrollBar_viewport1.SmallChange;
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport1_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( -( e.NewValue - e.OldValue ), 0, 0 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport1_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( 0, e.NewValue - e.OldValue, 0 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport1_ValueChanged( object sender, EventArgs e )
        {
            Viewport1.Camera.Move( FactorMoveCamera );
            view1.Refresh();
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport1_ValueChanged( object sender, EventArgs e )
        {
            Viewport1.Camera.Move( FactorMoveCamera );
            view1.Refresh();
        }

        //-------------------------------------------------------------------------//

        private void view1_KeyDown( object sender, KeyEventArgs e )
        {
            if ( Viewport1.bEnabled && Viewport1.type == Viewport.TypeViewport.Textured_3D )
            {
                if ( e.KeyCode == Keys.W )
                {
                    Scene.WorldCamera.Move( new Vector3f( 0, 0, 1 ) ); // TODO: Сделать движение в сторону мыши (вверх/ввниз особено) 
                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------------//

        //-------------------------------------------------------------------------//
        //                             VIEWPORT 2                                  //
        //-------------------------------------------------------------------------//

        private void view2_Paint( object sender, PaintEventArgs e ) // UPDATE VIEWPORT
        {
            Viewport2.UpdateViewport();
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseMove( object sender, MouseEventArgs e )
        {
            if ( Viewport2.bEnabled )
            {
                Mouse.UpdatePosition( e.X, Math.Abs( e.Y - view2.Height ), Viewport.fSize );

                if ( Mouse.IsClick )
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.BoxTool:
                        case Program.SelectTool.CursorTool:
                            Scene.CreateBrushSelect( Viewport2.type, Viewport2.Camera );    
                            break;

                        case Program.SelectTool.CameraTool: break;

                        case Program.SelectTool.EntityTool: break;
                    }

                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void view2_Click( object sender, EventArgs e )
        {
            if ( Viewport2.bEnabled )
            {
                if ( !Mouse.IsClick )
                    Mouse.SetClick( Viewport2.type );
                else
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.CursorTool:
                            if ( Scene.GetBrushSelect() != null )
                                Scene.ClearBrushSelect();
                            break;

                        case Program.SelectTool.CameraTool: break;

                        case Program.SelectTool.EntityTool: break;

                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrush();    
                            break;
                    }

                    Refresh();
                    Mouse.RemoveClick();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void label_viewport2_MouseClick( object sender, MouseEventArgs e )
        {
            if ( Viewport2.bEnabled )
            {
                TmpViewport = Viewport2;
                menuTypeViewport.Show( Cursor.Position.X, Cursor.Position.Y );
            }
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseWheel( object sender, MouseEventArgs e )
        {
            if ( Viewport2.bEnabled && Viewport2.type != Viewport.TypeViewport.Textured_3D )
            {
                if ( e.Delta > 0 )
                {
                    if ( vScrollBar__viewport2.Value < vScrollBar__viewport2.Maximum )
                        vScrollBar__viewport2.Value += vScrollBar__viewport2.SmallChange;

                    if ( hScrollBar_viewport2.Value < hScrollBar_viewport2.Maximum )
                        hScrollBar_viewport2.Value += hScrollBar_viewport2.SmallChange;
                }
                else
                {
                    if ( hScrollBar_viewport2.Value > hScrollBar_viewport2.Minimum )
                        hScrollBar_viewport2.Value -= hScrollBar_viewport2.SmallChange;

                    if ( vScrollBar__viewport2.Value > vScrollBar__viewport2.Minimum )
                        vScrollBar__viewport2.Value -= vScrollBar__viewport2.SmallChange;
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport2_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( -( e.NewValue - e.OldValue ), 0, 0 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar__viewport2_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( 0, e.NewValue - e.OldValue, 0 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport2_ValueChanged( object sender, EventArgs e )
        {
            Viewport2.Camera.Move( FactorMoveCamera );
            view2.Refresh();
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar__viewport2_ValueChanged( object sender, EventArgs e )
        {
            Viewport2.Camera.Move( FactorMoveCamera );
            view2.Refresh();
        }

        //-------------------------------------------------------------------------//



        //-------------------------------------------------------------------------//
        //                             VIEWPORT 3                                  //
        //-------------------------------------------------------------------------//

        private void view3_Paint( object sender, PaintEventArgs e )
        {
            Viewport3.UpdateViewport();
        }

        //-------------------------------------------------------------------------//

        private void view3_Click( object sender, EventArgs e )
        {
            if ( Viewport3.bEnabled )
            {
                if ( !Mouse.IsClick )
                    Mouse.SetClick( Viewport3.type );
                else
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.CursorTool:
                            if ( Scene.GetBrushSelect() != null )
                                Scene.ClearBrushSelect();
                            break;

                        case Program.SelectTool.CameraTool:
                            break;

                        case Program.SelectTool.EntityTool:
                            break;

                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrush();
                            break;
                    }

                    Refresh();
                    Mouse.RemoveClick();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseMove( object sender, MouseEventArgs e )
        {
            if ( Viewport3.bEnabled )
            {
                Mouse.UpdatePosition( e.X, Math.Abs( e.Y - view3.Height ), Viewport.fSize );

                if ( Mouse.IsClick )
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.BoxTool:
                        case Program.SelectTool.CursorTool:
                            Scene.CreateBrushSelect( Viewport3.type, Viewport3.Camera );
                            break;

                        case Program.SelectTool.CameraTool:
                            break;

                        case Program.SelectTool.EntityTool:
                            break;
                    }

                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void label_viewport3_MouseClick( object sender, MouseEventArgs e )
        {
            if ( Viewport3.bEnabled )
            {
                TmpViewport = Viewport3;
                menuTypeViewport.Show( Cursor.Position.X, Cursor.Position.Y );
            }
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseWheel( object sender, MouseEventArgs e )
        {
            if ( Viewport3.bEnabled && Viewport3.type != Viewport.TypeViewport.Textured_3D )
            {
                if ( e.Delta > 0 )
                {
                    if ( vScrollBar_viewport3.Value < vScrollBar_viewport3.Maximum )
                        vScrollBar_viewport3.Value += vScrollBar_viewport3.SmallChange;

                    if ( hScrollBar_viewport3.Value < hScrollBar_viewport3.Maximum )
                        hScrollBar_viewport3.Value += hScrollBar_viewport3.SmallChange;
                }
                else
                {
                    if ( hScrollBar_viewport3.Value > hScrollBar_viewport3.Minimum )
                        hScrollBar_viewport3.Value -= hScrollBar_viewport3.SmallChange;

                    if ( vScrollBar_viewport3.Value > vScrollBar_viewport3.Minimum )
                        vScrollBar_viewport3.Value -= vScrollBar_viewport3.SmallChange;
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport3_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( -( e.NewValue - e.OldValue ), 0, 0 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport3_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( 0, e.NewValue - e.OldValue, 0 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport3_ValueChanged( object sender, EventArgs e )
        {
            Viewport3.Camera.Move( FactorMoveCamera );
            view3.Refresh();
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport3_ValueChanged( object sender, EventArgs e )
        {
            Viewport3.Camera.Move( FactorMoveCamera );
            view3.Refresh();
        }

        //-------------------------------------------------------------------------//



        //-------------------------------------------------------------------------//
        //                             VIEWPORT 4                                  //
        //-------------------------------------------------------------------------//

        private void view4_Paint( object sender, PaintEventArgs e )
        {
            Viewport4.UpdateViewport();
        }

        //-------------------------------------------------------------------------//

        private void view4_Click( object sender, EventArgs e )
        {
            if ( Viewport4.bEnabled )
            {
                if ( !Mouse.IsClick )
                    Mouse.SetClick( Viewport4.type );
                else
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.CursorTool:
                            if ( Scene.GetBrushSelect() != null )
                                Scene.ClearBrushSelect();
                            break;

                        case Program.SelectTool.CameraTool:
                            break;

                        case Program.SelectTool.EntityTool:
                            break;

                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrush();
                            break;
                    }

                    Refresh();
                    Mouse.RemoveClick();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseMove( object sender, MouseEventArgs e )
        {
            if ( Viewport2.bEnabled )
            {
                Mouse.UpdatePosition( e.X, Math.Abs( e.Y - view4.Height ), Viewport.fSize );

                if ( Mouse.IsClick )
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.BoxTool:
                        case Program.SelectTool.CursorTool:
                            Scene.CreateBrushSelect( Viewport4.type, Viewport4.Camera );
                            break;

                        case Program.SelectTool.CameraTool:
                            break;

                        case Program.SelectTool.EntityTool:
                            break;
                    }

                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void label_viewport4_MouseClick( object sender, MouseEventArgs e )
        {
            if ( Viewport4.bEnabled )
            {
                TmpViewport = Viewport4;
                menuTypeViewport.Show( Cursor.Position.X, Cursor.Position.Y );
            }
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseWheel( object sender, MouseEventArgs e )
        {
            if ( Viewport4.bEnabled && Viewport4.type != Viewport.TypeViewport.Textured_3D )
            {
                if ( e.Delta > 0 )
                {
                    if ( vScrollBar_viewport4.Value < vScrollBar_viewport4.Maximum )
                        vScrollBar_viewport4.Value += vScrollBar_viewport4.SmallChange;

                    if ( hScrollBar_viewport4.Value < hScrollBar_viewport4.Maximum )
                        hScrollBar_viewport4.Value += hScrollBar_viewport4.SmallChange;
                }
                else
                {
                    if ( hScrollBar_viewport4.Value > hScrollBar_viewport4.Minimum )
                        hScrollBar_viewport4.Value -= hScrollBar_viewport4.SmallChange;

                    if ( vScrollBar_viewport4.Value > vScrollBar_viewport4.Minimum )
                        vScrollBar_viewport4.Value -= vScrollBar_viewport4.SmallChange;
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport4_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( -( e.NewValue - e.OldValue ), 0, 0 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport4_Scroll( object sender, ScrollEventArgs e )
        {
            FactorMoveCamera = new Vector3f( 0, e.NewValue - e.OldValue, 0 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport4_ValueChanged( object sender, EventArgs e )
        {
            Viewport4.Camera.Move( FactorMoveCamera );
            view4.Refresh();
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport4_ValueChanged( object sender, EventArgs e )
        {
            Viewport4.Camera.Move( FactorMoveCamera );
            view4.Refresh();
        }

        //-------------------------------------------------------------------------//



        //-------------------------------------------------------------------------//
        //                             MENU BAR                                    //
        //-------------------------------------------------------------------------//

        private void toolStripMenuItem10_Click( object sender, EventArgs e ) // ABOUT
        {
            About about = new About();
            about.ShowDialog();
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem8_Click( object sender, EventArgs e ) // EXIT
        {
            Application.Exit();
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem2_Click( object sender, EventArgs e ) // NEW MAP
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

        private void toolStripMenuItem7_Click( object sender, EventArgs e ) // CLOSE MAP
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

            Scene.Clear();
            Refresh();
        }

        //-------------------------------------------------------------------------//



        //-------------------------------------------------------------------------//
        //                          MENU TYPE VIEWPORT                             //
        //-------------------------------------------------------------------------//

        private void dFrontXYToolStripMenuItem_Click( object sender, EventArgs e ) // FRONT 2D
        {
            TmpViewport.SetTypeViewport( Viewport.TypeViewport.Front_2D_yz );
        }

        //-------------------------------------------------------------------------//

        private void dSideToolStripMenuItem_Click( object sender, EventArgs e ) // SIDE 2D
        {
            TmpViewport.SetTypeViewport( Viewport.TypeViewport.Side_2D_xz );
        }

        //-------------------------------------------------------------------------//

        private void dTopZYToolStripMenuItem_Click( object sender, EventArgs e ) // TOP 2D
        {
            TmpViewport.SetTypeViewport( Viewport.TypeViewport.Top_2D_xy );
        }

        //-------------------------------------------------------------------------//

        private void dTexturedToolStripMenuItem_Click( object sender, EventArgs e ) // TEXTURED 3D
        {
            TmpViewport.SetTypeViewport( Viewport.TypeViewport.Textured_3D );
            Scene.SetViewportWorldCamera( TmpViewport.View );
        }

        //-------------------------------------------------------------------------//



        //-------------------------------------------------------------------------//
        //                          MENU SELECT TOOLS                              //
        //-------------------------------------------------------------------------//

        private void button_cursor_Click( object sender, EventArgs e ) // CURSOR
        {
            Program.selectTool = Program.SelectTool.CursorTool;
            Scene.ClearBrushSelect();
            Mouse.RemoveClick();
            Refresh();
        }

        //-------------------------------------------------------------------------//

        private void button_camera_Click( object sender, EventArgs e ) // CAMERA
        {
            Program.selectTool = Program.SelectTool.CameraTool;
            Scene.ClearBrushSelect();
            Mouse.RemoveClick();
            Refresh();
        }

        //-------------------------------------------------------------------------//

        private void button_entitytool_Click( object sender, EventArgs e ) // ENTITY TOOL
        {
            Program.selectTool = Program.SelectTool.EntityTool;
            Scene.ClearBrushSelect();
            Mouse.RemoveClick();
            Refresh();
        }

        //-------------------------------------------------------------------------//

        private void button_boxtool_Click( object sender, EventArgs e ) // BOX TOOL (BRUSH)
        {
            Program.selectTool = Program.SelectTool.BoxTool;
            Scene.ClearBrushSelect();
            Mouse.RemoveClick();
            Refresh();
        }

        //-------------------------------------------------------------------------//



        private Viewport TmpViewport;
        private Viewport Viewport1;
        private Viewport Viewport2;
        private Viewport Viewport3;
        private Viewport Viewport4;
        private Vector3f FactorMoveCamera = new Vector3f( 0, 0, 0 );
    }

    //-------------------------------------------------------------------------//
}
