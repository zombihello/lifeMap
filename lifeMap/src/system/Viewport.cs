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
            this.View.InitializeContexts();
            LabelViewport = labeViewport;
            vScrollBar = scrollBarV;
            hScrollBar = scrollBarH;
        }

        //-------------------------------------------------------------------------//

        public Viewport( SimpleOpenGlControl View, TypeViewport TypeViewport, Label labeViewport, VScrollBar scrollBarV, HScrollBar scrollBarH )
        {
            this.View = View;
            this.View.InitializeContexts();
            type = TypeViewport;
            LabelViewport = labeViewport;
            LabelViewport.Text = type.ToString();
            vScrollBar = scrollBarV;
            hScrollBar = scrollBarH;

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

            //Инициализация PpenGL
            Gl.glLoadIdentity();
            Gl.glViewport( 0, 0, View.Width, View.Height );
            Gl.glOrtho( 0, View.Width, 0, View.Height, 0, View.Width );

            Gl.glClearColor( 0, 0, 0, 0 );
            Gl.glClear( Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT );

            if ( bEnabled )
                switch ( type )
                {
                    case TypeViewport.Front_2D_yz:
                        RenderGrid();
                        UpdateFront2D_YZ();
                        break;

                    case TypeViewport.Side_2D_xz:
                        RenderGrid();
                        UpdateSide2D_XZ();
                        break;

                    case TypeViewport.Top_2D_xy:
                        RenderGrid();
                        UpdateTop2D_XY();
                        break;

                    case TypeViewport.Textured_3D:
                        UpdateTextured_3D();
                        break;
                }
        }

        //-------------------------------------------------------------------------//

        private void UpdateFront2D_YZ()
        {
            for ( int i = 0; i < Brushes.Count; i++ )
                Brushes[i].Render( TypeViewport.Front_2D_yz );

                Brushes.Clear();

                Gl.glClear( Gl.GL_DEPTH_BUFFER_BIT );
        }

        //-------------------------------------------------------------------------//

        private void UpdateSide2D_XZ()
        {
            for ( int i = 0; i < Brushes.Count; i++ )
                Brushes[i].Render( TypeViewport.Side_2D_xz );

            Brushes.Clear();

            Gl.glClear( Gl.GL_DEPTH_BUFFER_BIT );
        }

        //-------------------------------------------------------------------------//

        private void UpdateTop2D_XY()
        {
            for ( int i = 0; i < Brushes.Count; i++ )
                Brushes[i].Render( TypeViewport.Top_2D_xy );

            Brushes.Clear();

            Gl.glClear( Gl.GL_DEPTH_BUFFER_BIT );
        }

        //-------------------------------------------------------------------------//

        private void UpdateTextured_3D()
        {
            for ( int i = 0; i < Brushes.Count; i++ )
                Brushes[i].Render( TypeViewport.Top_2D_xy );

            Brushes.Clear();

            Gl.glClear( Gl.GL_DEPTH_BUFFER_BIT );
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

        public void AddToRender( BasicBrush Brush )
        {
            Brushes.Add( Brush );
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

        public bool bEnabled = true;
        public static float fSize = 20f;
        public SimpleOpenGlControl View;
        public static Color colorGrid = new Color( 0, 0, 0.7f );
        public TypeViewport type;
        public Label LabelViewport;

        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;
        private List<BasicBrush> Brushes = new List<BasicBrush>();
    }

    //-------------------------------------------------------------------------//
}
