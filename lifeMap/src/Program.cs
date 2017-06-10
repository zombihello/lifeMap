using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

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
            AsociationMap();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainForm() );
        }

        //-------------------------------------------------------------------------//

        private static void AsociationMap()
        {
            RegistryKey Register;

            if ( Registry.ClassesRoot.GetValue( ".map" ) != null )
                Registry.ClassesRoot.DeleteSubKey( ".map" );

            if ( Registry.ClassesRoot.GetValue( "lifeMap" ) != null )
                Registry.ClassesRoot.DeleteSubKeyTree( "lifeMap" );

            Register = Registry.ClassesRoot.CreateSubKey( ".map" );
            Register.SetValue( string.Empty, "lifeMap" );

            Register = Registry.ClassesRoot.CreateSubKey( "lifeMap" );
            Register.SetValue( string.Empty, "lifeMap Source" );

            Register.CreateSubKey( "DefaultIcon" );
            Register.SetValue( string.Empty, Path.GetDirectoryName( args[ 0 ] + "\\mapSrc.ico,0" ) );

            Register = Registry.ClassesRoot.CreateSubKey( "lifeMap\\shell" );
            Register.SetValue( string.Empty, "open" );

            Register = Registry.ClassesRoot.CreateSubKey( "lifeMap\\shell\\open" );
            Register = Registry.ClassesRoot.CreateSubKey( "lifeMap\\shell\\open\\command" );
            Register.SetValue( string.Empty, "\"" + args[ 0 ] + "\" \"%1\"" );

            Register.Flush();
            Register.Close();
        }

        //-------------------------------------------------------------------------//

        public static float Align( float value, float sizeGrid )
        {
            return ( float ) Math.Floor( value / sizeGrid + 0.5f ) * sizeGrid;
        }

        //-------------------------------------------------------------------------//

        public static Vector3f Align( Vector3f value, float sizeGrid )
        {
            return new Vector3f( ( float ) Math.Floor( value.X / sizeGrid + 0.5f ) * sizeGrid,
                                 ( float ) Math.Floor( value.Y / sizeGrid + 0.5f ) * sizeGrid,
                                 ( float ) Math.Floor( value.Z / sizeGrid + 0.5f ) * sizeGrid );
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

        public static string Version = "Alpha 1.4.1";
        public static string SelectCategoryEntity;
        public static string[] args = Environment.GetCommandLineArgs();
        public static SelectTool selectTool = SelectTool.None;
        public static Dictionary<string, string> SelectEntity = new Dictionary<string, string>();
    }
}
