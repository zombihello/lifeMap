using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using lifeMap.src.brushes;

namespace lifeMap.src.system
{
    //-------------------------------------------------------------------------//

    struct SaveTexture
    {
        public string Route;
        public string Name;
    };

    //-------------------------------------------------------------------------//

    struct SaveBrush
    {
        public string Type;
        public string TextureName;
        public Vector3f Position;
        public Vector3f Size;
        public List<Vector3f> Vertex;
        public List<Vertex> LocalVertex;
        public List<Vector3f> TextureCoords;
    };

    //-------------------------------------------------------------------------//

    class Serialization
    {
        //-------------------------------------------------------------------------//

        public Serialization()
        {
            Brushes[ "Solid" ] = new List<SaveBrush>();
            Brushes[ "Triggers" ] = new List<SaveBrush>();
        }

        //-------------------------------------------------------------------------//

        public void SaveMap( string Route )
        {
            string CodeMap = "";

            FileStream fileStream = new FileStream( Route, FileMode.Create );
            StreamWriter streamWriter = new StreamWriter( fileStream );

            var jsonSerializerSettings = new JsonSerializerSettings 
            { 
                NullValueHandling = NullValueHandling.Ignore
            };

            CodeMap += JsonConvert.SerializeObject( this, jsonSerializerSettings );

            streamWriter.Write( CodeMap );

            streamWriter.Close();
            fileStream.Close();
        }

        //-------------------------------------------------------------------------//

        public void LoadMap( string Route )
        {
            string CodeMap = File.ReadAllText( Route );
            Serialization serialization = JsonConvert.DeserializeObject<Serialization>( CodeMap );

            NameMap = serialization.NameMap;
            DescriptionMap = serialization.DescriptionMap;
            SkyBoxName = serialization.SkyBoxName;
            Textures = serialization.Textures;
            Brushes = serialization.Brushes;
        }

        //-------------------------------------------------------------------------//

        public void SetMapSettings( MapProperties mapProperties )
        {
            NameMap = mapProperties.GetValue( "Name Map" );
            DescriptionMap = mapProperties.GetValue( "Description Map" );
            SkyBoxName = mapProperties.GetValue( "SkyBox Name" );
        }

        //-------------------------------------------------------------------------//

        public void SetLoadTextures( List<Texture> textures )
        {
            for ( int i = 0; i < textures.Count; i++ )
            {
                SaveTexture saveTexture = new SaveTexture();
                saveTexture.Route = textures[ i ].Route;
                saveTexture.Name = textures[ i ].Name;
                Textures.Add( saveTexture );
            }
        }

        //-------------------------------------------------------------------------//

        public void SetSolidBrushes( List<BasicBrush> brushes )
        {
            for ( int i = 0; i < brushes.Count; i++ )
            {
                SaveBrush saveBrush = new SaveBrush();
                saveBrush = brushes[ i ].ToSave();
                Brushes[ "Solid" ].Add( saveBrush );
            }
        }

        //-------------------------------------------------------------------------//

        public void GetMapSettings( MapProperties mapProperties )
        {
            mapProperties.SetValue( "Name Map", NameMap );
            mapProperties.SetValue( "Description Map", DescriptionMap );
            mapProperties.SetValue( "SkyBox Name", SkyBoxName );
        }

        //-------------------------------------------------------------------------//

        public List<Texture> GetLoadTextures()
        {
            List<Texture> mTexture = new List<Texture>();

            for ( int i = 0; i < Textures.Count; i++ )
            {
                Texture texture = new Texture();
                texture.LoadTexture( Textures[ i ].Route );
                mTexture.Add( texture );
            }

                return mTexture;
        }

        //-------------------------------------------------------------------------//

        public List<BasicBrush> GetSolidBrushes()
        {
            List<BasicBrush> mBrushes = new List<BasicBrush>();

            for ( int i = 0; i < Brushes["Solid"].Count; i++ )
                if ( Brushes["Solid"][i].Type == "Cube" )
                {
                    mBrushes.Add( new BrushBox(Brushes["Solid"][i] ));
                }

            return mBrushes;
        }

        //-------------------------------------------------------------------------//

        public void ClearSerialization()
        {
            NameMap = "";
            DescriptionMap = "";
            SkyBoxName = "";

            Textures.Clear();
            Brushes.Clear();
        }

        //-------------------------------------------------------------------------//

        public string NameMap = "";
        public string DescriptionMap = "";
        public string SkyBoxName = "";

        public List<SaveTexture> Textures = new List<SaveTexture>();
        public Dictionary<string, List<SaveBrush>> Brushes = new Dictionary<string, List<SaveBrush>>();
    }

    //-------------------------------------------------------------------------//
}
