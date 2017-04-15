using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lifeMap
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
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
            return ( float ) Math.Floor( value / sizeGrid + 0.5f ) * sizeGrid;
        }

        //-------------------------------------------------------------------------//
    }
}
