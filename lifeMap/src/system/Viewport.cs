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
            Gl.glOrtho( 0, View.Width, 0, View.Height, -View.Width, View.Width );

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT );

            if ( bEnabled )
            {
                //Camera.Update( type );

                if ( type != TypeViewport.Textured_3D )
                    RenderGrid();

                Scene.UpdateScene( type );
            }
        }

        //-------------------------------------------------------------------------//

        private void RenderGrid()
        {
            Gl.glColor3f( colorGrid.R, colorGrid.G, colorGrid.B );

            for ( int i = 0; i < View.Width; i++ )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glVertex2f( i * fSize, 0 );
                Gl.glVertex2f( i * fSize, View.Height );
                Gl.glEnd();
            }

            for ( int i = 0; i < View.Height; i++ )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glVertex2f( 0, i * fSize );
                Gl.glVertex2f( View.Width, i * fSize );
                Gl.glEnd();
            }

            Gl.glClear( Gl.GL_DEPTH_BUFFER_BIT );
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

        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;
        private Camera Camera = null;
    }

    //-------------------------------------------------------------------------//
}
