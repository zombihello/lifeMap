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
            for ( int i = 0; i < mTextures.Count; i++ )
                if ( mTextures[ i ].Name == name )
                {
                    SelectTexture = new Texture( mTextures[i] );
                    return;
                }
        }

        //-------------------------------------------------------------------------//

        public static void LoadTexture( string route )
        {
            if ( SelectTexture.LoadTexture( route ) )
            {
                mTextures.Add( new Texture( SelectTexture ) );
                mPicTextures.Add( new Bitmap( route ) );
            }
        }

        //-------------------------------------------------------------------------//

        public static void AddTexture( Texture texture, Bitmap bitmap )
        {
            mTextures.Add( texture );
            mPicTextures.Add( bitmap );
        }

        //-------------------------------------------------------------------------//

        public static void ClearTextures()
        {
            for ( int i = 0; i < mTextures.Count; i++ )
                mTextures[ i ].DeleteTexture();

                mTextures.Clear();
            mPicTextures.Clear();

            SelectTexture.DeleteTexture();
        }

        //-------------------------------------------------------------------------//

        public static bool IsTextureExist( string name )
        {
            for ( int i = 0; i < mTextures.Count; i++ )
                if ( mTextures[ i ].Name == name )
                    return true;

            return false;
        }

        //-------------------------------------------------------------------------//

        public static void SetFilterTexture( bool isFilterTexture )
        {
            Texture.IsFilterTexture = isFilterTexture;

            for ( int i = 0; i < mTextures.Count; i++ )
            {
                Texture texture = mTextures[ i ];
                texture.DeleteTexture();
                texture.LoadTexture( texture.Route );
            }
        }

        //-------------------------------------------------------------------------//

        public static Texture SelectTexture = new Texture();
        public static List<Texture> mTextures = new List<Texture>();
        public static List<Bitmap> mPicTextures = new List<Bitmap>();

        //-------------------------------------------------------------------------//
    }
}
