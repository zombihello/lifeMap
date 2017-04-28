using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src.system;

namespace lifeMap.src.brushes
{
    class BasicBrush
    {
        //-------------------------------------------------------------------------//

        public BasicBrush()
        {
            mPointsResize.Add( new PointsResize( this, Viewport.TypeViewport.Front_2D_yz ) );
            mPointsResize.Add( new PointsResize( this, Viewport.TypeViewport.Side_2D_xz ) );
            mPointsResize.Add( new PointsResize( this, Viewport.TypeViewport.Top_2D_xy ) );
        }

        //-------------------------------------------------------------------------//

        public virtual void Create( Vector3f StartPosition, Vector3f EndPosition ) { }

        //-------------------------------------------------------------------------//

        public void Render( Viewport.TypeViewport typeViewport )
        {
            RenderCenterBrush( typeViewport );

            if ( Mouse.BrushSelect == this && typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                for ( int i = 0; i < mPointsResize.Count; i++ )
                    if ( mPointsResize[i].typeViewport == typeViewport )
                        mPointsResize[i].Render();
            }

            Gl.glBegin( Gl.GL_LINES );
            Gl.glColor3f( ColorBrush.R, ColorBrush.G, ColorBrush.B );

            for ( int i = 0; i < mIdVertex.Count; i++ )
            {
                int id = mIdVertex[i];
                Gl.glVertex3f( mGlobalVertex[id].X, mGlobalVertex[id].Y, mGlobalVertex[id].Z );
            }

            Gl.glEnd();
        }

        //-------------------------------------------------------------------------//

        public void Move( Vector3f FactorMove, Viewport.TypeViewport typeViewport )
        {
            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Front_2D_yz:
                    Position.Y += Program.Align( FactorMove.Y, Viewport.fSize );
                    Position.Z += Program.Align( FactorMove.X, Viewport.fSize );
                    ToGloablCoords();
                    break;

                case Viewport.TypeViewport.Side_2D_xz:
                    Position.X += Program.Align( FactorMove.X, Viewport.fSize );
                    Position.Y += Program.Align( FactorMove.Y, Viewport.fSize );
                    ToGloablCoords();
                    break;

                case Viewport.TypeViewport.Top_2D_xy:
                    Position.X += Program.Align( FactorMove.X, Viewport.fSize );
                    Position.Z += Program.Align( FactorMove.Y, Viewport.fSize );
                    ToGloablCoords();
                    break;

                case Viewport.TypeViewport.Textured_3D:
                    break;
            }
        }

        //-------------------------------------------------------------------------//

        public void SetPosition( Vector3f position )
        {
            Position.X = Program.Align( position.X, Viewport.fSize );
            Position.Y = Program.Align( position.Y, Viewport.fSize );
            Position.Z = Program.Align( position.Z, Viewport.fSize );
            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        public void Resize( Vector3f FactorSize, Viewport.TypeViewport typeViewport )
        {
            FactorSize = Program.Align( FactorSize, Viewport.fSize );

            switch ( PointsResize.SelectPointType )
            {
                //----------------------------------------------------------//

                case PointsResize.PointType.BottomCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.Y -= FactorSize.Y;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, 0 ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.Z -= FactorSize.Y;
                        Position.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, 0, FactorSize.Y ), typeViewport );
                    }
                    break;


                //----------------------------------------------------------//

