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

            //Инициализация OpenGL
            Gl.glMatrixMode( Gl.GL_PROJECTION );
            Gl.glLoadIdentity();
            Gl.glViewport( 0, 0, View.Width, View.Height );

            if ( type != TypeViewport.Textured_3D )
                Gl.glOrtho( 0, View.Width, 0, View.Height, -View.Width, View.Width ); // TODO: Сделать зум вьюпорта
            else
            {
                Glu.gluPerspective( 45f, ( float )View.Width / ( float )View.Height, 0.1f, 1000.0f );
                Scene.WorldCamera.SetPosition( Scene.WorldCamera.Position );
            }

            Gl.glMatrixMode( Gl.GL_MODELVIEW );
            Gl.glLoadIdentity();

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT );

            if ( bEnabled )
            {
                if ( type != TypeViewport.Textured_3D )
                {
                    Camera.Update( type );
                    RenderGrid();
                    Camera.RenderCamera();
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

            Gl.glColor3f( colorGrid.R, colorGrid.G, colorGrid.B );

            for ( int i = -1000; i < 1000; i++ )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glVertex3f( i * fSize, -1000, 0 );
                Gl.glVertex3f( i * fSize, 1000, 0 );
                Gl.glEnd();
            }

            for ( int i = -1000; i < 1000; i++ )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glVertex3f( -1000, i * fSize, 0 );
                Gl.glVertex3f( 1000, i * fSize, 0 );
                Gl.glEnd();
            }

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

        public static float fSize = 20f;
        public static Color colorGrid = new Color( 0.2f, 0.2f, 0.2f );

        public bool bEnabled = true;
        public SimpleOpenGlControl View;
        public TypeViewport type;
        public Label LabelViewport;
        public Camera Camera = null;

        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;
    }

    //-------------------------------------------------------------------------//
}
