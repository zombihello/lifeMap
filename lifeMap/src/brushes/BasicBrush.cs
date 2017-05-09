using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

using lifeMap.src.system;

namespace lifeMap.src.brushes
{
    class BasicBrush
    {
        //-------------------------------------------------------------------------//

        public enum PrimitivesType
        {
            Cube,
            Sphere,
            Plane
        };

        //-------------------------------------------------------------------------//

        public virtual void Create( Vector3f StartPosition, Vector3f EndPosition ) { }

        //-------------------------------------------------------------------------//

        public void Render( Viewport.TypeViewport typeViewport )
        {
            RenderCenterBrush( typeViewport );

            if ( typeViewport != Viewport.TypeViewport.Textured_3D )
            {
                Gl.glBegin( Gl.GL_LINES );
                Gl.glColor3f( ColorBrush.R, ColorBrush.G, ColorBrush.B );

                for ( int i = 0; i < mIdVertex_Lines.Count; i++ )
                {
                    int id = mIdVertex_Lines[ i ];
                    Gl.glVertex3f( mGlobalVertex[ id ].X, mGlobalVertex[ id ].Y, mGlobalVertex[ id ].Z );
                }
            }
            else
            {
                TextureBrush.SelectTexture( Gl.GL_TEXTURE_2D );

                if ( Mouse.BrushSelect != this )
                    Gl.glColor4f( 1, 1, 1, 1 );
                else
                    Gl.glColor4f( 1, 0, 0, 0.5f );

                Gl.glBegin( Gl.GL_TRIANGLES );

                for ( int i = 0; i < mIdVertex_Triangles.Count; i++ )
                {
                    int id = mIdVertex_Triangles[ i ];
                    Gl.glTexCoord2f( mTextureCoord[ i ].X, mTextureCoord[ i ].Y );
                    Gl.glVertex3f( mGlobalVertex[ id ].X, mGlobalVertex[ id ].Y, mGlobalVertex[ id ].Z );
                }
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

            switch ( ManagerPoints.SelectPointType )
            {
                //----------------------------------------------------------//

                case Points.PointType.BottomCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.Y -= FactorSize.Y;
                        ManagerPoints.Size.Y -= FactorSize.Y / 2;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, 0 ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.Z -= FactorSize.Y;
                        ManagerPoints.Size.Z -= FactorSize.Y / 2;
                        Position.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, 0, FactorSize.Y ), typeViewport );
                    }
                    break;


                //----------------------------------------------------------//

                case Points.PointType.LeftBottom:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X -= FactorSize.X;
                        Size.Z -= FactorSize.Y;
                        ManagerPoints.Size.X -= FactorSize.X / 2;
                        ManagerPoints.Size.Z -= FactorSize.Y / 2;
                        Position.X += FactorSize.X;
                        Position.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z -= FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        ManagerPoints.Size.Z -= FactorSize.X / 2;
                        ManagerPoints.Size.Y -= FactorSize.Y / 2;
                        Position.Z += FactorSize.X;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X -= FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        ManagerPoints.Size.X -= FactorSize.X / 2;
                        ManagerPoints.Size.Y -= FactorSize.Y / 2;
                        Position.X += FactorSize.X;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case Points.PointType.LeftCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z -= FactorSize.X;
                        ManagerPoints.Size.Z -= FactorSize.X / 2;
                        Position.Z += FactorSize.X;
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X -= FactorSize.X;
                        ManagerPoints.Size.X -= FactorSize.X / 2;
                        Position.X += FactorSize.X;
                    }

                    ResizeLocalVertex( new Vector3f( FactorSize.X, 0, 0 ), typeViewport );
                    break;

                //----------------------------------------------------------//

