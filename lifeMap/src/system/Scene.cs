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

            for ( int i = 0; i < mBrush.Count; i++ )
                mBrush[i].Render( typeViewport );

            if ( BrushSelect != null )
                BrushSelect.Render( typeViewport );
        }

        //-------------------------------------------------------------------------//

        private static void RenderXYZ()
        {
            Gl.glBegin( Gl.GL_LINES );
            Gl.glColor3f( 1, 0, 0 );
            Gl.glVertex3f( 0, 0, 0 );
            Gl.glVertex3f( 20, 0, 0 );

            Gl.glColor3f( 0, 0, 1 );
            Gl.glVertex3f( 0, 0, 0 );
            Gl.glVertex3f( 0, 20, 0 );

            Gl.glColor3f( 0, 1, 0 );
            Gl.glVertex3f( 0, 0, 0 );
            Gl.glVertex3f( 0, 0, 20 );
            Gl.glEnd();
        }

        //-------------------------------------------------------------------------//

        public static void CreateBrushSelect( Viewport.TypeViewport typeViewport, Camera Camera )
        {
            Vector3f StartPosition = Program.ToNewCoords( Camera.Position, Mouse.ClickPosition );
            Vector3f EndPosition = Program.ToNewCoords( Camera.Position, Mouse.Position );

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Top_2D_xy:
                    BrushSelect = new BrushSelect();
                    StartPosition.Z = StartPosition.Y;
                    EndPosition.Z = EndPosition.Y;
                    StartPosition.Y = EndPosition.Y = 0;
                    BrushSelect.Create( StartPosition, EndPosition );
                    break;

                case Viewport.TypeViewport.Front_2D_yz:
                    BrushSelect = new BrushSelect();
                    StartPosition.Z = StartPosition.X;
                    EndPosition.Z = EndPosition.X;
                    StartPosition.X = EndPosition.X = 0;
                    BrushSelect.Create( StartPosition, EndPosition );
                    break;

                case Viewport.TypeViewport.Side_2D_xz:
                    BrushSelect = new BrushSelect();
                    StartPosition.Z = EndPosition.Z = 0;
                    BrushSelect.Create( StartPosition, EndPosition );
                    break;
            }
        }

        //-------------------------------------------------------------------------//

        public static void CreateBrush()
        {
            if ( BrushSelect != null )
            {
                BrushBox BrushBox = new BrushBox();
                BrushBox.Create( BrushSelect.startPosition, BrushSelect.endPosition );
                mBrush.Add( BrushBox );
                ClearBrushSelect();
            }
        }

        //-------------------------------------------------------------------------//

        public static bool SelectBrush( Vector3f PositionClick, Viewport.TypeViewport typeViewport )
        {
            for ( int i = 0; i < mBrush.Count; i++ )
            {
                Vector3f centerBrush = new Vector3f();

                switch ( typeViewport )
                {
                    case Viewport.TypeViewport.Top_2D_xy:
                        centerBrush = new Vector3f( mBrush[i].CenterBrush.X, mBrush[i].CenterBrush.Z, 0 );
                        break;

                    case Viewport.TypeViewport.Front_2D_yz:
                        centerBrush = new Vector3f( mBrush[i].CenterBrush.Z, mBrush[i].CenterBrush.Y, 0 );
                        break;

                    case Viewport.TypeViewport.Side_2D_xz:
                        centerBrush = new Vector3f( mBrush[i].CenterBrush.X, mBrush[i].CenterBrush.Y, 0 );
                        break;

                    case Viewport.TypeViewport.Textured_3D:
                        //TODO: Сделать возможность выбора браша в 3д
                        break;
                }

                if ( PositionClick.X >= centerBrush.X - 5 &&
                     PositionClick.X <= centerBrush.X + 5 )
                    if ( PositionClick.Y >= centerBrush.Y - 5 &&
                         PositionClick.Y <= centerBrush.Y + 5 )
                    {
                        if ( Mouse.IsSelectBrush && Mouse.BrushSelect != null )
                            Mouse.BrushSelect.SetColorBrush( Mouse.BrushSelect.DefaultColorBrush );

                        mBrush[i].SetColorBrush( new Color( 1, 1, 1 ) );
                        Mouse.BrushSelect = mBrush[i];

                        ManagerPoints.SetSelectBrush( mBrush[i] );
                        ManagerPoints.Size = new Vector3f( mBrush[i].SelectSize );

                        Mouse.IsSelectBrush = true;
                        Mouse.typeSelectBrush = Mouse.TypeSelectBrush.Move;
                        return true;
                    }
            }

            return false;
        }

        //-------------------------------------------------------------------------//

        public static bool SelectPointResizeBrush( Vector3f PositionClick, Viewport.TypeViewport typeViewport )
        {
            if ( Mouse.IsSelectBrush && Mouse.BrushSelect != null )
            {
                if ( ManagerPoints.IsPointsClick( PositionClick ) )
                {
                    if ( ManagerPoints.pointsType == ManagerPoints.PointsType.Resize )
                        Mouse.typeSelectBrush = Mouse.TypeSelectBrush.Resize;
                    else
                        Mouse.typeSelectBrush = Mouse.TypeSelectBrush.Rotate;

                    return true;
                }
            }

            return false;
        }

        //-------------------------------------------------------------------------//

        public static void SetViewportWorldCamera( SimpleOpenGlControl View )
        {
            WorldCamera.SetViewport( View );
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

        public static void RemoveBrush( BasicBrush SelectBrush )
        {
            for ( int i = 0; i < mBrush.Count; i++ )
                if ( mBrush[i] == SelectBrush )
                {
                    mBrush.Remove( SelectBrush );
                    ManagerPoints.PointsClear();
                    return;
                }
        }

        //-------------------------------------------------------------------------//

        public static BrushSelect GetBrushSelect()
        {
            return BrushSelect;
        }

        //-------------------------------------------------------------------------//

        public static Camera WorldCamera = new Camera();

        private static BrushSelect BrushSelect = null;
        private static List<BasicBrush> mBrush = new List<BasicBrush>();

        //-------------------------------------------------------------------------//
    }
}
