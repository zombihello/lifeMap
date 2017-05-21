using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lifeMap.src.system
{
    //-------------------------------------------------------------------------//

    public class SaveGeneral
    {
        public SaveGeneral()
        {
            Configurations = new List<string>();
            GameDirectory = new Dictionary<string, string>();
            GameDataFiles = new Dictionary<string, List<string>>();
            GameExecutableDirectory = new Dictionary<string, string>();
            TexturesDirectory = new Dictionary<string, string>();
            ExportMapDirectory = new Dictionary<string, string>();
            lifeMapMAPDirectory = new Dictionary<string, string>();
        }

        public string SelectConfiguration;
        public List<string> Configurations;
        public Dictionary<string, List<string>> GameDataFiles;
        public Dictionary<string, string> GameDirectory;
        public Dictionary<string, string> GameExecutableDirectory;
        public Dictionary<string, string> TexturesDirectory;
        public Dictionary<string, string> ExportMapDirectory;
        public Dictionary<string, string> lifeMapMAPDirectory;
    };

    //-------------------------------------------------------------------------//

    public struct SaveViews
    {
        public int SizeGrid;
        public int Intensity;
        public int RenderDistance;
        public bool FilterTexture;
        public int CameraFOV;
    };

    //-------------------------------------------------------------------------//

    class SerializationSettings
    {
        //-------------------------------------------------------------------------//

        public SerializationSettings() { }

        //-------------------------------------------------------------------------//

        public void Save( string Route, Options options )
        {
            string CodeSetting = "";

            General = options.ToSaveGeneral();
            Views = options.ToSaveViews();

            FileStream fileStream = new FileStream( Route, FileMode.Create );
            StreamWriter streamWriter = new StreamWriter( fileStream );

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            CodeSetting += JsonConvert.SerializeObject( this, jsonSerializerSettings );

            streamWriter.Write( CodeSetting );

            streamWriter.Close();
            fileStream.Close();
        }

        //-------------------------------------------------------------------------//

        public void Load( string Route, Options options )
        {
            if ( File.Exists( Route ) )
            {
                string CodeSetting = File.ReadAllText( Route );
                SerializationSettings serializationSettings = JsonConvert.DeserializeObject<SerializationSettings>( CodeSetting );

                General = serializationSettings.General;
                Views = serializationSettings.Views;

                options.LoadGeneral( General );
                options.LoadViews( Views );
            }
        }

        //-------------------------------------------------------------------------//

        public SaveGeneral General;
        public SaveViews Views;
    }

    //-------------------------------------------------------------------------//
}
