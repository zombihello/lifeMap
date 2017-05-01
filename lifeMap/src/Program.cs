using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using lifeMap.src.system;

namespace lifeMap
{
    static class Program
    {
        //-------------------------------------------------------------------------//

        public enum SelectTool
        {
            None,
            CursorTool,
            CameraTool,
            EntityTool,
            BoxTool
        };

        //-------------------------------------------------------------------------//

        public enum PlaneType
        {
            X,
            Y,
            Z
        };

        //-------------------------------------------------------------------------//

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainForm() );
        }

        //-------------------------------------------------------------------------//

        public static float Align( float value, float sizeGrid )
        {
            return ( float )Math.Floor( value / sizeGrid ) * sizeGrid;
        }

        //-------------------------------------------------------------------------//

        public static Vector3f Align( Vector3f value, float sizeGrid )
        {
            return new Vector3f( ( float )Math.Floor( value.X / sizeGrid ) * sizeGrid,
                                 ( float )Math.Floor( value.Y / sizeGrid ) * sizeGrid,
                                 ( float )Math.Floor( value.Z / sizeGrid ) * sizeGrid );
        }

        //-------------------------------------------------------------------------//

        public static Vector3f ToNewCoords( Vector3f NewCenterCoord, Vector3f PositionPoint )
        {
            Vector3f NewPosition = new Vector3f( PositionPoint.X - NewCenterCoord.X, PositionPoint.Y - NewCenterCoord.Y, PositionPoint.Z - NewCenterCoord.Z );
            return NewPosition;
        }

        //-------------------------------------------------------------------------//

        public static float ToNewCoords( float NewCenter, float PositionPoint )
        {
            return PositionPoint - NewCenter;
        }

        //-------------------------------------------------------------------------//

        public static SelectTool selectTool = SelectTool.None;
    }
}
