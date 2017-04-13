using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

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

        public Viewport( SimpleOpenGlControl View )
        {
            this.View = View;
            this.View.InitializeContexts();
        }

        //-------------------------------------------------------------------------//

        public Viewport( SimpleOpenGlControl View, TypeViewport TypeViewport )
        {
            this.View = View;
            this.View.InitializeContexts();
            type = TypeViewport;
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
                        break;

                    case TypeViewport.Side_2D_xz:
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
                        break;

                    case TypeViewport.Top_2D_xy:
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
                        break;

                    case TypeViewport.Textured_3D:
                        break;
                }
        }

        //-------------------------------------------------------------------------//

        public void SetSizeGrid( float size )
        {
            fSize = size;
        }

        //-------------------------------------------------------------------------//

        public void SetColorGrid( float r, float g, float b )
        {
            colorGrid.R = r;
            colorGrid.G = g;
            colorGrid.B = b;
        }

        //-------------------------------------------------------------------------//

        public void SetColorGrid( Color color )
        {
            colorGrid = color;
        }

        //-------------------------------------------------------------------------//

        public void SetTypeViewport( TypeViewport TypeViewport )
        {
            type = TypeViewport;
        }

        //-------------------------------------------------------------------------//

        public bool bEnabled = true;

        private float fSize = 20f;
        private TypeViewport type;
        private Color colorGrid = new Color( 0, 0, 0.7f );
        private SimpleOpenGlControl View;
    }

    //-------------------------------------------------------------------------//
}
