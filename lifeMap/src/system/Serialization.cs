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
        public string Name;
    };

    //-------------------------------------------------------------------------//

    struct SaveEntity
    {
        public string EntityName;
        public Vector3f Position;
        public Dictionary<string, string> Values;
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
        public List<Vector3f> Normals;
        public List<Vector3f> TextureCoords;
    };

    //-------------------------------------------------------------------------//

    class Serialization
    {
        //-------------------------------------------------------------------------//

        public Serialization()
        {
            Brushes["Solid"] = new List<SaveBrush>();
            Brushes["Triggers"] = new List<SaveBrush>();
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

        public void ExportMap( string Route, string TextureRoute )
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
                    CodeMap += "<Texture Name=\"" + Textures[i].Name + "\" Route=\"" + TextureRoute + "\\" + Textures[i].Name + "\"/>\n";

                CodeMap += "</Textures>\n";
            }

            //Brushes
            CodeMap += "<Brushes>\n";

            //Solid
            if ( Brushes["Solid"].Count > 0 )
            {
                List<SaveBrush> mSaveBrush = Brushes["Solid"];
                CodeMap += "<Solid>\n";

                for ( int i = 0; i < mSaveBrush.Count; i++ )
                {
                    CodeMap += "<Brush>\n";
                    CodeMap += "<Type Value=\"" + mSaveBrush[i].Type + "\"/>\n";
                    CodeMap += "<TextureName Value=\"" + mSaveBrush[i].TextureName + "\"/>\n";

                    //Position Vertex
                    List<Vector3f> mVertex = mSaveBrush[i].Vertex;
                    CodeMap += "<PositionVertex>\n";

                    for ( int j = 0; j < mVertex.Count; j++ )
                    {
                        string VertexX = mVertex[j].X.ToString().Replace( ",", "." );
                        string VertexY = mVertex[j].Y.ToString().Replace( ",", "." );
                        string VertexZ = mVertex[j].Z.ToString().Replace( ",", "." );
                        CodeMap += "<Vertex X=\"" + VertexX + "\" Y=\"" + VertexY + "\" Z=\"" + VertexZ + "\"/>\n";
                    }

                    CodeMap += "</PositionVertex>\n";

                    //Normals
                    List<Vector3f> mNormals = mSaveBrush[i].Normals;

                    CodeMap += "<Normals>\n";

                    for ( int j = 0; j < mNormals.Count; j++ )
                    {
                        string NormalX = mNormals[j].X.ToString().Replace( ",", "." );
                        string NormalY = mNormals[j].Y.ToString().Replace( ",", "." );
                        string NormalZ = mNormals[j].Z.ToString().Replace( ",", "." );
                        CodeMap += "<Point X=\"" + NormalX + "\" Y=\"" + NormalY + "\" Z=\"" + NormalZ + "\"/>\n";
                    }

                    CodeMap += "</Normals>\n";

                    //Texture Coords
                    List<Vector3f> mTextureCoords = mSaveBrush[i].TextureCoords;
                    CodeMap += "<TextureCoords>\n";

                    for ( int j = 0; j < mTextureCoords.Count; j++ )
                    {
                        string textureX = mTextureCoords[j].X.ToString().Replace( ",", "." );
                        string textureY = mTextureCoords[j].Y.ToString().Replace( ",", "." );
                        CodeMap += "<Point X=\"" + textureX + "\" Y=\"" + textureY + "\"/>\n";
                    }

                    CodeMap += "</TextureCoords>\n";
                    CodeMap += "</Brush>\n";
                }

                CodeMap += "</Solid>\n";
            }

            //Triggers
            if ( Brushes["Triggers"].Count > 0 )
            {
                CodeMap += "<Triggers>\n";
                //TODO: добавить тригеры
                CodeMap += "</Triggers>\n";
            }

            CodeMap += "</Brushes>\n";

            CodeMap += "<Entitys>\n";

            for ( int i = 0; i < Entitys.Count; i++ )
            {
                CodeMap += "<Entity Name=\"" + Entitys[i].EntityName + "\">\n";
                CodeMap += "<Position X=\"" + Entitys[i].Position.X + "\" Y=\"" + Entitys[i].Position.Y + "\" Z=\"" + Entitys[i].Position.Z + "\"/>\n";

                for ( int j = 0; j < Entitys[i].Values.Keys.Count; j++ )
                {
                    string nameValue = Entitys[i].Values.Keys.ToList()[j].ToString();
                    CodeMap += "<Value Name=\"" + nameValue + "\" Value=\"" + Entitys[i].Values[nameValue] + "\"/>\n";
                }

                CodeMap += "</Entity>\n";
            }

            CodeMap += "</Entitys>\n";

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
            Entitys = serialization.Entitys;
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
                saveTexture.Name = textures[i].Name;
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
                    saveBrush = brushes[i].ToSave();
                else
                    saveBrush = brushes[i].ToExport();

                Brushes["Solid"].Add( saveBrush );
            }
        }

        //-------------------------------------------------------------------------//

        public void SetEntitys( List<Entity> entitys )
        {
            for ( int i = 0; i < entitys.Count; i++ )
            {
                SaveEntity saveEntity = new SaveEntity();
                saveEntity = entitys[i].ToSave();

                Entitys.Add( saveEntity );
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

        public List<Texture> GetLoadTextures( string DirectoryTextures )
        {
            List<Texture> mTexture = new List<Texture>();

            for ( int i = 0; i < Textures.Count; i++ )
            {
                Texture texture = new Texture();
                texture.LoadTexture( DirectoryTextures + "\\" + Textures[i].Name );
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
                    mBrushes.Add( new BrushBox( Brushes["Solid"][i] ) );
                }

            return mBrushes;
        }

        //-------------------------------------------------------------------------//

        public List<Entity> GetEntitys()
        {
            List<Entity> mEntitys = new List<Entity>();

            if ( Entity.listEntity == null )
                return mEntitys;

            for ( int i = 0; i < Entitys.Count; i++ )
                if ( Entity.listEntity.Entity.ContainsKey( Entitys[i].EntityName ) )
                    mEntitys.Add( new Entity( Entitys[i] ) );

            return mEntitys;
        }

        //-------------------------------------------------------------------------//

        public void ClearSerialization()
        {
            NameMap = "";
            DescriptionMap = "";
            SkyBoxName = "";

            Textures.Clear();
            Brushes.Clear();
            Entitys.Clear();
        }

        //-------------------------------------------------------------------------//

        public string NameMap = "";
        public string DescriptionMap = "";
        public string SkyBoxName = "";

        public List<SaveTexture> Textures = new List<SaveTexture>();
        public Dictionary<string, List<SaveBrush>> Brushes = new Dictionary<string, List<SaveBrush>>();
        public List<SaveEntity> Entitys = new List<SaveEntity>();
    }

    //-------------------------------------------------------------------------//
}
