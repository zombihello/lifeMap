using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using lifeMap.src.brushes;

namespace lifeMap.src.system
{
    //-------------------------------------------------------------------------//

    class ListEntity
    {
        //-------------------------------------------------------------------------//

        public ListEntity()
        {
            Entity = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
        }

        //-------------------------------------------------------------------------//

        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> Entity;
    }

    //-------------------------------------------------------------------------//

    class SerializationEntity
    {
        //-------------------------------------------------------------------------//

        public bool LoadEntity( string Route )
        {
            if ( !File.Exists( Route ) )
                return false;

            string CodeEntity = File.ReadAllText( Route );
            ListEntity serialization = JsonConvert.DeserializeObject<ListEntity>( CodeEntity );

            listEntity = serialization;
            Entity.listEntity = listEntity;

            return true;
        }

        //-------------------------------------------------------------------------//

        public ListEntity listEntity = new ListEntity();
    }

    //-------------------------------------------------------------------------//
}
