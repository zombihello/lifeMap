using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src.system;
using lifeMap.src.brushes;

namespace lifeMap.src
{
    //-------------------------------------------------------------------------//

    class Viewport
    {
        //-------------------------------------------------------------------------//

        public enum TypeViewport
        {
            None,
            Top_2D_xy,
            Front_2D_yz,
            Side_2D_xz,
            Textured_3D
        };

        //-------------------------------------------------------------------------//

        public Viewport( SimpleOpenGlControl View, Label labeViewport, VScrollBar scrollBarV, HScrollBar scrollBarH )
        {
            this.View = View;
            Camera = new Camera( View );
            LabelViewport = labeViewport;
            vScrollBar = scrollBarV;
            hScrollBar = scrollBarH;

            this.View.InitializeContexts();
        }

        //-------------------------------------------------------------------------//

        public Viewport( SimpleOpenGlControl View, TypeViewport TypeViewport, Label labeViewport, VScrollBar scrollBarV, HScrollBar scrollBarH )
        {
            this.View = View;
            Camera = new Camera( View );
            type = TypeViewport;
            LabelViewport = labeViewport;
            LabelViewport.Text = type.ToString();
            vScrollBar = scrollBarV;
            hScrollBar = scrollBarH;

            this.View.InitializeContexts();

            MainForm.MainContext.MakeCurrent();
            IntPtr mainContext_RC = Wgl.wglGetCurrentContext();

            this.View.MakeCurrent();
            IntPtr View_RC = Wgl.wglGetCurrentContext();

            Wgl.wglShareLists( mainContext_RC, View_RC );

            if ( type == TypeViewport.Textured_3D )
            {
                vScrollBar.Visible = false;
                hScrollBar.Visible = false;
            }
        }

        //-------------------------------------------------------------------------//

        public void UpdateViewport()
        {
            View.MakeCurrent();
            Viewport.TmpViewport = this;

            //Инициализация OpenGL
            Gl.glMatrixMode( Gl.GL_PROJECTION );
            Gl.glLoadIdentity();
            Gl.glViewport( 0, 0, View.Width, View.Height );

            if ( type != TypeViewport.Textured_3D )
            {
                if ( FactorZoom < 0 )
                    Gl.glOrtho( 0, View.Width / FactorZoom, 0, View.Height / FactorZoom, -View.Width / FactorZoom, View.Width / FactorZoom );
                else
                    Gl.glOrtho( 0, View.Width * FactorZoom, 0, View.Height * FactorZoom, -View.Width * FactorZoom, View.Width * FactorZoom );
            }
            else
            {
                Glu.gluPerspective( 45f, ( float ) View.Width / ( float ) View.Height, 0.1f, 1000.0f );
                Scene.WorldCamera.SetPosition( Scene.WorldCamera.Position );
            }

            Gl.glMatrixMode( Gl.GL_MODELVIEW );
            Gl.glLoadIdentity();

            Gl.glEnable( Gl.GL_TEXTURE_2D );
            Gl.glEnable( Gl.GL_DEPTH_TEST );

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT );

            if ( bEnabled )
            {
                Texture.ClearSelectTexture();

                if ( type != TypeViewport.Textured_3D )
                {
                    Camera.Update( type );
                    RenderGrid();
                    Camera.RenderCamera();

                    if ( Mouse.IsSelectBrush && Mouse.BrushSelect != null )
                    {
                        ManagerPoints.PointsUpdate();
                        ManagerPoints.PointsRender( type );
                    }
                }
                else
                    Scene.WorldCamera.Update( type );

                Scene.UpdateScene( type );
            }
        }

        //-------------------------------------------------------------------------//

        private void RenderGrid()
        {
            if ( type == TypeViewport.Top_2D_xy )
                Gl.glRotatef( 90, 1, 0, 0 );
            else if ( type == TypeViewport.Front_2D_yz )
                Gl.glRotatef( -90, 0, 1, 0 );

            Gl.glColor3f( 0.5f, 0, 0 );
            Gl.glBegin( Gl.GL_LINES );

            for ( int i = -1024; i <= 1024; i += 512 )
            {
                Gl.glVertex3f( i, -1024, 0 );
                Gl.glVertex3f( i, 1024, 0 );

                Gl.glVertex3f( 1024, i, 0 );
                Gl.glVertex3f( -1024, i, 0 );
            }

            Gl.glEnd();

            Gl.glColor3f( colorGrid.R, colorGrid.G, colorGrid.B );
            Gl.glBegin( Gl.GL_LINES );

            for ( float i = -1024; i <= 1024; i += fSize )
            {
                Gl.glVertex3f( i, -1024, 0 );
                Gl.glVertex3f( i, 1024, 0 );

                Gl.glVertex3f( 1024, i, 0 );
                Gl.glVertex3f( -1024, i, 0 );
            }

            Gl.glEnd();

            Gl.glClear( Gl.GL_DEPTH_BUFFER_BIT );

            if ( type == TypeViewport.Top_2D_xy )
                Gl.glRotatef( -90, 1, 0, 0 );
            else if ( type == TypeViewport.Front_2D_yz )
                Gl.glRotatef( 90, 0, 1, 0 );
        }

        //-------------------------------------------------------------------------//

        public void SetTypeViewport( TypeViewport TypeViewport )
        {
            type = TypeViewport;
            LabelViewport.Text = type.ToString();

            if ( type == TypeViewport.Textured_3D )
            {
                vScrollBar.Visible = false;
                hScrollBar.Visible = false;
            }
            else
            {
                vScrollBar.Visible = true;
                hScrollBar.Visible = true;
            }

            View.Refresh();
            LabelViewport.Refresh();
        }

        //-------------------------------------------------------------------------//

        public static float fSize = 16f;
        public static Color colorGrid = new Color( 0.2f, 0.2f, 0.2f );

        public bool bEnabled = true;
        public float FactorZoom = 1;
        public static Viewport TmpViewport = null;
        public SimpleOpenGlControl View;
        public TypeViewport type;
        public Label LabelViewport;
        public Camera Camera = null;

        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;
    }

    //-------------------------------------------------------------------------//
}
