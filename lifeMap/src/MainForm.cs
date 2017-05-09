using System;
using System.IO;
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
using Tao.DevIl;
using Newtonsoft.Json;

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
            MainContext.InitializeContexts();

            saveFileDialog.Filter = "lifeMap | *.map";

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

            Il.ilInit();
            Il.ilEnable( Il.IL_ORIGIN_SET );

            Gl.glDepthMask( Gl.GL_TRUE );
            Gl.glClearDepth( 1 );
        }

        //-------------------------------------------------------------------------//



        //-------------------------------------------------------------------------//
        //                             VIEWPORT                                    //
        //-------------------------------------------------------------------------//

        //-------------------------------------------------------------------------//

        private void Viewport_MouseDown( Viewport Viewport, Vector3f MousePosition )
        {
            if ( Viewport.bEnabled )
                if ( !Mouse.IsClick )
                {
                    Mouse.UpdatePosition( new Vector3f( MousePosition.X, Math.Abs( MousePosition.Y - Viewport.View.Height ), 0 ) );
                    Mouse.SetClick( Viewport.type, Viewport.Camera );

                    if ( Program.selectTool == Program.SelectTool.CursorTool )
                    {
                        if ( !Mouse.IsSelectBrush )
                            Scene.SelectBrush( Program.ToNewCoords( Viewport.Camera.Position, Mouse.Position ), Viewport.type );
                        else
                        {
                            if ( !Scene.SelectPointResizeBrush( Program.ToNewCoords( Viewport.Camera.Position, Mouse.Position ), Viewport.type ) )
                                Scene.SelectBrush( Program.ToNewCoords( Viewport.Camera.Position, Mouse.Position ), Viewport.type );
                        }
                    }
                }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_MouseUp( Viewport Viewport )
        {
            if ( Viewport.bEnabled )
                if ( Mouse.IsClick )
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.CursorTool:
                            if ( Scene.GetBrushSelect() != null )
                                Scene.ClearBrushSelect();
                            break;

                        case Program.SelectTool.CameraTool:
                            break;

                        case Program.SelectTool.EntityTool: break;

                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrush();
                            break;
                    }

                    Refresh();
                    Mouse.RemoveClick();
                }
        }

        //-------------------------------------------------------------------------//
        private void Viewport_MouseMove( Viewport Viewport, Vector3f MousePosition )
        {
            if ( Viewport.bEnabled )
            {
                Mouse.UpdatePosition( MousePosition.X, Math.Abs( MousePosition.Y - Viewport.View.Height ), Viewport.fSize );

                if ( Mouse.IsClick )
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrushSelect( Viewport.type, Viewport.Camera );
                            break;

                        case Program.SelectTool.CursorTool:
                            if ( Mouse.IsSelectBrush )
                            {
                                Vector3f OffsetPosition = new Vector3f( Mouse.Position.X - Mouse.OldPosition.X, Mouse.Position.Y - Mouse.OldPosition.Y, 0 );

                                switch ( Mouse.typeSelectBrush )
                                {
                                    case Mouse.TypeSelectBrush.Move:
                                        Mouse.BrushSelect.Move( OffsetPosition, Viewport.type );
                                        break;

                                    case Mouse.TypeSelectBrush.Resize:
                                        Mouse.BrushSelect.Resize( OffsetPosition, Viewport.type );
                                        break;

                                    case Mouse.TypeSelectBrush.Rotate:
                                        Mouse.BrushSelect.Rotate( Viewport, Viewport.type );
                                        break;
                                }
                            }
                            break;

                        case Program.SelectTool.CameraTool:
                            break;

                        case Program.SelectTool.EntityTool: break;
                    }

                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_Scroll( float OldValue, float NewValue, int IdCoord )
        {
            if ( IdCoord == 1 )
                FactorMoveCamera = new Vector3f( -( NewValue - OldValue ) * Viewport.fSize, 0, 0 );
            else if ( IdCoord == 2 )
                FactorMoveCamera = new Vector3f( 0, ( NewValue - OldValue ) * Viewport.fSize, 0 );
        }

        //-------------------------------------------------------------------------//

        private void Viewport_ValueChanged( Viewport Viewport )
        {
            Viewport.Camera.Move( FactorMoveCamera );
            Viewport.View.Refresh();
        }

        //-------------------------------------------------------------------------//

        private void Viewport_SelectTypeViewport( Viewport Viewport )
        {
            if ( Viewport.bEnabled )
            {
                TmpViewport = Viewport;
                menuTypeViewport.Show( Cursor.Position.X, Cursor.Position.Y );
            }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_MouseWheel( Viewport Viewport, HScrollBar hScrollBar, VScrollBar vScrollBar, float Delta )
        {
            if ( Viewport.bEnabled && Viewport.type != Viewport.TypeViewport.Textured_3D )
            {
                if ( Delta > 0 )
                {
                    if ( vScrollBar.Value < vScrollBar.Maximum )
                        vScrollBar.Value += vScrollBar.SmallChange;

                    if ( hScrollBar.Value < hScrollBar.Maximum )
                        hScrollBar.Value += hScrollBar.SmallChange;
                }
                else
                {
                    if ( hScrollBar.Value > hScrollBar.Minimum )
                        hScrollBar.Value -= hScrollBar.SmallChange;

                    if ( vScrollBar.Value > vScrollBar.Minimum )
                        vScrollBar.Value -= vScrollBar.SmallChange;
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_KeyDown( Viewport Viewport, Keys KeyCode )
        {
            if ( Viewport.bEnabled )
            {
                if ( Viewport.type == Viewport.TypeViewport.Textured_3D )
                    Scene.WorldCamera.Move( KeyCode );
                else
                    if ( KeyCode == Keys.Delete )
                        Scene.RemoveBrush( Mouse.BrushSelect );

                Refresh();
            }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_MouseDoubleClick()
        {
            if ( Mouse.IsSelectBrush && Mouse.BrushSelect != null )
            {
                if ( ManagerPoints.pointsType != ManagerPoints.PointsType.Rotate )
                    ManagerPoints.SetPointsType( ManagerPoints.PointsType.Rotate );
                else
                    ManagerPoints.SetPointsType( ManagerPoints.PointsType.Resize );
            }
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

        private void view1_MouseUp( object sender, MouseEventArgs e )
        {
            Viewport_MouseUp( Viewport1 );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseDown( object sender, MouseEventArgs e )
        {
            Viewport_MouseDown( Viewport1, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport1, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport1_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport1 );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport1, hScrollBar_viewport1, vScrollBar_viewport1, e.Delta );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport1_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 1 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport1_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 2 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport1_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport1 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport1_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport1 );
        }

        //-------------------------------------------------------------------------//

        private void view1_KeyDown( object sender, KeyEventArgs e )
        {
            Viewport_KeyDown( Viewport1, e.KeyCode );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            Viewport_MouseDoubleClick();
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

        private void view2_MouseDown( object sender, MouseEventArgs e )
        {
            Viewport_MouseDown( Viewport2, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseUp( object sender, MouseEventArgs e )
        {
            Viewport_MouseUp( Viewport2 );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport2, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport2_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport2 );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport2, hScrollBar_viewport2, vScrollBar__viewport2, e.Delta );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport2_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 1 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar__viewport2_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 2 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport2_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport2 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar__viewport2_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport2 );
        }

        //-------------------------------------------------------------------------//

        private void view2_KeyDown( object sender, KeyEventArgs e )
        {
            Viewport_KeyDown( Viewport2, e.KeyCode );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            Viewport_MouseDoubleClick();
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

        private void view3_MouseUp( object sender, MouseEventArgs e )
        {
            Viewport_MouseUp( Viewport3 );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseDown( object sender, MouseEventArgs e )
        {
            Viewport_MouseDown( Viewport3, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport3, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport3_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport3 );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport3, hScrollBar_viewport3, vScrollBar_viewport3, e.Delta );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport3_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 1 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport3_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 2 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport3_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport3 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport3_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport3 );
        }

        //-------------------------------------------------------------------------//

        private void view3_KeyDown( object sender, KeyEventArgs e )
        {
            Viewport_KeyDown( Viewport3, e.KeyCode );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            Viewport_MouseDoubleClick();
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

        private void view4_MouseUp( object sender, MouseEventArgs e )
        {
            Viewport_MouseUp( Viewport4 );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseDown( object sender, MouseEventArgs e )
        {
            Viewport_MouseDown( Viewport4, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport4, new Vector3f( e.X, e.Y, 0 ) );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport4_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport4 );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport4, hScrollBar_viewport4, vScrollBar_viewport4, e.Delta );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport4_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 1 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport4_Scroll( object sender, ScrollEventArgs e )
        {
            Viewport_Scroll( e.OldValue, e.NewValue, 2 );
        }

        //-------------------------------------------------------------------------//

        private void hScrollBar_viewport4_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport4 );
        }

        //-------------------------------------------------------------------------//

        private void vScrollBar_viewport4_ValueChanged( object sender, EventArgs e )
        {
            Viewport_ValueChanged( Viewport4 );
        }

        //-------------------------------------------------------------------------//

        private void view4_KeyDown( object sender, KeyEventArgs e )
        {
            Viewport_KeyDown( Viewport4, e.KeyCode );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            Viewport_MouseDoubleClick();
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
            Scene.Clear();
            ManagerTexture.ClearTextures();
            image_previewTexture.Image = null;
            comboBox_textureView.SelectedIndex = -1;
            comboBox_textureView.Items.Clear();

            menuBar.Items[ 1 ].Visible = true;

            menuBar_File.DropDownItems[ 3 ].Enabled = true; // Save Map
            menuBar_File.DropDownItems[ 4 ].Enabled = true; // Save as...
            menuBar_File.DropDownItems[ 6 ].Enabled = true; // Export
            menuBar_File.DropDownItems[ 8 ].Enabled = true; // Close Map

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

        private void toolStripMenuItem3_Click( object sender, EventArgs e ) // LOAD MAP
        {
            openFileDialog.Filter = "lifeMap | *.map";

            if ( openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                Scene.Clear();
                ManagerTexture.ClearTextures();
                image_previewTexture.Image = null;
                comboBox_textureView.SelectedIndex = -1;
                comboBox_textureView.Items.Clear();

                Serialization serialization = new Serialization();
                serialization.LoadMap( openFileDialog.FileName );

                serialization.GetMapSettings( mapProperties );
                ManagerTexture.mTextures = serialization.GetLoadTextures();

                for ( int i = 0; i < ManagerTexture.mTextures.Count; i++ )
                {
                    comboBox_textureView.Items.Add( ManagerTexture.mTextures[ i ].Name );
                    ManagerTexture.mPicTextures.Add( new Bitmap( ManagerTexture.mTextures[ i ].Route ) );
                }

                Scene.SetAllBrushes( serialization.GetSolidBrushes() );

                menuBar.Items[ 1 ].Visible = true;

                menuBar_File.DropDownItems[ 3 ].Enabled = true; // Save Map
                menuBar_File.DropDownItems[ 4 ].Enabled = true; // Save as...
                menuBar_File.DropDownItems[ 6 ].Enabled = true; // Export
                menuBar_File.DropDownItems[ 8 ].Enabled = true; // Close Map

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
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem4_Click( object sender, EventArgs e ) // SAVE MAP
        {
            saveFileDialog.Filter = "lifeMap | *.map";

            if ( saveFileDialog.FileName != "" || saveFileDialog.FileName == "" && saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                Serialization serialization = new Serialization();
                serialization.SetMapSettings( mapProperties );
                serialization.SetLoadTextures( ManagerTexture.mTextures );
                serialization.SetSolidBrushes( Scene.GetAllBrushes() );

                serialization.SaveMap( saveFileDialog.FileName );
            }

        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem5_Click( object sender, EventArgs e ) // SAVE AS..
        {
            saveFileDialog.Filter = "lifeMap | *.map";

            if ( saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                Serialization serialization = new Serialization();
                serialization.SetMapSettings( mapProperties );
                serialization.SetLoadTextures( ManagerTexture.mTextures );
                serialization.SetSolidBrushes( Scene.GetAllBrushes() );

                serialization.SaveMap( saveFileDialog.FileName );
            }
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem6_Click( object sender, EventArgs e ) // EXPORT
        {
            saveFileDialog.Filter = "lifeEngine Map | *.lmap";

            if ( saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                Serialization serialization = new Serialization();
                serialization.SetMapSettings( mapProperties );
                serialization.SetLoadTextures( ManagerTexture.mTextures );
                serialization.SetSolidBrushes( Scene.GetAllBrushes(), true );

                serialization.ExportMap( saveFileDialog.FileName );
            }
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem7_Click( object sender, EventArgs e ) // CLOSE MAP
        {
            menuBar.Items[ 1 ].Visible = false;

            menuBar_File.DropDownItems[ 3 ].Enabled = false; // Save Map
            menuBar_File.DropDownItems[ 4 ].Enabled = false; // Save as...
            menuBar_File.DropDownItems[ 6 ].Enabled = false; // Export
            menuBar_File.DropDownItems[ 8 ].Enabled = false; // Close Map

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
            ManagerTexture.ClearTextures();
            image_previewTexture.Image = null;
            comboBox_textureView.SelectedIndex = -1;
            comboBox_textureView.Items.Clear();

            Refresh();
        }

        //-------------------------------------------------------------------------//

        private void mapPropiertesToolStripMenuItem_Click( object sender, EventArgs e ) // MAP PROPERTIES
        {
            mapProperties.ShowDialog();
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



        //-------------------------------------------------------------------------//
        //                          MENU SELECT TEXTURE                            //
        //-------------------------------------------------------------------------//

        private void button_texturePreview_Click( object sender, EventArgs e )
        {
            openFileDialog.Filter = "";

            if ( openFileDialog.ShowDialog() == DialogResult.OK &&
                !ManagerTexture.IsTextureExist( Path.GetFileName( openFileDialog.FileName ) ) )
            {
                ManagerTexture.LoadTexture( openFileDialog.FileName );

                comboBox_textureView.Items.Add( Path.GetFileName( openFileDialog.FileName ) );
                comboBox_textureView.SelectedIndex = comboBox_textureView.Items.Count - 1;
                image_previewTexture.Image = ( Image ) ManagerTexture.mPicTextures[ comboBox_textureView.Items.Count - 1 ];
            }
        }

        //-------------------------------------------------------------------------//

        private void comboBox_textureView_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ManagerTexture.SetSelectTexture( comboBox_textureView.Items[ comboBox_textureView.SelectedIndex ].ToString() );
            image_previewTexture.Image = ( Image ) ManagerTexture.mPicTextures[ comboBox_textureView.SelectedIndex ];
        }

        //-------------------------------------------------------------------------//

        public static SimpleOpenGlControl MainContext = new SimpleOpenGlControl();

        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private MapProperties mapProperties = new MapProperties();
        private Vector3f FactorMoveCamera = new Vector3f( 0, 0, 0 );

        private Viewport TmpViewport;
        private Viewport Viewport1;
        private Viewport Viewport2;
        private Viewport Viewport3;
        private Viewport Viewport4;
    }

    //-------------------------------------------------------------------------//
}
