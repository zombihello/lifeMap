using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;
using Tao.DevIl;

namespace lifeMap.src.system
{
    class Texture
    {
        //-------------------------------------------------------------------------//

        public Texture() { }

        //-------------------------------------------------------------------------//

        public Texture( Texture clone )
        {
            Size = new Vector3f( clone.Size );
            TextureObject = clone.TextureObject;

            Route = clone.Route;
            Name = clone.Name;            
        }

        //-------------------------------------------------------------------------//

        public bool LoadTexture( string route )
        {
            Il.ilGenImages( 1, out TextureId );
            Il.ilBindImage( TextureId );

            if ( !Il.ilLoadImage( route ) )
                return false;

            Route = route;
            Name = Path.GetFileName( Route );

            Size.X = Il.ilGetInteger( Il.IL_IMAGE_WIDTH );
            Size.Y = Il.ilGetInteger( Il.IL_IMAGE_HEIGHT );
            int bitspp = Il.ilGetInteger( Il.IL_IMAGE_BITS_PER_PIXEL );

            switch ( bitspp )
            {
                case 24:
                    TextureObject = MakeGlTexture( Gl.GL_RGB, Il.ilGetData() );
                    break;

                case 32:
                    TextureObject = MakeGlTexture( Gl.GL_RGBA, Il.ilGetData() );
                    break;
            }

            Il.ilDeleteImages( 1, ref TextureId );

            return true;
        }

        //-------------------------------------------------------------------------//
    
        public void DeleteTexture()
        {
            if ( TextureObject != 0 )
                Gl.glDeleteTextures( 1, ref TextureObject );
        }

        //-------------------------------------------------------------------------//

        public void SelectTexture( int TypeTexture )
        {
            Gl.glBindTexture( TypeTexture, TextureObject );
        }

        //-------------------------------------------------------------------------//

        private uint MakeGlTexture( int Format, IntPtr Pixels )
        {
            uint TextureGl = 0;

            Gl.glGenTextures( 1, out TextureGl );
            Gl.glBindTexture( Gl.GL_TEXTURE_2D, TextureGl );

            int AnisotropyLevel = 0;
            Gl.glGetIntegerv( Gl.GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT, out AnisotropyLevel );

            if ( IsFilterTexture ) // TODO: ДОДЕЛАТЬ
            {
                Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAX_ANISOTROPY_EXT, AnisotropyLevel );
                Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR );
                Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR_MIPMAP_LINEAR );
            }
            else
            {
                Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST );
                Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST_MIPMAP_NEAREST );
            }

            Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT );
            Gl.glTexParameteri( Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT );

            Gl.glTexEnvf( Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_COMBINE );
            
            switch ( Format )
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D( Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, ( int ) Size.X, ( int ) Size.Y, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, Pixels );
                    Glu.gluBuild2DMipmaps( Gl.GL_TEXTURE_2D, Gl.GL_RGB, ( int ) Size.X, ( int ) Size.Y, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, Pixels );
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D( Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, ( int ) Size.X, ( int ) Size.Y, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, Pixels );
                    Glu.gluBuild2DMipmaps( Gl.GL_TEXTURE_2D, Gl.GL_RGBA, ( int ) Size.X, ( int ) Size.Y, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, Pixels );
                    break;
            }

            return TextureGl;
        }

        //-------------------------------------------------------------------------//

        public static void ClearSelectTexture()
        {
            Gl.glBindTexture( Gl.GL_TEXTURE_2D, 0 );
        }

        //-------------------------------------------------------------------------//

        public Vector3f GetSize()
        {
            return Size;
        }

        //-------------------------------------------------------------------------//

        public static bool IsFilterTexture = true;

        public string Route;
        public string Name;

        private Vector3f Size = new Vector3f();
        private uint TextureObject = 0;
        private int TextureId;

        //-------------------------------------------------------------------------//
    }
}
