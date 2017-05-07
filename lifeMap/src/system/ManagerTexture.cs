using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifeMap.src.system
{
    class ManagerTexture
    {

        //-------------------------------------------------------------------------//

        public static void SetSelectTexture( string name )
        {
            if ( mTextures.ContainsKey(name) )
                SelectTexture = new Texture( mTextures[name] );
        }

        //-------------------------------------------------------------------------//

        public static void LoadTexture( string route )
        {
            SelectTexture.LoadTexture( route );
            mTextures[ Path.GetFileName( route ) ] = new Texture( SelectTexture );
            mPicTextures.Add( new Bitmap( route ) );
        }

        //-------------------------------------------------------------------------//

        public static void AddTexture( string name, Texture texture, Bitmap bitmap )
        {
            mTextures.Add( name, texture );
            mPicTextures.Add( bitmap );
        }

        //-------------------------------------------------------------------------//

        public static void ClearTextures()
        {
            foreach ( string key in mTextures.Keys )
                mTextures[ key ].DeleteTexture();

            mTextures.Clear();
            mPicTextures.Clear();

            SelectTexture.DeleteTexture();
        }

        //-------------------------------------------------------------------------//

        public static bool IsTextureExist( string name )
        {
            return mTextures.ContainsKey( name );
        }

        //-------------------------------------------------------------------------//

        public static Texture SelectTexture = new Texture(); 
        public static Dictionary<string, Texture> mTextures = new Dictionary<string,Texture>();
        public static List<Bitmap> mPicTextures = new List<Bitmap>();

        //-------------------------------------------------------------------------//
    }
}
