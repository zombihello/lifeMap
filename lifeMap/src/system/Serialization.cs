using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
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
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            CodeMap += JsonConvert.SerializeObject( this, jsonSerializerSettings );

            streamWriter.Write( CodeMap );

            streamWriter.Close();
            fileStream.Close();
        }

        //-------------------------------------------------------------------------//

        public void ExportMap( string Route )
        {
            string CodeMap = "";

            FileStream fileStream = new FileStream( Route, FileMode.Create );
            StreamWriter streamWriter = new StreamWriter( fileStream );

            CodeMap += "<!-- lifeMap " + Program.Version + " -->\n";
            CodeMap += "<Map>\n";

            //Map Settings
            CodeMap += "<Settings>\n";
            CodeMap += "<NameMap Value=\"" + NameMap + "\"/>\n";
            CodeMap += "<DescriptionMap Value=\"" + DescriptionMap + "\"/>\n";
            CodeMap += "<SkyBoxName Value=\"" + SkyBoxName + "\"/>\n";
            CodeMap += "</Settings>\n";

            //Textures
            if ( Textures.Count > 0 )
            {
                CodeMap += "<Textures>\n";

                for ( int i = 0; i < Textures.Count; i++ )
                    CodeMap += "<Texture Name=\"" + Textures[ i ].Name + "\" Route=\"" + Textures[ i ].Route + "\"/>\n";

                CodeMap += "</Textures>\n";
            }

            //Brushes
            CodeMap += "<Brushes>\n";

            //Solid
            if ( Brushes[ "Solid" ].Count > 0 )
            {
                List<SaveBrush> mSaveBrush = Brushes[ "Solid" ];
                CodeMap += "<Solid>\n";

                for ( int i = 0; i < mSaveBrush.Count; i++ )
                {
                    CodeMap += "<Brush>\n";
                    CodeMap += "<Type Value=\"" + mSaveBrush[ i ].Type + "\"/>\n";
                    CodeMap += "<TextureName Value=\"" + mSaveBrush[ i ].TextureName + "\"/>\n";

                    //Position Vertex
                    List<Vector3f> mVertex = mSaveBrush[ i ].Vertex;
                    CodeMap += "<PositionVertex>\n";

                    for ( int j = 0; j < mVertex.Count; j++ )
                        CodeMap += "<Vertex X=\"" + mVertex[ j ].X + "\" Y=\"" + mVertex[ j ].Y + "\" Z=\"" + mVertex[ j ].Z + "\"/>\n";

                    CodeMap += "</PositionVertex>\n";

                    //Texture Coords
                    List<Vector3f> mTextureCoords = mSaveBrush[ i ].TextureCoords;
                    CodeMap += "<TextureCoords>\n";

                    for ( int j = 0; j < mTextureCoords.Count; j++ )
                    {
                        string textureX = string.Format( "{0:0}", mTextureCoords[ j ].X );
                        string textureY = string.Format( "{0:0}", mTextureCoords[ j ].Y ); // TODO: некоректно сохраняються координаты, исправить
                        CodeMap += "<Point X=\"" + textureX + "\" Y=\"" + textureY + "\"/>\n";
                    }

                    CodeMap += "</TextureCoords>\n";
                    CodeMap += "</Brush>\n";
                }

                CodeMap += "</Solid>\n";
            }

            //Triggers
            if ( Brushes[ "Triggers" ].Count > 0 )
            {
                CodeMap += "<Triggers>\n";
                //TODO: добавить тригеры
                CodeMap += "</Triggers>\n";
            }

            CodeMap += "</Brushes>\n";

            CodeMap += "</Map>";

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

        public void SetLoadTextures( List<Texture> textures, string DirectoryTextures )
        {
            for ( int i = 0; i < textures.Count; i++ )
            {
                SaveTexture saveTexture = new SaveTexture();
                saveTexture.Route = DirectoryTextures + "\\" + Path.GetFileName( textures[ i ].Route );
                saveTexture.Name = textures[ i ].Name;
                Textures.Add( saveTexture );
            }
        }

        //-------------------------------------------------------------------------//

        public void SetSolidBrushes( List<BasicBrush> brushes, bool IsExport = false )
        {
            for ( int i = 0; i < brushes.Count; i++ )
            {
                SaveBrush saveBrush = new SaveBrush();

                if ( !IsExport )
                    saveBrush = brushes[ i ].ToSave();
                else
                    saveBrush = brushes[ i ].ToExport();

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

            for ( int i = 0; i < Brushes[ "Solid" ].Count; i++ )
                if ( Brushes[ "Solid" ][ i ].Type == "Cube" )
                {
                    mBrushes.Add( new BrushBox( Brushes[ "Solid" ][ i ] ) );
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
