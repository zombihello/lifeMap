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

namespace lifeMap.src.system
{
    static class Scene
    {
        //-------------------------------------------------------------------------//

        public static void UpdateScene( Viewport.TypeViewport typeViewport )
        {
            RenderXYZ();

            for ( int i = 0; i < mEntity.Count; i++ )
                mEntity[ i ].Render( typeViewport );

            for ( int i = 0; i < mBrush.Count; i++ )
                mBrush[ i ].Render( typeViewport );

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

        public static void CreateBrushSelect( Viewport.TypeViewport typeViewport, Viewport viewport )
        {
            Vector3f StartPosition = Program.ToNewCoords( viewport.Camera.Position, Mouse.ClickPosition );
            Vector3f EndPosition = Program.ToNewCoords( viewport.Camera.Position, Mouse.Position );

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Top_2D_xz:
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

                case Viewport.TypeViewport.Side_2D_xy:
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

        public static void CreateEntity( Viewport.TypeViewport typeViewport, Viewport viewport )
        {
            if ( Entity.listEntity == null || !Entity.listEntity.Entity.ContainsKey( Program.SelectEntity[ "Entity" ] ) )
                return;

            Entity entity = new Entity();
            Vector3f Position = Program.ToNewCoords( viewport.Camera.Position, Mouse.ClickPosition );

            switch ( typeViewport )
            {
                case Viewport.TypeViewport.Top_2D_xz:
                    Position.Z = Position.Y;
                    Position.Y = Position.Y = 0;
                    entity.Create( Position );
                    break;

                case Viewport.TypeViewport.Front_2D_yz:
                    Position.Z = Position.X;
                    Position.X = 0;
                    entity.Create( Position );
                    break;

                case Viewport.TypeViewport.Side_2D_xy:
                    Position.Z = 0;
                    entity.Create( Position );
                    break;
            }

            mEntity.Add( entity );
        }

        //-------------------------------------------------------------------------//

        public static bool SelectBrush( Vector3f PositionClick, Viewport.TypeViewport typeViewport, MouseButtons Button )
        {
            Vector3f centerBrush = new Vector3f();

            float factorSize = 4;

            if ( Viewport.TmpViewport.FactorZoom > 0 )
                factorSize *= Viewport.TmpViewport.FactorZoom;
            else
                factorSize /= Viewport.TmpViewport.FactorZoom;

            //--------------ПРОВЕРКА-ВЫБОРА-ЭНТИТИ----------------------//

            for ( int i = 0; i < mEntity.Count; i++ )
            {
                switch ( typeViewport )
                {
                    case Viewport.TypeViewport.Top_2D_xz:
                        centerBrush = new Vector3f( mEntity[ i ].CenterBrush.X, mEntity[ i ].CenterBrush.Z, 0 );
                        break;

                    case Viewport.TypeViewport.Front_2D_yz:
                        centerBrush = new Vector3f( mEntity[ i ].CenterBrush.Z, mEntity[ i ].CenterBrush.Y, 0 );
                        break;

                    case Viewport.TypeViewport.Side_2D_xy:
                        centerBrush = new Vector3f( mEntity[ i ].CenterBrush.X, mEntity[ i ].CenterBrush.Y, 0 );
                        break;

                    case Viewport.TypeViewport.Textured_3D:
                        //TODO: Сделать возможность выбора браша в 3д
                        break;
                }

                if ( PositionClick.X >= centerBrush.X - factorSize &&
                     PositionClick.X <= centerBrush.X + factorSize )
                    if ( PositionClick.Y >= centerBrush.Y - factorSize &&
                         PositionClick.Y <= centerBrush.Y + factorSize )
                    {
                        if ( Mouse.IsSelect && Mouse.BrushSelect != null )
                            Mouse.BrushSelect.SetColorBrush( Mouse.BrushSelect.DefaultColorBrush );

                        mEntity[ i ].SetColorBrush( new Color( 255, 255, 255 ) );
                        Mouse.BrushSelect = mEntity[ i ];
                        Mouse.EntitySelect = mEntity[ i ];

                        ManagerPoints.SetSelect( mEntity[ i ] );
                        ManagerPoints.SetPointsType( ManagerPoints.PointsType.Rotate );

                        Mouse.IsSelect = true;
                        Mouse.typeSelect = Mouse.TypeSelectBrush.Move;
                        return true;
                    }
            }

            if ( Button == MouseButtons.Right ) return false;

            //--------------ПРОВЕРКА-ВЫБОРА-БРАШЕЙ----------------------//

            for ( int i = 0; i < mBrush.Count; i++ )
            {
                switch ( typeViewport )
                {
                    case Viewport.TypeViewport.Top_2D_xz:
                        centerBrush = new Vector3f( mBrush[ i ].CenterBrush.X, mBrush[ i ].CenterBrush.Z, 0 );
                        break;

                    case Viewport.TypeViewport.Front_2D_yz:
                        centerBrush = new Vector3f( mBrush[ i ].CenterBrush.Z, mBrush[ i ].CenterBrush.Y, 0 );
                        break;

                    case Viewport.TypeViewport.Side_2D_xy:
                        centerBrush = new Vector3f( mBrush[ i ].CenterBrush.X, mBrush[ i ].CenterBrush.Y, 0 );
                        break;

                    case Viewport.TypeViewport.Textured_3D:
                        //TODO: Сделать возможность выбора браша в 3д
                        break;
                }

                if ( PositionClick.X >= centerBrush.X - factorSize &&
                     PositionClick.X <= centerBrush.X + factorSize )
                    if ( PositionClick.Y >= centerBrush.Y - factorSize &&
                         PositionClick.Y <= centerBrush.Y + factorSize )
                    {
                        if ( Mouse.IsSelect && Mouse.BrushSelect != null )
                            Mouse.BrushSelect.SetColorBrush( Mouse.BrushSelect.DefaultColorBrush );

                        mBrush[ i ].SetColorBrush( new Color( 255, 255, 255 ) );
                        Mouse.BrushSelect = mBrush[ i ];

                        ManagerPoints.SetSelect( mBrush[ i ] );
                        ManagerPoints.SetPointsType( ManagerPoints.PointsType.Resize );

                        Mouse.IsSelect = true;
                        Mouse.typeSelect = Mouse.TypeSelectBrush.Move;
                        return true;
                    }
            }

            return false;
        }

        //-------------------------------------------------------------------------//

        public static bool SelectPointResizeBrush( Vector3f PositionClick, Viewport.TypeViewport typeViewport )
        {
            if ( Mouse.IsSelect && Mouse.BrushSelect != null )
            {
                if ( ManagerPoints.IsPointsClick( PositionClick ) )
                {
                    if ( ManagerPoints.pointsType == ManagerPoints.PointsType.Resize )
                        Mouse.typeSelect = Mouse.TypeSelectBrush.Resize;
                    else
                        Mouse.typeSelect = Mouse.TypeSelectBrush.Rotate;

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

        public static void SetAllBrushes( List<BasicBrush> brushes )
        {
            mBrush = brushes;
        }

        //-------------------------------------------------------------------------//

        public static void SetAllEntitys( List<Entity> entitys )
        {
            mEntity = entitys;
        }

        //-------------------------------------------------------------------------//

        public static void Clear()
        {
            mBrush.Clear();
            mEntity.Clear();
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
                if ( mBrush[ i ] == SelectBrush )
                {
                    mBrush.Remove( SelectBrush );
                    ManagerPoints.PointsClear();
                    return;
                }

            for ( int i = 0; i < mEntity.Count; i++ )
                if ( mEntity[ i ] == SelectBrush )
                {
                    mEntity.Remove( Mouse.EntitySelect );
                    Mouse.EntitySelect = null;
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

        public static List<BasicBrush> GetAllBrushes()
        {
            return mBrush;
        }

        //-------------------------------------------------------------------------//

        public static List<Entity> GetAllEntitys()
        {
            return mEntity;
        }

        //-------------------------------------------------------------------------//

        public static Camera WorldCamera = new Camera();

        private static BrushSelect BrushSelect = null;
        private static List<BasicBrush> mBrush = new List<BasicBrush>();
        private static List<Entity> mEntity = new List<Entity>();

        //-------------------------------------------------------------------------//
    }
}