                case Points.PointType.LeftTop:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X -= FactorSize.X;
                        Size.Z += FactorSize.Y;
                        ManagerPoints.Size.X -= FactorSize.X / 2;
                        ManagerPoints.Size.Z += FactorSize.Y / 2;
                        Position.X += FactorSize.X;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z -= FactorSize.X;
                        Size.Y += FactorSize.Y;
                        ManagerPoints.Size.Z -= FactorSize.X / 2;
                        ManagerPoints.Size.Y += FactorSize.Y / 2;
                        Position.Z += FactorSize.X;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X -= FactorSize.X;
                        Size.Y += FactorSize.Y;
                        ManagerPoints.Size.X -= FactorSize.X / 2;
                        ManagerPoints.Size.Y += FactorSize.Y / 2;
                        Position.X += FactorSize.X;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case Points.PointType.RightBottom:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X += FactorSize.X;
                        Size.Z -= FactorSize.Y;
                        ManagerPoints.Size.X += FactorSize.X / 2;
                        ManagerPoints.Size.Z -= FactorSize.Y / 2;
                        Position.Z += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z += FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        ManagerPoints.Size.Z += FactorSize.X / 2;
                        ManagerPoints.Size.Y -= FactorSize.Y / 2;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X += FactorSize.X;
                        Size.Y -= FactorSize.Y;
                        ManagerPoints.Size.X += FactorSize.X / 2;
                        ManagerPoints.Size.Y -= FactorSize.Y / 2;
                        Position.Y += FactorSize.Y;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case Points.PointType.RightCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z += FactorSize.X;
                        ManagerPoints.Size.Z += FactorSize.X / 2;
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X += FactorSize.X;
                        ManagerPoints.Size.X += FactorSize.X / 2;
                    }

                    ResizeLocalVertex( new Vector3f( FactorSize.X, 0, 0 ), typeViewport );
                    break;

                //----------------------------------------------------------//

                case Points.PointType.RightTop:
                    if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.X += FactorSize.X;
                        Size.Z += FactorSize.Y;
                        ManagerPoints.Size.X += FactorSize.X / 2;
                        ManagerPoints.Size.Z += FactorSize.Y / 2;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, 0, FactorSize.Y ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                    {
                        Size.Z += FactorSize.X;
                        Size.Y += FactorSize.Y;
                        ManagerPoints.Size.Z += FactorSize.X / 2;
                        ManagerPoints.Size.Y += FactorSize.Y / 2;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, FactorSize.X ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.X += FactorSize.X;
                        Size.Y += FactorSize.Y;
                        ManagerPoints.Size.X += FactorSize.X / 2;
                        ManagerPoints.Size.Y += FactorSize.Y / 2;
                        ResizeLocalVertex( new Vector3f( FactorSize.X, FactorSize.Y, 0 ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//

                case Points.PointType.TopCenter:
                    if ( typeViewport == Viewport.TypeViewport.Front_2D_yz || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                    {
                        Size.Y += FactorSize.Y;
                        ManagerPoints.Size.Y += FactorSize.Y / 2;
                        ResizeLocalVertex( new Vector3f( 0, FactorSize.Y, 0 ), typeViewport );
                    }
                    else if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                    {
                        Size.Z += FactorSize.Y;
                        ManagerPoints.Size.Z += FactorSize.Y / 2;
                        ResizeLocalVertex( new Vector3f( 0, 0, FactorSize.Y ), typeViewport );
                    }
                    break;

                //----------------------------------------------------------//
            }

            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        public void Rotate( Viewport viewport, Viewport.TypeViewport typeViewport )
        {
            Vector3f MousePosition = Program.ToNewCoords( viewport.Camera.Position, Mouse.Position );

            float dX = 0;
            float dY = 0;
            float Angle = 0;

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Top_2D_xy:
                    dX = MousePosition.X - CenterBrush.X;
                    dY = MousePosition.Y - CenterBrush.Z;

                    Angle = ( float ) Math.Atan2( dY, dX );

                    for ( int i = 0; i < mLocalVertex.Count; i++ )
                    {
                        Vector3f CenterRotate = new Vector3f( mLocalVertex[ i ].DefaultPosition.X - Size.X / 2, mLocalVertex[ i ].DefaultPosition.Z - Size.Z / 2, 0 );

                        mLocalVertex[ i ].Position.X = CenterRotate.X * ( float ) Math.Cos( Angle ) - CenterRotate.Y * ( float ) Math.Sin( Angle ) + Size.X / 2;
                        mLocalVertex[ i ].Position.Z = CenterRotate.X * ( float ) Math.Sin( Angle ) + CenterRotate.Y * ( float ) Math.Cos( Angle ) + Size.Z / 2;
                    }

                    break;

                case Viewport.TypeViewport.Front_2D_yz:
                    dX = MousePosition.X - CenterBrush.Z;
                    dY = MousePosition.Y - CenterBrush.Y;

                    Angle = ( float ) Math.Atan2( dY, dX );

                    for ( int i = 0; i < mLocalVertex.Count; i++ )
                    {
                        Vector3f CenterRotate = new Vector3f( mLocalVertex[ i ].DefaultPosition.Z - Size.Z / 2, mLocalVertex[ i ].DefaultPosition.Y - Size.Y / 2, 0 );

                        mLocalVertex[ i ].Position.Z = CenterRotate.X * ( float ) Math.Cos( Angle ) - CenterRotate.Y * ( float ) Math.Sin( Angle ) + Size.Z / 2;
                        mLocalVertex[ i ].Position.Y = CenterRotate.X * ( float ) Math.Sin( Angle ) + CenterRotate.Y * ( float ) Math.Cos( Angle ) + Size.Y / 2;
                    }

                    break;

                case Viewport.TypeViewport.Side_2D_xz:
                    dX = MousePosition.X - CenterBrush.X;
                    dY = MousePosition.Y - CenterBrush.Y;

                    Angle = ( float ) Math.Atan2( dY, dX );

                    for ( int i = 0; i < mLocalVertex.Count; i++ )
                    {
                        Vector3f CenterRotate = new Vector3f( mLocalVertex[ i ].DefaultPosition.X - Size.X / 2, mLocalVertex[ i ].DefaultPosition.Y - Size.Y / 2, 0 );

                        mLocalVertex[ i ].Position.X = CenterRotate.X * ( float ) Math.Cos( Angle ) - CenterRotate.Y * ( float ) Math.Sin( Angle ) + Size.X / 2;
                        mLocalVertex[ i ].Position.Y = CenterRotate.X * ( float ) Math.Sin( Angle ) + CenterRotate.Y * ( float ) Math.Cos( Angle ) + Size.Y / 2;
                    }

                    break;
            }

            UpdateSelectPoints();
            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        private void UpdateSelectPoints()
        {
            Vector3f MaxVertex = new Vector3f();
            Vector3f MinVertex = new Vector3f();

            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                if ( i == 0 )
                {
                    MaxVertex = new Vector3f( mLocalVertex[ i ].Position );
                    MinVertex = new Vector3f( mLocalVertex[ i ].Position );
                }
                else
                {

                    if ( mLocalVertex[ i ].Position.Y > MaxVertex.Y )
                        MaxVertex.Y = mLocalVertex[ i ].Position.Y;

                    if ( mLocalVertex[ i ].Position.X > MaxVertex.X )
                        MaxVertex.X = mLocalVertex[ i ].Position.X;

                    if ( mLocalVertex[ i ].Position.Z > MaxVertex.Z )
                        MaxVertex.Z = mLocalVertex[ i ].Position.Z;

                    if ( mLocalVertex[ i ].Position.Y < MinVertex.Y )
                        MinVertex.Y = mLocalVertex[ i ].Position.Y;

                    if ( mLocalVertex[ i ].Position.X < MinVertex.X )
                        MinVertex.X = mLocalVertex[ i ].Position.X;

                    if ( mLocalVertex[ i ].Position.Z < MinVertex.Z )
                        MinVertex.Z = mLocalVertex[ i ].Position.Z;
                }
            }

            SelectSize = ( MaxVertex - MinVertex ) / 2;
            ManagerPoints.Size = SelectSize;
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

        protected void InitBrush( Vector3f StartPosition, Vector3f EndPosition, PrimitivesType Type, Texture texture = null )
        {
            this.Type = Type;

            if ( texture != null )
                TextureBrush = new Texture( texture );

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

            SelectSize = new Vector3f( Size / 2 );
            InitIdVertex( Type );
        }

        //-------------------------------------------------------------------------//

        protected void InitBrush( SaveBrush saveBrush, PrimitivesType Type )
        {
            InitIdVertex( Type );
            Position = saveBrush.Position;
            Size = saveBrush.Size;

            for ( int i = 0; i < ManagerTexture.mTextures.Count; i++ )
                if ( ManagerTexture.mTextures[ i ].Name == saveBrush.TextureName )
                    TextureBrush = new Texture( ManagerTexture.mTextures[ i ] );

            mLocalVertex = saveBrush.LocalVertex;
            mTextureCoord = saveBrush.TextureCoords;

            CenterBrush = Position + Size / 2;

            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                mGlobalVertex.Add( new Vector3f( mLocalVertex[ i ].Position ) );
                mGlobalVertex[ i ] = mLocalVertex[ i ].Position + Position;
            }

            UpdateSelectPoints();
        }

        //-------------------------------------------------------------------------//

        protected void ToGloablCoords()
        {
            for ( int i = 0; i < mLocalVertex.Count; i++ )
                mGlobalVertex[ i ] = mLocalVertex[ i ].Position + Position;

            CenterBrush = Position + Size / 2;
        }

        //-------------------------------------------------------------------------//

        private void ResizeLocalVertex( Vector3f FactorSize, Viewport.TypeViewport typeViewport )
        {
            bool IsUpdateVertexs =
                ManagerPoints.SelectPointType == Points.PointType.LeftCenter ||
                ManagerPoints.SelectPointType == Points.PointType.BottomCenter ||
                ManagerPoints.SelectPointType == Points.PointType.LeftTop ||
                ManagerPoints.SelectPointType == Points.PointType.LeftBottom ||
                ManagerPoints.SelectPointType == Points.PointType.RightBottom;

            for ( int i = 0; i < mLocalVertex.Count; i++ )
            {
                Vertex vertex = mLocalVertex[ i ];

                switch ( ManagerPoints.SelectPointType )
                {
                    //----------------------------------------------------------//

                    case Points.PointType.LeftCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy ||
                             typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                vertex.Move( FactorSize.X, Program.PlaneType.X );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                vertex.Move( FactorSize.X, Program.PlaneType.Z );
                        }
                        break;

                    //----------------------------------------------------------//

                    case Points.PointType.RightCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy ||
                            typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                            vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                vertex.Move( FactorSize.X, Program.PlaneType.X );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                vertex.Move( FactorSize.X, Program.PlaneType.Z );
                        }
                        break;

                    //----------------------------------------------------------//

                    case Points.PointType.TopCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                vertex.Move( FactorSize.Z, Program.PlaneType.Z );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                 vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                 vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                 vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        break;

                    //----------------------------------------------------------//

                    case Points.PointType.BottomCenter:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                 vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                 vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                 vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                vertex.Move( FactorSize.Z, Program.PlaneType.Z );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                 vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                 vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                 vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        break;

                    //----------------------------------------------------------//

                    case Points.PointType.LeftTop:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        break;

                    //----------------------------------------------------------//

                    case Points.PointType.LeftBottom:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                    vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        break;

                    //----------------------------------------------------------//

                    case Points.PointType.RightTop:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        break;

                    //----------------------------------------------------------//

                    case Points.PointType.RightBottom:
                        if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                        {
                            if ( FactorSize.Z != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftTop )
                                    vertex.Move( FactorSize.Z, Program.PlaneType.Z );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                        {
                            if ( FactorSize.X != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightTop ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom )
                                    vertex.Move( FactorSize.X, Program.PlaneType.X );

                            if ( FactorSize.Y != 0 )
                                if ( vertex.typeVertex == Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex == Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( FactorSize.Y, Program.PlaneType.Y );
                        }
                        break;

                    //----------------------------------------------------------//
                }
            }

            //-----------------------------------------------------------------------------//

            if ( IsUpdateVertexs )
                for ( int i = 0; i < mLocalVertex.Count; i++ )
                {
                    Vertex vertex = mLocalVertex[ i ];

                    switch ( ManagerPoints.SelectPointType )
                    {
                        //----------------------------------------------------------//

                        case Points.PointType.LeftCenter:
                            if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                 vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                if ( typeViewport != Viewport.TypeViewport.Front_2D_yz )
                                    vertex.Move( -FactorSize.X, Program.PlaneType.X );
                                else
                                    vertex.Move( -FactorSize.X, Program.PlaneType.Z );
                            break;

                        //----------------------------------------------------------//

                        case Points.PointType.BottomCenter:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftTop )
                                    vertex.Move( -FactorSize.Z, Program.PlaneType.Z );
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( -FactorSize.Y, Program.PlaneType.Y );
                            }
                            break;

                        //----------------------------------------------------------//

                        case Points.PointType.LeftTop:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy || typeViewport == Viewport.TypeViewport.Side_2D_xz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Move( -FactorSize.X, Program.PlaneType.X );
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( -FactorSize.Z, Program.PlaneType.Z );
                            }
                            break;

                        //----------------------------------------------------------//

                        case Points.PointType.LeftBottom:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Move( -FactorSize.X, Program.PlaneType.X );

                                if ( vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftTop )
                                    vertex.Move( -FactorSize.Z, Program.PlaneType.Z );
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( -FactorSize.Z, Program.PlaneType.Z );

                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( -FactorSize.Y, Program.PlaneType.Y );
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom )
                                    vertex.Move( -FactorSize.X, Program.PlaneType.X );

                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( -FactorSize.Y, Program.PlaneType.Y );
                            }
                            break;

                        //----------------------------------------------------------//

                        case Points.PointType.RightBottom:
                            if ( typeViewport == Viewport.TypeViewport.Top_2D_xy )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightTop ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftTop )
                                    vertex.Move( -FactorSize.Z, Program.PlaneType.Z );
                            }
                            else if ( typeViewport == Viewport.TypeViewport.Side_2D_xz || typeViewport == Viewport.TypeViewport.Front_2D_yz )
                            {
                                if ( vertex.typeVertex != Vertex.TypeVertex.Back_RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.Back_LeftBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.RightBottom ||
                                     vertex.typeVertex != Vertex.TypeVertex.LeftBottom )
                                    vertex.Move( -FactorSize.Y, Program.PlaneType.Y );
                            }
                            break;

                        //----------------------------------------------------------//
                    }
                }

            //-----------------------------------------------------------------------------//
        }

        //-------------------------------------------------------------------------//

        public void UpdateVertex()
        {
            for ( int i = 0; i < mLocalVertex.Count; i++ )
                mLocalVertex[ i ].DefaultPosition = new Vector3f( mLocalVertex[ i ].Position );

            SelectSize = new Vector3f( ManagerPoints.Size );
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

        protected void InitIdVertex( PrimitivesType type )
        {
            switch ( type )
            {
                case PrimitivesType.Cube:
                    //----------------------------------------------
                    // Id Вершин / Тип рисовния - Линии (Для 2D)
                    //---------------------------------------------

                    mIdVertex_Lines = new List<int>
                    {
                        0, 1, 2, 3,
                        0, 3, 1, 2,

                        4, 5, 6, 7,
                        4, 7, 5, 6,

                        0, 4, 3, 7,
                        0, 3, 4, 7,

                        1, 5, 2, 6,
                        1, 2, 5, 6,

                        3, 2, 7, 6,
                        3, 7, 2, 6,

                        0, 1, 4, 5,
                        0, 4, 1, 5
                    };

                    //-----------------------------------------------------
                    // Id Вершин / Тип рисовния - Треугольники (Для 3D)
                    //-----------------------------------------------------

                    mIdVertex_Triangles = new List<int>
                    {
                        7, 3, 4,
                        3, 0, 4,

                        2, 6, 1,
                        6, 5, 1,

                        7, 6, 3,
                        6, 2, 3,

                        0, 1, 4,
                        1, 5, 4,

                        6, 4, 5,
                        6, 7, 4,

                        0, 2, 1,
                        0, 3, 2
                    };
                    break;

                case PrimitivesType.Sphere:
                    break;

                case PrimitivesType.Plane:
                    break;
            }
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

        protected void GenerateTextureCoords()
        {
            mTextureCoord.Clear();

            for ( int i = 0, j = 0; i < mIdVertex_Triangles.Count / 3; i++ )
            {
                Vertex A = mLocalVertex[ mIdVertex_Triangles[ j ] ];
                Vertex B = mLocalVertex[ mIdVertex_Triangles[ j + 1 ] ];
                Vertex C = mLocalVertex[ mIdVertex_Triangles[ j + 2 ] ];
                j += 3;

                Vector3f Normal = Vector3f.CrossProduct( B.Position - A.Position, C.Position - A.Position );
                Normal.Normalize();

                Vector3f planeTangent = Vector3f.CrossProduct( Normal, new Vector3f( 0.0f, 1.0f, 0.00001f ) );
                Vector3f planeBinormal = Vector3f.CrossProduct( Normal, planeTangent );

                planeTangent.Normalize();
                planeBinormal.Normalize();

                float U = Vector3f.DotProduct( A.Position, planeTangent );
                float V = Vector3f.DotProduct( A.Position, planeBinormal );

                /*
                 * U += textureShiftX;
                 * V += textureShiftY;
                 * U /= textureScaleX;
                 * V /= textureScaleY;
                 */
                U /= 20f; // ScaleX 
                V /= 20f;  // ScaleY

                mTextureCoord.Add( new Vector3f( -U, -V, 0 ) );

                U = Vector3f.DotProduct( B.Position, planeTangent );
                V = Vector3f.DotProduct( B.Position, planeBinormal );

                U /= 20f;
                V /= 20f;

                mTextureCoord.Add( new Vector3f( -U, -V, 0 ) );

                U = Vector3f.DotProduct( C.Position, planeTangent );
                V = Vector3f.DotProduct( C.Position, planeBinormal );

                U /= 20f;
                V /= 20f;

                mTextureCoord.Add( new Vector3f( -U, -V, 0 ) );
            }
        }

        //-------------------------------------------------------------------------//

        public SaveBrush ToSave()
        {
            SaveBrush saveBrush = new SaveBrush();
            saveBrush.TextureName = TextureBrush.Name;
            saveBrush.Type = Type.ToString();
            saveBrush.Position = Position;
            saveBrush.Size = Size;
            saveBrush.LocalVertex = mLocalVertex;
            saveBrush.TextureCoords = mTextureCoord;

            return saveBrush;
        }

        //-------------------------------------------------------------------------//

        public SaveBrush ToExport()
        {
            SaveBrush saveBrush = new SaveBrush();
            saveBrush.TextureName = TextureBrush.Name;
            saveBrush.Type = Type.ToString();
            saveBrush.Vertex = mGlobalVertex;
            saveBrush.TextureCoords = mTextureCoord;
            return saveBrush;
        }

        //-------------------------------------------------------------------------//

        public PrimitivesType Type;
        public Vector3f CenterBrush = new Vector3f();
        public Vector3f Size = new Vector3f();
        public Vector3f SelectSize = new Vector3f();
        public Vector3f Position = new Vector3f();
        public Color DefaultColorBrush = new Color( 1, 0, 0 );

        protected Color ColorBrush = new Color( 1, 0, 0 );
        protected Texture TextureBrush = new Texture();

        private List<Vertex> mLocalVertex = new List<Vertex>();
        private List<Vector3f> mGlobalVertex = new List<Vector3f>();
        private List<Vector3f> mTextureCoord = new List<Vector3f>();
        private List<int> mIdVertex_Lines = new List<int>();
        private List<int> mIdVertex_Triangles = new List<int>();
    }
}
