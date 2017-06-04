using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

using lifeMap.src.system;
using lifeMap.src.forms;

namespace lifeMap.src.brushes
{
    class Entity : BasicBrush
    {
        //-------------------------------------------------------------------------//

        public Entity() { }

        //-------------------------------------------------------------------------//

        public Entity( SaveEntity saveEntity )
        {
            Dictionary<string, string> TmpValues = saveEntity.Values;
            Dictionary<string, string> TmpSettings = listEntity.Entity[ saveEntity.EntityName ][ "Settings" ];

            brushType = BasicBrush.BrushType.Entity;
            this.Position = saveEntity.Position;
            EntityName = saveEntity.EntityName;
            Size = new Vector3f( TmpSettings[ "Size" ] );
            SelectSize = new Vector3f( Size / 2 );
            ColorBrush = DefaultColorBrush = new Color( TmpSettings[ "Color" ] );

            for ( int i = 0; i < TmpValues.Keys.Count; i++ )
                mValues[ TmpValues.Keys.ToList()[ i ].ToString() ] = TmpValues[ TmpValues.Keys.ToList()[ i ] ];

            // Front
            AddVertex( 0, 0, 0, Vertex.TypeVertex.LeftBottom ); // 0
            AddVertex( Size.X, 0, 0, Vertex.TypeVertex.RightBottom ); // 1
            AddVertex( Size.X, Size.Y, 0, Vertex.TypeVertex.RightTop ); // 2
            AddVertex( 0, Size.Y, 0, Vertex.TypeVertex.LeftTop ); // 3

            // Back
            AddVertex( 0, 0, Size.Z, Vertex.TypeVertex.Back_LeftBottom ); // 4
            AddVertex( Size.X, 0, Size.Z, Vertex.TypeVertex.Back_RightBottom ); // 5
            AddVertex( Size.X, Size.Y, Size.Z, Vertex.TypeVertex.Back_RightTop ); // 6
            AddVertex( 0, Size.Y, Size.Z, Vertex.TypeVertex.Back_LeftTop ); // 7

            InitIdVertex( PrimitivesType.Cube );
            GenerateTextureCoords();
            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        public void Create( Vector3f Position )
        {
            Dictionary<string, string> TmpValues = listEntity.Entity[ Program.SelectEntity[ "Entity" ] ][ "Value" ];
            Dictionary<string, string> TmpSettings = listEntity.Entity[ Program.SelectEntity[ "Entity" ] ][ "Settings" ];

            brushType = BasicBrush.BrushType.Entity;
            this.Position = Program.Align( Position, Viewport.fSize );
            EntityName = Program.SelectEntity[ "Entity" ];
            Size = new Vector3f( TmpSettings[ "Size" ] );
            SelectSize = new Vector3f( Size / 2 );
            ColorBrush = DefaultColorBrush = new Color( TmpSettings[ "Color" ] );
       
            for ( int i = 0; i < TmpValues.Keys.Count; i++ )
                mValues[ TmpValues.Keys.ToList()[ i ].ToString() ] = TmpValues[ TmpValues.Keys.ToList()[ i ] ];

            // Front
            AddVertex( 0, 0, 0, Vertex.TypeVertex.LeftBottom ); // 0
            AddVertex( Size.X, 0, 0, Vertex.TypeVertex.RightBottom ); // 1
            AddVertex( Size.X, Size.Y, 0, Vertex.TypeVertex.RightTop ); // 2
            AddVertex( 0, Size.Y, 0, Vertex.TypeVertex.LeftTop ); // 3

            // Back
            AddVertex( 0, 0, Size.Z, Vertex.TypeVertex.Back_LeftBottom ); // 4
            AddVertex( Size.X, 0, Size.Z, Vertex.TypeVertex.Back_RightBottom ); // 5
            AddVertex( Size.X, Size.Y, Size.Z, Vertex.TypeVertex.Back_RightTop ); // 6
            AddVertex( 0, Size.Y, Size.Z, Vertex.TypeVertex.Back_LeftTop ); // 7

            InitIdVertex( PrimitivesType.Cube );
            GenerateTextureCoords();
            ToGloablCoords();
        }

        //-------------------------------------------------------------------------//

        public void ShowProperties()
        {
            EntityProperties entityProperties = new EntityProperties( EntityName, mValues );

            if ( entityProperties.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                mValues = entityProperties.GetValues();
        }

        //-------------------------------------------------------------------------//

        public SaveEntity ToSave()
        {
            SaveEntity saveEntity = new SaveEntity();      
            saveEntity.EntityName = EntityName;
            saveEntity.Position = Position;
            saveEntity.Values = mValues;

            return saveEntity;
        }

        //-------------------------------------------------------------------------//

        public static ListEntity listEntity;

        private string EntityName;
        private Dictionary<string, string> mValues = new Dictionary<string, string>();
    }
}