                case PointsResize.PointType.LeftBottom:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X -= FactorSize.X;
                        Size.Z -= FactorSize.Y;
                        Position.X += FactorSize.X;
                        Position.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z -= FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        Position.Z += FactorSize.X;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X -= FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        Position.X += FactorSize.X;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case PointsResize.PointType.LeftCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z -= FactorSize.X;
                        Position.Z += FactorSize.X;
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X -= FactorSize.X;
                        Position.X += FactorSize.X;
                    }

                    ResizeLocalVertex( new Vector3f( FactorSize.X, 0, 0 ), typeViewport );
                    break;

                //----------------------------------------------------------//

                case PointsResize.PointType.LeftTop:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X -= FactorSize.X;
                        Size.Z += FactorSize.Y;
                        Position.X += FactorSize.X;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z -= FactorSize.X;
                        Size.Y += FactorSize.Y;
                        Position.Z += FactorSize.X;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X -= FactorSize.X;
                        Size.Y += FactorSize.Y;
                        Position.X += FactorSize.X;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case PointsResize.PointType.RightBottom:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X += FactorSize.X;
                        Size.Z -= FactorSize.Y;
                        Position.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z += FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X += FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case PointsResize.PointType.RightCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        Size.Z += FactorSize.X;
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        Size.X += FactorSize.X;

                    ResizeLocalVertex( new Vector3f( FactorSize.X, 0, 0 ), typeViewport );
                    break;

                //----------------------------------------------------------//

                case PointsResize.PointType.RightTop:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X += FactorSize.X;
                        Size.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z += FactorSize.X;
                        Size.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X += FactorSize.X;
                        Size.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case PointsResize.PointType.TopCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, 0 ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, 0, FactorSize.Y ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//
            }


            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        private void RenderCenterBrush( Viewport.TypeViewport typeViewport )
        {
            if ( typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glColor3f( ColorBrush.R, ColorBrush.G, ColorBrush.B );

                Gl.glVertex3f( CenterBrush.X - 4, CenterBrush.Y - 4, CenterBrush.Z - 4 );
                Gl.glVertex3f( CenterBrush.X + 4, CenterBrush.Y + 4, CenterBrush.Z + 4 );

                if ( typeViewport != Viewport.TypeViewport.Front_2D_yz )
                {
                    Gl.glVertex3f( CenterBrush.X + 4, CenterBrush.Y - 4, CenterBrush.Z - 4 );
                    Gl.glVertex3f( CenterBrush.X - 4, CenterBrush.Y + 4, CenterBrush.Z + 4 );
                }
                else
                {
                    Gl.glVertex3f( CenterBrush.X + 4, CenterBrush.Y - 4, CenterBrush.Z + 4 );
                    Gl.glVertex3f( CenterBrush.X - 4, CenterBrush.Y + 4, CenterBrush.Z - 4 );
                }

                Gl.glEnd();
            }
        }

        //-------------------------------------------------------------------------//

        protected void InitBrush( Vector3f StartPosition, Vector3f EndPosition )
        {
            if ( StartPosition.X == 0 )
                StartPosition.X = Viewport.fSize;

            if ( StartPosition.Y == 0 )
                StartPosition.Y = Viewport.fSize;

            if ( StartPosition.Z == 0 )
                StartPosition.Z = Viewport.fSize;

            Position = Program.Align( StartPosition, Viewport.fSize );
            EndPosition = Program.Align( EndPosition, Viewport.fSize );

            Size.X = EndPosition.X - Position.X;
            Size.Y = EndPosition.Y - Position.Y;
            Size.Z = EndPosition.Z - Position.Z;

            if ( Size.X < 0 )
            {
                Position.X = EndPosition.X;
                Size.X = Program.Align( Math.Abs( Size.X ), Viewport.fSize );
            }

            if ( Size.Y < 0 )
            {
                Position.Y = EndPosition.Y;
                Size.Y = Program.Align( Math.Abs( Size.Y ), Viewport.fSize );
            }

            if ( Size.Z < 0 )
            {
                Position.Z = EndPosition.Z;
                Size.Z = Program.Align( Math.Abs( Size.Z ), Viewport.fSize );
            }
        }

        //-------------------------------------------------------------------------//

        protected void ToGloablCoords()
        {
            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                mGlobalVertex[i].X = mLocalVertex[i].Position.X + Position.X;
                mGlobalVertex[i].Y = mLocalVertex[i].Position.Y + Position.Y;
                mGlobalVertex[i].Z = mLocalVertex[i].Position.Z + Position.Z;
            }

            CenterBrush.X = Position.X + Size.X / 2;
            CenterBrush.Y = Position.Y + Size.Y / 2;
            CenterBrush.Z = Position.Z + Size.Z / 2;

            for ( int i = 0; i < mPointsResize.Count; i++ )
                mPointsResize[i].InitPoints( this, mPointsResize[i].typeViewport );
        }

        //-------------------------------------------------------------------------//

        private void ResizeLocalVertex( Vector3f FactorSize, Viewport.TypeViewport typeViewport )
        {
            bool IsUpdateVertexs =
                PointsResize.SelectPointType == PointsResize.PointType.LeftCenter ||
                PointsResize.SelectPointType == PointsResize.PointType.BottomCenter ||
                PointsResize.SelectPointType == PointsResize.PointType.LeftTop ||
                PointsResize.SelectPointType == PointsResize.PointType.LeftBottom ||
                PointsResize.SelectPointType == PointsResize.PointType.RightBottom;

            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                Vertex vertex = mLocalVertex[i];

                switch ( PointsResize.SelectPointType )
                {
                    //----------------------------------------------------------//

                    case PointsResize.PointType.LeftCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy ||
                             typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                vertex.Position.X += FactorSize.X;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                vertex.Position.Z += FactorSize.X;
                        }
                        break;

                    //----------------------------------------------------------//

                    case PointsResize.PointType.RightCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy ||
                            typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                            vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                vertex.Position.X += FactorSize.X;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                vertex.Position.Z += FactorSize.X;
                        }
                        break;

                    //----------------------------------------------------------//

                    case PointsResize.PointType.TopCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                    vertex.Position.Z += FactorSize.Z;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop || 
                                 vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop || 
                                 vertex.typeVertex == Vertex.TypeVertex.RightTop || 
                                 vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Position.Y += FactorSize.Y;
                        break;

                    //----------------------------------------------------------//

                    case PointsResize.PointType.BottomCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                 vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                 vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                 vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Position.Z += FactorSize.Z;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom || 
                                 vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom || 
                                 vertex.typeVertex == Vertex.TypeVertex.RightBottom || 
                                 vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                    vertex.Position.Y += FactorSize.Y;
                        break;

                    //----------------------------------------------------------//

                    case PointsResize.PointType.LeftTop:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                        vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                        vertex.Position.Z += FactorSize.Z;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Z += FactorSize.Z;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                        vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        break;

                    //----------------------------------------------------------//

                    case PointsResize.PointType.LeftBottom:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                        vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Z += FactorSize.Z;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Z += FactorSize.Z;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        break;

                    //----------------------------------------------------------//

                    case PointsResize.PointType.RightTop:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                        vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                        vertex.Position.Z += FactorSize.Z;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                        vertex.Position.Z += FactorSize.Z;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                        vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        break;

                    //----------------------------------------------------------//

                    case PointsResize.PointType.RightBottom:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                    vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                        vertex.Position.Z += FactorSize.Z;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                    vertex.Position.Z += FactorSize.Z;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                    vertex.Position.X += FactorSize.X;

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Y += FactorSize.Y;
                        }
                        break;

                    //----------------------------------------------------------//
                }
            }

            //-----------------------------------------------------------------------------//

            if ( IsUpdateVertexs )
                for ( int i = 0; i < mLocalVertex.Count; i++ )
                {
                    Vertex vertex = mLocalVertex[i];

                    switch ( PointsResize.SelectPointType )
                    {
                        //----------------------------------------------------------//

                        case PointsResize.PointType.LeftCenter:
                            if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                 vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                if ( typeViewport != Viewport.TypeViewport.Front_2D_yz )
                                    vertex.Position.X -= FactorSize.X;
                                else
                                    vertex.Position.Z -= FactorSize.X;
                            break;

                        //----------------------------------------------------------//

                        case PointsResize.PointType.BottomCenter:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftTop )
                                    vertex.Position.Z -= FactorSize.Z;
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Position.Y -= FactorSize.Y;
                            }
                            break;

                        //----------------------------------------------------------//

                        case PointsResize.PointType.LeftTop:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom )
                                        vertex.Position.X -= FactorSize.X;
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Z -= FactorSize.Z;
                            }
                            break;

                        //----------------------------------------------------------//

                        case PointsResize.PointType.LeftBottom:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom )
                                        vertex.Position.X -= FactorSize.X;

                                if ( vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftTop )
                                    vertex.Position.Z -= FactorSize.Z;
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Z -= FactorSize.Z;

                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Y -= FactorSize.Y;
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom )
                                        vertex.Position.X -= FactorSize.X;

                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                        vertex.Position.Y -= FactorSize.Y;
                            }
                            break;

                        //----------------------------------------------------------//

                        case PointsResize.PointType.RightBottom:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftTop )
                                    vertex.Position.Z -= FactorSize.Z;
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Position.Y -= FactorSize.Y;
                            }
                            break;

                        //----------------------------------------------------------//
                    }
                }

            //-----------------------------------------------------------------------------//
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( Vector3f PositionVertex, Vertex.TypeVertex type )
        {
            mLocalVertex.Add( new Vertex( PositionVertex, type ) );
            mGlobalVertex.Add( PositionVertex );
        }

        //-------------------------------------------------------------------------//

        protected void AddVertex( float x, float y, float z, Vertex.TypeVertex type )
        {
            mLocalVertex.Add( new Vertex( x, y, z, type ) );
            mGlobalVertex.Add( new Vector3f( x, y, z ) );
        }

        //-------------------------------------------------------------------------//

        protected void AddIdVertex( int id )
        {
            mIdVertex.Add( id );
        }

        //-------------------------------------------------------------------------//

        public void SetColorBrush( Color color )
        {
            ColorBrush = color;
        }

        //-------------------------------------------------------------------------//

        public void SetDefaultColorBrush( Color color )
        {
            DefaultColorBrush = color;
        }

        //-------------------------------------------------------------------------//

        public Vector3f CenterBrush = new Vector3f();
        public Vector3f Size = new Vector3f();
        public Vector3f Position = new Vector3f();
        public Color DefaultColorBrush = new Color( 1, 0, 0 );
        public List<PointsResize> mPointsResize = new List<PointsResize>();

        protected Color ColorBrush = new Color( 1, 0, 0 );

        private List<Vertex> mLocalVertex = new List<Vertex>();
        private List<Vector3f> mGlobalVertex = new List<Vector3f>();
        private List<int> mIdVertex = new List<int>();
    }
}
