using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifeMap.src
{
    //-------------------------------------------------------------------------//

    class Color
    {
        //-------------------------------------------------------------------------//

        public Color() 
        {
            R = G = B = 0;
        }

        //-------------------------------------------------------------------------//

        public Color( float r, float g, float b )
        {
            R = r / 255;
            G = g / 255;
            B = b / 255;
        }

        //-------------------------------------------------------------------------//

        public Color( string values )
        {
            string[] tmpValues = values.Split( ' ' );
            R = G = B = 0;

            for ( int i = 0; i < tmpValues.Length; i++ )
                switch ( i )
                {
                    case 0:
                        R = float.Parse( tmpValues[ i ] ) / 255;
                        break;

                    case 1:
                        G = float.Parse( tmpValues[ i ] ) / 255;
                        break;

                    case 2:
                        B = float.Parse( tmpValues[ i ] ) / 255;
                        return;
                }
        }

        //-------------------------------------------------------------------------//

        public float R;
        public float G;
        public float B;
    }

    //-------------------------------------------------------------------------//
}
