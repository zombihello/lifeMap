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

namespace lifeMap.src
{
    //-------------------------------------------------------------------------//

    static class Mouse
    {
        //-------------------------------------------------------------------------//

        public enum TypeSelectBrush
        {
            None,
            Move,
            Resize,
            Rotate
        };

        //-------------------------------------------------------------------------//

        public static void UpdatePosition( Vector3f position, float FactorZoom = 0, float AlignValue = 0 )
        {
            OldPosition = Position;

            if ( FactorZoom > 0 )
                position *= FactorZoom;
            else if ( FactorZoom < 0 )
                position /= Math.Abs( FactorZoom );


            if ( AlignValue != 0 )
                Position = new Vector3f( Program.Align( position.X, AlignValue ), Program.Align( position.Y, AlignValue ), 0 );
            else
                Position = position;

            if ( !IsClick )
                RemoveClick();
        }

        //-------------------------------------------------------------------------//

        public static void UpdatePosition( float x, float y, float FactorZoom = 0, float AlignValue = 0 )
        {
            OldPosition = Position;

            if ( FactorZoom > 0 )
            {
                x *= FactorZoom;
                y *= FactorZoom;
            }
            else if ( FactorZoom < 0 )
            {
                x /= Math.Abs( FactorZoom );
                y /= Math.Abs( FactorZoom );
            }

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

        public static void SetClick( Viewport.TypeViewport TypeViewport, Camera camera )
        {
            if ( IsSelect && BrushSelect != null )
            {
                Vector3f PositionCursor = Program.ToNewCoords( camera.Position, Position );

                float factorSize = 4;

                if ( Viewport.TmpViewport.FactorZoom > 0 )
                    factorSize *= Viewport.TmpViewport.FactorZoom;
                else
                    factorSize /= Viewport.TmpViewport.FactorZoom;

                switch ( TypeViewport )
                {
                    case Viewport.TypeViewport.Top_2D_xz:
                        if ( PositionCursor.X > ( BrushSelect.CenterBrush.X + Math.Abs( ManagerPoints.FactorShift.X ) ) + factorSize ||
                            PositionCursor.X < ( BrushSelect.CenterBrush.X - Math.Abs( ManagerPoints.FactorShift.X ) ) - factorSize ||
                            PositionCursor.Y > ( BrushSelect.CenterBrush.Z + Math.Abs( ManagerPoints.FactorShift.Z ) ) + factorSize ||
                            PositionCursor.Y < ( BrushSelect.CenterBrush.Z - Math.Abs( ManagerPoints.FactorShift.Z ) ) - factorSize )
                            IsSelect = false;
                        break;

                    case Viewport.TypeViewport.Front_2D_yz:
                        if ( PositionCursor.X > ( BrushSelect.CenterBrush.Z + Math.Abs( ManagerPoints.FactorShift.Z ) ) + factorSize ||
                             PositionCursor.X < ( BrushSelect.CenterBrush.Z - Math.Abs( ManagerPoints.FactorShift.Z ) ) - factorSize ||
                             PositionCursor.Y > ( BrushSelect.CenterBrush.Y + Math.Abs( ManagerPoints.FactorShift.Y ) ) + factorSize ||
                             PositionCursor.Y < ( BrushSelect.CenterBrush.Y - Math.Abs( ManagerPoints.FactorShift.Y ) ) - factorSize )
                            IsSelect = false;
                        break;

                    case Viewport.TypeViewport.Side_2D_xy:
                        if ( PositionCursor.X > ( BrushSelect.CenterBrush.X + Math.Abs( ManagerPoints.FactorShift.X ) ) + factorSize ||
                             PositionCursor.X < ( BrushSelect.CenterBrush.X - Math.Abs( ManagerPoints.FactorShift.X ) ) - factorSize ||
                             PositionCursor.Y > ( BrushSelect.CenterBrush.Y + Math.Abs( ManagerPoints.FactorShift.Y ) ) + factorSize ||
                             PositionCursor.Y < ( BrushSelect.CenterBrush.Y - Math.Abs( ManagerPoints.FactorShift.Y ) ) - factorSize )
                            IsSelect = false;
                        break;
                }

                if ( !IsSelect )
                {
                    BrushSelect.SetColorBrush( BrushSelect.DefaultColorBrush );
                    BrushSelect = null;
                }

            }
            else
                if ( IsSelect && BrushSelect == null )
                    IsSelect = false;

            ClickPosition = Position;
            TypeViewportClicked = TypeViewport;
            IsDoubleClick = false;
            IsClick = true;
        }

        //-------------------------------------------------------------------------//

        public static void RemoveClick()
        {
            if ( IsSelect && typeSelect != TypeSelectBrush.Move )
            {
                BrushSelect.UpdateVertex();
                typeSelect = TypeSelectBrush.Move;
            }

            ClickPosition = new Vector3f();
            TypeViewportClicked = Viewport.TypeViewport.None;
            IsClick = false;
        }

        //-------------------------------------------------------------------------//

        public static bool IsClick = false;
        public static bool IsSelect = false;
        public static bool IsDoubleClick = false;

        public static Viewport.TypeViewport TypeViewportClicked = Viewport.TypeViewport.None;
        public static TypeSelectBrush typeSelect = TypeSelectBrush.None;
        public static BasicBrush BrushSelect = null;
        public static Entity EntitySelect = null;
        public static Vector3f OldPosition = new Vector3f();
        public static Vector3f Position = new Vector3f( 0, 0, 0 );
        public static Vector3f ClickPosition = new Vector3f();
    }

    //-------------------------------------------------------------------------//
}
