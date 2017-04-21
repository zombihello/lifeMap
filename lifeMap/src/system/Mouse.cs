using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lifeMap.src.system;
using lifeMap.src.brushes;

namespace lifeMap.src
{
    //-------------------------------------------------------------------------//

    static class Mouse
    {
        //-------------------------------------------------------------------------//

        public static void UpdatePosition( Vector3f position, float AlignValue = 0 )
        {
            if ( AlignValue != 0 )
                Position = new Vector3f( Program.Align( position.X, AlignValue ), Program.Align( position.Y, AlignValue ), 0 );
            else
                Position = position;

            if ( !IsClick )
                RemoveClick();
        }

        //-------------------------------------------------------------------------//

        public static void UpdatePosition( float x, float y, float AlignValue = 0 )
        {
            if ( AlignValue != 0 )
                Position = new Vector3f( Program.Align( x, AlignValue ), Program.Align( y, AlignValue ), 0 );
            else
                Position = new Vector3f( x, y, 0 );

            if ( !IsClick )
                RemoveClick();
        }

        //-------------------------------------------------------------------------//

        public static void SetClick()
        {
            ClickPosition = Position;
            IsClick = true;
        }

        //-------------------------------------------------------------------------//

        public static void SetClick( Viewport.TypeViewport Type )
        {
            ClickPosition = Position;
            TypeViewportClicked = Type;
            IsClick = true;
        }

        //-------------------------------------------------------------------------//

        public static void RemoveClick()
        {
            if ( IsSelectBrush )
            {
                IsSelectBrush = false;
                BrushSelect.SetColorBrush( BrushSelect.DefaultColorBrush );
                BrushSelect = null;
            }

            ClickPosition = new Vector3f();
            TypeViewportClicked = Viewport.TypeViewport.None;
            IsClick = false;    
        }

        //-------------------------------------------------------------------------//

        public static bool IsClick = false;
        public static bool IsSelectBrush = false;

        public static Viewport.TypeViewport TypeViewportClicked = Viewport.TypeViewport.None;
        public static BasicBrush BrushSelect = null;
        public static Vector3f Position = new Vector3f();
        public static Vector3f ClickPosition = new Vector3f();
    }

    //-------------------------------------------------------------------------//
}
