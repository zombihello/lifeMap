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
using lifeMap.src.forms;

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

            Viewport2 = new Viewport( view2, Viewport.TypeViewport.Top_2D_xz, label_viewport2, vScrollBar__viewport2, hScrollBar_viewport2 );
            Viewport2.bEnabled = false;

            Viewport3 = new Viewport( view3, Viewport.TypeViewport.Front_2D_yz, label_viewport3, vScrollBar_viewport3, hScrollBar_viewport3 );
            Viewport3.bEnabled = false;

            Viewport4 = new Viewport( view4, Viewport.TypeViewport.Side_2D_xy, label_viewport4, vScrollBar_viewport4, hScrollBar_viewport4 );
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

            SerializationSettings settings = new SerializationSettings();
            settings.Load( Path.GetDirectoryName( Program.args[ 0 ] ) + "\\settings.cfg", options );

            LoadListEntity();

            for ( int i = 0; i < comboBox_CategEntity.Items.Count; i++ )
                Program.SelectEntity.Add( comboBox_CategEntity.Items[ i ].ToString(), "" );
        }

        //-------------------------------------------------------------------------//

        public void LoadListEntity()
        {
            listEntity.Entity.Clear();

            SerializationEntity entity = new SerializationEntity();
            List<string> RouteToDEG = options.GetRouteToDEG();

            for ( int i = 0; i < RouteToDEG.Count; i++ )
            {
                Dictionary<string, Dictionary<string, Dictionary<string, string>>> tmpEntity = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

                if ( entity.LoadEntity( RouteToDEG[ i ] ) )
                {
                    tmpEntity = entity.listEntity.Entity;

                    for ( int j = 0; j < tmpEntity.Keys.Count; j++ )
                        if ( !listEntity.Entity.ContainsKey( tmpEntity.Keys.ToList()[ j ] ) )
                            listEntity.Entity.Add( tmpEntity.Keys.ToList()[ j ], tmpEntity[ tmpEntity.Keys.ToList()[ j ] ] );
                }
            }
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

        private void MainForm_Shown( object sender, EventArgs e )
        {
            if ( Program.args.Length > 1 )
                if ( options.GetRouteToDEG().Count == 0 )
                    MessageBox.Show( "No upload game data files (entity)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                else
                    LoadMap( Program.args[ 1 ] );
        }

        //-------------------------------------------------------------------------//

        private void ClearMap()
        {
            Scene.Clear();
            ManagerTexture.ClearTextures();
            image_previewTexture.Image = null;
            comboBox_textureView.SelectedIndex = -1;
            comboBox_textureView.Items.Clear();
        }

        //-------------------------------------------------------------------------//

        private void LoadMap( string Route )
        {
            Serialization serialization = new Serialization();
            serialization.LoadMap( Route );

            serialization.GetMapSettings( mapProperties );
            ManagerTexture.mTextures = serialization.GetLoadTextures( options.GetTexturesDirecoty() );

            for ( int i = 0; i < ManagerTexture.mTextures.Count; i++ )
            {
                ManagerTexture.mTextures[ i ].Route = options.GetTexturesDirecoty() + "\\" + ManagerTexture.mTextures[ i ].Name;

                if ( File.Exists( ManagerTexture.mTextures[ i ].Route ) )
                {
                    comboBox_textureView.Items.Add( ManagerTexture.mTextures[ i ].Name );
                    ManagerTexture.mPicTextures.Add( new Bitmap( ManagerTexture.mTextures[ i ].Route ) );
                }
                else
                    ManagerTexture.mTextures.RemoveAt( i );
            }

            Scene.SetAllBrushes( serialization.GetSolidBrushes() );
            Scene.SetAllEntitys( serialization.GetEntitys() );

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

        //-------------------------------------------------------------------------//
        //                             VIEWPORT                                    //
        //-------------------------------------------------------------------------//

        //-------------------------------------------------------------------------//

        private void Viewport_MouseDown( Viewport Viewport, Vector3f MousePosition, MouseButtons Button )
        {
            if ( Viewport.bEnabled )
                if ( !Mouse.IsClick )
                {
                    Mouse.UpdatePosition( MousePosition.X, Math.Abs( MousePosition.Y - Viewport.View.Height ), Viewport.FactorZoom );
                    Mouse.SetClick( Viewport.type, Viewport.Camera );

                    if ( Program.selectTool == Program.SelectTool.CursorTool && !Mouse.IsSelect )
                    {
                        Scene.SelectBrush( Program.ToNewCoords( Viewport.Camera.Position, Mouse.Position ), Viewport.type, Button );
                    }
                    else if ( Mouse.IsSelect )
                    {
                        if ( !Scene.SelectPointResizeBrush( Program.ToNewCoords( Viewport.Camera.Position, Mouse.Position ), Viewport.type ) )
                            Scene.SelectBrush( Program.ToNewCoords( Viewport.Camera.Position, Mouse.Position ), Viewport.type, Button );
                    }

                }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_MouseUp( Viewport Viewport, MouseButtons Button )
        {
            if ( Mouse.IsClick )
            {
                if ( Button == System.Windows.Forms.MouseButtons.Left )
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.CursorTool:
                            if ( Scene.GetBrushSelect() != null )
                                Scene.ClearBrushSelect();
                            break;

                        case Program.SelectTool.CameraTool:
                            break;

                        case Program.SelectTool.EntityTool:
                            Scene.CreateEntity( Viewport.type, Viewport );
                            break;

                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrush();
                            break;
                    }

                Refresh();
                Mouse.RemoveClick();
            }
        }

        //-------------------------------------------------------------------------//
        private void Viewport_MouseMove( Viewport Viewport, Vector3f MousePosition, MouseButtons Button )
        {
            Mouse.UpdatePosition( MousePosition.X, Math.Abs( MousePosition.Y - Viewport.View.Height ), Viewport.FactorZoom, Viewport.fSize );

            if ( Button == System.Windows.Forms.MouseButtons.Left && Viewport.bEnabled )
            {
                if ( Mouse.IsClick )
                {
                    switch ( Program.selectTool )
                    {
                        case Program.SelectTool.BoxTool:
                            Scene.CreateBrushSelect( Viewport.type, Viewport );
                            break;

                        case Program.SelectTool.CursorTool:
                            if ( Mouse.IsSelect )
                            {
                                Vector3f OffsetPosition = new Vector3f( Mouse.Position.X - Mouse.OldPosition.X, Mouse.Position.Y - Mouse.OldPosition.Y, 0 );

                                switch ( Mouse.typeSelect )
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

                        case Program.SelectTool.EntityTool:
                            break;
                    }

                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_Scroll( float OldValue, float NewValue, int IdCoord )
        {
            if ( IdCoord == 1 )
                FactorMoveCamera = new Vector3f( -( NewValue - OldValue ) * 4, 0, 0 );
            else if ( IdCoord == 2 )
                FactorMoveCamera = new Vector3f( 0, ( NewValue - OldValue ) * 4, 0 );
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

        private void Viewport_ShowViewportMenu( Viewport Viewport, MouseButtons Button )
        {
            if ( Button == System.Windows.Forms.MouseButtons.Right )
                if ( Viewport.bEnabled && Viewport.type != src.Viewport.TypeViewport.Textured_3D )
                {
                    if ( Mouse.IsSelect && Mouse.EntitySelect != null )
                        viewportMenu.Show( Cursor.Position.X, Cursor.Position.Y );
                }
        }

        //-------------------------------------------------------------------------//

        private void Viewport_MouseWheel( Viewport Viewport, HScrollBar hScrollBar, VScrollBar vScrollBar, MouseEventArgs e )
        {
            if ( Viewport.bEnabled && Viewport.type != Viewport.TypeViewport.Textured_3D )
            {
                if ( e.Delta > 0 )
                {
                    if ( Viewport.FactorZoom > -5 )
                    {
                        Viewport.FactorZoom--;

                        if ( Viewport.FactorZoom == 0 )
                        {
                            Viewport.FactorZoom--;
                        }

                    }
                }
                else
                {
                    if ( Viewport.FactorZoom < 5 )
                    {
                        Viewport.FactorZoom++;

                        if ( Viewport.FactorZoom == 0 )
                        {
                            Viewport.FactorZoom++;
                        }
                    }
                }

                Viewport.View.Refresh();
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

        private void Viewport_MouseDoubleClick( MouseButtons Button )
        {
            if ( Button == System.Windows.Forms.MouseButtons.Left )
                if ( Mouse.IsSelect && Mouse.BrushSelect != null && Mouse.BrushSelect.brushType != BasicBrush.BrushType.Entity )
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
            Viewport_MouseUp( Viewport1, e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseDown( object sender, MouseEventArgs e )
        {
            Viewport_MouseDown( Viewport1, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport1, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport1_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport1 );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport1, hScrollBar_viewport1, vScrollBar_viewport1, e );
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
            Viewport_MouseDoubleClick( e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view1_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_ShowViewportMenu( Viewport1, e.Button );
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
            Viewport_MouseDown( Viewport2, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseUp( object sender, MouseEventArgs e )
        {
            Viewport_MouseUp( Viewport2, e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport2, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport2_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport2 );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport2, hScrollBar_viewport2, vScrollBar__viewport2, e );
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
            Viewport_MouseDoubleClick( e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view2_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_ShowViewportMenu( Viewport2, e.Button );
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
            Viewport_MouseUp( Viewport3, e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseDown( object sender, MouseEventArgs e )
        {
            Viewport_MouseDown( Viewport3, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport3, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport3_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport3 );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport3, hScrollBar_viewport3, vScrollBar_viewport3, e );
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
            Viewport_MouseDoubleClick( e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view3_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_ShowViewportMenu( Viewport3, e.Button );
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
            Viewport_MouseUp( Viewport4, e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseDown( object sender, MouseEventArgs e )
        {
            Viewport_MouseDown( Viewport4, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseMove( object sender, MouseEventArgs e )
        {
            Viewport_MouseMove( Viewport4, new Vector3f( e.X, e.Y, 0 ), e.Button );
        }

        //-------------------------------------------------------------------------//

        private void label_viewport4_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_SelectTypeViewport( Viewport4 );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseWheel( object sender, MouseEventArgs e )
        {
            Viewport_MouseWheel( Viewport4, hScrollBar_viewport4, vScrollBar_viewport4, e );
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
            Viewport_MouseDoubleClick( e.Button );
        }

        //-------------------------------------------------------------------------//

        private void view4_MouseClick( object sender, MouseEventArgs e )
        {
            Viewport_ShowViewportMenu( Viewport4, e.Button );
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
            if ( options.GetRouteToDEG().Count == 0 )
            {
                MessageBox.Show( "No upload game data files (entity)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            ClearMap();

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
            if ( options.GetRouteToDEG().Count == 0 )
            {
                MessageBox.Show( "No upload game data files (entity)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            openFileDialog.Filter = "lifeMap | *.map";
            openFileDialog.InitialDirectory = options.GetSrcMapDirectory();

            if ( openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                saveFileDialog.FileName = openFileDialog.FileName;
                ClearMap();
                LoadMap( openFileDialog.FileName );
            }
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem4_Click( object sender, EventArgs e ) // SAVE MAP
        {
            saveFileDialog.Filter = "lifeMap | *.map";
            saveFileDialog.InitialDirectory = options.GetSrcMapDirectory();

            if ( saveFileDialog.FileName != "" || saveFileDialog.FileName == "" && saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                Serialization serialization = new Serialization();
                serialization.SetMapSettings( mapProperties );
                serialization.SetLoadTextures( ManagerTexture.mTextures );
                serialization.SetSolidBrushes( Scene.GetAllBrushes() );
                serialization.SetEntitys( Scene.GetAllEntitys() );

                serialization.SaveMap( saveFileDialog.FileName );
            }

        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem5_Click( object sender, EventArgs e ) // SAVE AS..
        {
            saveFileDialog.Filter = "lifeMap | *.map";
            saveFileDialog.InitialDirectory = options.GetSrcMapDirectory();

            if ( saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                Serialization serialization = new Serialization();
                serialization.SetMapSettings( mapProperties );
                serialization.SetLoadTextures( ManagerTexture.mTextures );
                serialization.SetSolidBrushes( Scene.GetAllBrushes() );
                serialization.SetEntitys( Scene.GetAllEntitys() );

                serialization.SaveMap( saveFileDialog.FileName );
            }
        }

        //-------------------------------------------------------------------------//

        private void toolStripMenuItem6_Click( object sender, EventArgs e ) // EXPORT
        {
            if ( runMap.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                saveFileDialog.Filter = "lifeEngine Map | *.lmap";
                saveFileDialog.InitialDirectory = options.GetExportMapDirectory();
                string ExportRoute = "";

                if ( saveFileDialog.ShowDialog() == DialogResult.OK )
                {
                    Serialization serialization = new Serialization();
                    serialization.SetMapSettings( mapProperties );

                    string GameRootDir = options.GetGameDirectory();
                    string GamaExeDir = options.GetGameExecutable();
                    string TextureRoute = "";                   

                    int idChar = GamaExeDir.LastIndexOf( "\\" );
                    GamaExeDir = GamaExeDir.Remove( idChar );

                    while ( GameRootDir != GamaExeDir )
                    {
                        idChar = GamaExeDir.LastIndexOf( "\\" );
                        GamaExeDir = GamaExeDir.Remove( idChar );
                        TextureRoute += "..\\";
                        ExportRoute += "..\\";
                    }

                    TextureRoute += options.GetTexturesDirecoty().Remove( 0, GameRootDir.Length + 1 );
                    ExportRoute += options.GetExportMapDirectory().Remove(0, GameRootDir.Length + 1);
                    serialization.SetLoadTextures( ManagerTexture.mTextures );
                    serialization.SetSolidBrushes( Scene.GetAllBrushes(), true );
                    serialization.SetEntitys( Scene.GetAllEntitys() );

                    serialization.ExportMap( saveFileDialog.FileName, TextureRoute, ExportRoute );
                }

                System.Diagnostics.Process LightmapMaker = new System.Diagnostics.Process();
                LightmapMaker.StartInfo.FileName = Application.ExecutablePath.Remove(Application.ExecutablePath.LastIndexOf("\\")) + "\\lm.exe";
                LightmapMaker.StartInfo.WorkingDirectory = Path.GetDirectoryName(ExportRoute + saveFileDialog.FileName.Remove(0, saveFileDialog.FileName.LastIndexOf("\\") + 1));
                LightmapMaker.StartInfo.Arguments = saveFileDialog.FileName + " " + mapProperties.GetValue("Lightmap Size");
                LightmapMaker.Start();

                if ( runMap.IsStartGame() )
                {
                    System.Diagnostics.Process StartGame = new System.Diagnostics.Process();
                    StartGame.StartInfo.FileName = options.GetGameExecutable();
                    StartGame.StartInfo.WorkingDirectory = Path.GetDirectoryName( options.GetGameExecutable() );
                    StartGame.StartInfo.Arguments = runMap.GetParametesGame();
                    StartGame.Start();
                }
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

            ClearMap();
            Refresh();
        }

        //-------------------------------------------------------------------------//

        private void mapPropiertesToolStripMenuItem_Click( object sender, EventArgs e ) // MAP PROPERTIES
        {
            mapProperties.ShowDialog();
        }

        //-------------------------------------------------------------------------//

        private void smToolStripMenuItem_Click( object sender, EventArgs e ) // SMALLER GRID
        {
            if ( Viewport.fSize > 4 )
            {
                Viewport.fSize = Viewport.fSize / 2;
                Refresh();
            }
        }

        //-------------------------------------------------------------------------//

        private void biggerGridToolStripMenuItem_Click( object sender, EventArgs e ) // BIGGER GRID
        {
            if ( Viewport.fSize < 256 )
            {
                Viewport.fSize = Viewport.fSize * 2;
                Refresh();
            }
        }

        //-------------------------------------------------------------------------//

        private void optionsToolStripMenuItem_Click( object sender, EventArgs e ) // OPTIONS
        {
            options.ShowDialog();

            int Intensity = options.GetIntensity();

            Viewport.fSize = options.GetSizeGrid();
            Viewport.colorGrid = new lifeMap.src.Color( Intensity, Intensity, Intensity );
            Viewport.cameraFOV = options.GetCameraFOV();
            Viewport.zFar = options.GetRenderDistance();
            ManagerTexture.SetFilterTexture( options.GetFilterTexture() );
            LoadListEntity();

            if ( string.Equals( comboBox_CategEntity.SelectedItem, "Entity" ) )
            {
                comboBox_ObjEntity.Items.Clear();
                comboBox_ObjEntity.Items.Add( "" );
                comboBox_ObjEntity.Items.Clear();

                Dictionary<string, Dictionary<string, Dictionary<string, string>>> tmpEntity = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
                tmpEntity = listEntity.Entity;

                for ( int i = 0; i < tmpEntity.Keys.Count; i++ )
                    comboBox_ObjEntity.Items.Add( tmpEntity.Keys.ToList()[ i ] );

                if ( comboBox_ObjEntity.Items.Count > 0 )
                    comboBox_ObjEntity.SelectedIndex = 0;
            }

            SerializationSettings saveSettings = new SerializationSettings();
            saveSettings.Save( Path.GetDirectoryName( Program.args[ 0 ] ) + "\\settings.cfg", options );

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
            TmpViewport.SetTypeViewport( Viewport.TypeViewport.Side_2D_xy );
        }

        //-------------------------------------------------------------------------//

        private void dTopZYToolStripMenuItem_Click( object sender, EventArgs e ) // TOP 2D
        {
            TmpViewport.SetTypeViewport( Viewport.TypeViewport.Top_2D_xz );
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
            comboBox_CategEntity.SelectedItem = "Entity";

            if ( comboBox_ObjEntity.Items.Count > 1 )
                Program.SelectEntity[ "Entity" ] = comboBox_ObjEntity.SelectedItem.ToString();

            Refresh();
        }

        //-------------------------------------------------------------------------//

        private void button_boxtool_Click( object sender, EventArgs e ) // BOX TOOL (BRUSH)
        {
            Program.selectTool = Program.SelectTool.BoxTool;
            Scene.ClearBrushSelect();
            Mouse.RemoveClick();
            comboBox_CategEntity.SelectedItem = "Primitives";
            Program.SelectEntity[ "Primitives" ] = comboBox_ObjEntity.SelectedItem.ToString();

            Refresh();
        }

        //-------------------------------------------------------------------------//



        //-------------------------------------------------------------------------//
        //                          MENU SELECT TEXTURE                            //
        //-------------------------------------------------------------------------//

        private void button_texturePreview_Click( object sender, EventArgs e )
        {
            openFileDialog.Filter = "";
            openFileDialog.InitialDirectory = options.GetTexturesDirecoty();

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
        //                          MENU SELECT ENTITY                             //
        //-------------------------------------------------------------------------//

        private void comboBox_CategEntity_SelectedIndexChanged( object sender, EventArgs e )
        {
            int IndexSelect = comboBox_CategEntity.SelectedIndex;
            string selectCategory = comboBox_CategEntity.Items[ IndexSelect ].ToString();

            comboBox_ObjEntity.Items.Clear();
            comboBox_ObjEntity.Items.Add( "" );
            comboBox_ObjEntity.Items.Clear();

            if ( string.Equals( selectCategory, "Entity" ) )
            {
                Program.SelectCategoryEntity = "Entity";

                for ( int i = 0; i < listEntity.Entity.Keys.Count; i++ )
                {
                    string key = listEntity.Entity.Keys.ToList()[ i ];
                    comboBox_ObjEntity.Items.Add( key );
                }
            }
            else if ( string.Equals( selectCategory, "Primitives" ) )
            {
                Program.SelectCategoryEntity = "Primitives";

                comboBox_ObjEntity.Items.Add( "Cube" );
                comboBox_ObjEntity.Items.Add( "Sphere" );
                comboBox_ObjEntity.Items.Add( "Plane" );
            }

            if ( comboBox_ObjEntity.Items.Count > 0 )
                comboBox_ObjEntity.SelectedIndex = 0;
        }

        //-------------------------------------------------------------------------//

        private void comboBox_ObjEntity_SelectedIndexChanged( object sender, EventArgs e )
        {
            int IndexSelect = comboBox_ObjEntity.SelectedIndex;
            string selectEntity = comboBox_ObjEntity.Items[ IndexSelect ].ToString();

            Program.SelectEntity[ comboBox_CategEntity.SelectedItem.ToString() ] = selectEntity;
        }

        //-------------------------------------------------------------------------//

        //-------------------------------------------------------------------------//
        //                          VIEWPORT MENU                                  //
        //-------------------------------------------------------------------------//

        //-------------------------------------------------------------------------//

        private void propertiesToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Mouse.EntitySelect.ShowProperties();
        }

        //-------------------------------------------------------------------------//

        public static Options options = new Options();
        public static SimpleOpenGlControl MainContext = new SimpleOpenGlControl();

        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private MapProperties mapProperties = new MapProperties();
        private RunMap runMap = new RunMap();
        private Vector3f FactorMoveCamera = new Vector3f( 0, 0, 0 );
        private ListEntity listEntity = new ListEntity();

        private Viewport TmpViewport;
        private Viewport Viewport1;
        private Viewport Viewport2;
        private Viewport Viewport3;
        private Viewport Viewport4;
    }

    //-------------------------------------------------------------------------//
}
