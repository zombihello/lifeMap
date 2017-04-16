using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src.system;
using lifeMap.src.brushes;

namespace lifeMap.src.system
{
    static class Scene
    {
        //-------------------------------------------------------------------------//

        public static void UpdateScene( Viewport.TypeViewport typeViewport )
        {
            RenderXYZ();

            if ( BrushSelect != null )
                BrushSelect.Render( typeViewport );

            for ( int i = 0; i < mBrush.Count; i++ )
                mBrush[i].Render( typeViewport );
        }

        //-------------------------------------------------------------------------//

        private static void RenderXYZ()
        {
            Gl.glBegin( Gl.GL_LINES );
            Gl.glColor3f( 1, 0, 0 );
            Gl.glVertex3f( 0, 0, 0 );
            Gl.glVertex3f( 100, 0, 0 );

            Gl.glColor3f( 0, 1, 0 );
            Gl.glVertex3f( 0, 0, 0 );
            Gl.glVertex3f( 0, 100, 0 );

            Gl.glColor3f( 0, 0, 1 );
            Gl.glVertex3f( 0, 0, 0 );
            Gl.glVertex3f( 0, 0, 100 );
            Gl.glEnd();
        }

        //-------------------------------------------------------------------------//

        public static void SetBrushSelect( BrushSelect brushSelect )
        {
            BrushSelect = brushSelect;
        }

        //-------------------------------------------------------------------------//

        public static void AddBrush( BasicBrush brush )
        {
            mBrush.Add( brush );
        }

        //-------------------------------------------------------------------------//

        public static void Clear()
        {
            mBrush.Clear();
            BrushSelect = null;
        }

        //-------------------------------------------------------------------------//

        public static void ClearBrushSelect()
        {
            BrushSelect = null;
        }

        //-------------------------------------------------------------------------//

        public static BrushSelect GetBrushSelect()
        {
            return BrushSelect;
        }

        //-------------------------------------------------------------------------//

        private static BrushSelect BrushSelect = null;
        private static List<BasicBrush> mBrush = new List<BasicBrush>();

        //-------------------------------------------------------------------------//
    }
}
