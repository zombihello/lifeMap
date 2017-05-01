﻿using System;
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

        public static void UpdatePosition( Vector3f position, float AlignValue = 0 )
        {
            OldPosition = Position;

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
            OldPosition = Position;

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
            if ( IsSelectBrush && BrushSelect != null )
            {
                Vector3f PositionCursor = Program.ToNewCoords( camera.Position, Position );

                switch ( TypeViewport )
                {
                    case Viewport.TypeViewport.Top_2D_xy:
                        if ( PositionCursor.X > ( BrushSelect.CenterBrush.X + Math.Abs( ManagerPoints.Size.X ) ) + 5 ||
                            PositionCursor.X < ( BrushSelect.CenterBrush.X - Math.Abs( ManagerPoints.Size.X ) ) - 5 ||
                            PositionCursor.Y > ( BrushSelect.CenterBrush.Z + Math.Abs( ManagerPoints.Size.Z ) ) + 5 ||
                            PositionCursor.Y < ( BrushSelect.CenterBrush.Z - Math.Abs( ManagerPoints.Size.Z ) ) - 5 )
                            IsSelectBrush = false;
                        break;

                    case Viewport.TypeViewport.Front_2D_yz:
                        if ( PositionCursor.X > ( BrushSelect.CenterBrush.Z + Math.Abs( ManagerPoints.Size.Z ) ) + 5 ||
                             PositionCursor.X < ( BrushSelect.CenterBrush.Z - Math.Abs( ManagerPoints.Size.Z ) ) - 5 ||
                             PositionCursor.Y > ( BrushSelect.CenterBrush.Y + Math.Abs( ManagerPoints.Size.Y ) ) + 5 ||
                             PositionCursor.Y < ( BrushSelect.CenterBrush.Y - Math.Abs( ManagerPoints.Size.Y ) ) - 5 )
                            IsSelectBrush = false;
                        break;

                    case Viewport.TypeViewport.Side_2D_xz:
                        if ( PositionCursor.X > ( BrushSelect.CenterBrush.X + Math.Abs( ManagerPoints.Size.X ) ) + 5 ||
                             PositionCursor.X < ( BrushSelect.CenterBrush.X - Math.Abs( ManagerPoints.Size.X ) ) - 5 ||
                             PositionCursor.Y > ( BrushSelect.CenterBrush.Y + Math.Abs( ManagerPoints.Size.Y ) ) + 5 ||
                             PositionCursor.Y < ( BrushSelect.CenterBrush.Y - Math.Abs( ManagerPoints.Size.Y ) ) - 5 )
                            IsSelectBrush = false;
                        break;
                }

                if ( !IsSelectBrush )
                {
                    BrushSelect.SetColorBrush( BrushSelect.DefaultColorBrush );
                    ManagerPoints.FactorSize = 0;
                    BrushSelect = null;
                }

            }
            else
                if ( IsSelectBrush && BrushSelect == null )
                {
                    IsSelectBrush = false;
                    ManagerPoints.FactorSize = 0;
                }

            ClickPosition = Position;
            TypeViewportClicked = TypeViewport;
            IsDoubleClick = false;
            IsClick = true;
        }

        //-------------------------------------------------------------------------//

        public static void RemoveClick()
        {
            if ( IsSelectBrush && typeSelectBrush != TypeSelectBrush.Move )
            {
                BrushSelect.UpdateVertex();
                typeSelectBrush = TypeSelectBrush.Move;
            }

            ClickPosition = new Vector3f();
            TypeViewportClicked = Viewport.TypeViewport.None;
            IsClick = false;
        }

        //-------------------------------------------------------------------------//

        public static bool IsClick = false;
        public static bool IsSelectBrush = false;
        public static bool IsDoubleClick = false;

        public static Viewport.TypeViewport TypeViewportClicked = Viewport.TypeViewport.None;
        public static TypeSelectBrush typeSelectBrush = TypeSelectBrush.None;
        public static BasicBrush BrushSelect = null;
        public static Vector3f OldPosition = new Vector3f();
        public static Vector3f Position = new Vector3f( 0, 0, 0 );
        public static Vector3f ClickPosition = new Vector3f();
    }

    //-------------------------------------------------------------------------//
}
