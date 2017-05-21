using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using lifeMap.src.system;

namespace lifeMap.src
{
    public partial class Options : Form
    {
        //-------------------------------------------------------------------------//

        public Options()
        {
            InitializeComponent();

            openFileDialog.Filter = "Data Entity Game | *.deg";

            comboBox_sizeGrid.SelectedIndex = 2;
            trackBar_intensity.Value = 20;
            trackBar_renderDistance.Value = 1000;
            checkBox_filterTextures.Checked = true;
            textBox_cameraFOV.Text = 45.ToString();
        }

        //-------------------------------------------------------------------------//

        private void button_browse_Click( object sender, EventArgs e ) // BROWSE GAME EXECUTABLE
        {
            openFileDialog.Filter = "Executable | *.exe";

            if ( openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                if ( openFileDialog.FileName.Contains( textBox_gameDirectory.Text ) )
                    textBox_gameExecutable.Text = openFileDialog.FileName;
                else
                    MessageBox.Show( "Executable File Should Be Placed In The Game Directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        //-------------------------------------------------------------------------//

        private void button_browseTextureDirectory_Click( object sender, EventArgs e ) // BROWSE TEXTURES DIRECTORY
        {
            folderBrowser.Description = "Select Textures Directory (ex C:\\Game\\Textures):";

            if ( folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                if ( folderBrowser.SelectedPath.Contains( textBox_gameDirectory.Text ) )
                    textBox_texturesDirectory.Text = folderBrowser.SelectedPath;
                else
                    MessageBox.Show( "Textures Directory Should Be Placed In The Game Directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        //-------------------------------------------------------------------------//

        private void button_exportMapDirectory_Click( object sender, EventArgs e ) // BROWSE EXPORT MAP DIRECTORY
        {
            folderBrowser.Description = "Select Export Map Directory (ex C:\\Game\\Maps):";

            if ( folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                textBox_exportMapDirectory.Text = folderBrowser.SelectedPath;
        }

        //-------------------------------------------------------------------------//

        private void button_browseSrcMapDirectory_Click( object sender, EventArgs e ) // BROWSE SRC MAP DIRECTORY
        {
            folderBrowser.Description = "Select lifeMap MAP Directory (ex C:\\GameSrc\\MapSrc):";

            if ( folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                textBox_srcMapDirectory.Text = folderBrowser.SelectedPath;
        }

        //-------------------------------------------------------------------------//

        private void button_browse_gameDir( object sender, EventArgs e ) // BROWSE GAME DIRECTORY
        {
            folderBrowser.Description = "Select Game Directory (ex C:\\Game):";

            if ( folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                textBox_gameDirectory.Text = folderBrowser.SelectedPath;
        }

        //-------------------------------------------------------------------------//

        private void button_add_Click( object sender, EventArgs e ) // ADD DATA ENTITY GAME
        {
            if ( openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                bool IsFind = false;

                for ( int i = 0; i < listBox_gameDataFiles.Items.Count; i++ )
                    if ( listBox_gameDataFiles.Items[ i ].ToString() == openFileDialog.FileName )
                    {
                        IsFind = true;
                        break;
                    }

                if ( !IsFind )
                    listBox_gameDataFiles.Items.Add( openFileDialog.FileName );
            }
        }

        //-------------------------------------------------------------------------//

        private void button_remove_Click( object sender, EventArgs e ) // REMOVE DATA ENTITY GAME
        {
            if ( listBox_gameDataFiles.SelectedIndex > -1 )
                listBox_gameDataFiles.Items.RemoveAt( listBox_gameDataFiles.SelectedIndex );
        }

        //-------------------------------------------------------------------------//

        private void button_edit_Click( object sender, EventArgs e ) // EDIT DATA ENTITY GAME
        {
            if ( listBox_gameDataFiles.SelectedIndex > -1 )
                System.Diagnostics.Process.Start( "notepad.exe", listBox_gameDataFiles.Items[ listBox_gameDataFiles.SelectedIndex ].ToString() );
        }

        //-------------------------------------------------------------------------//

        private void button_editConfiguration_Click( object sender, EventArgs e ) // EDIT CONFIGURATION
        {
            editConfiguration.SetListConfigurations( comboBox_configuration.Items );
            editConfiguration.ShowDialog();

            ListBox.ObjectCollection configuration = editConfiguration.GetListConfigurations();

            if ( comboBox_configuration.Items.Count != configuration.Count )
                if ( comboBox_configuration.Items.Count < configuration.Count )
                {
                    for ( int i = 0; i < configuration.Count; i++ )
                        if ( comboBox_configuration.Items.IndexOf( configuration[ i ] ) == -1 )
                        {
                            string Configuration = configuration[ i ].ToString();
                            comboBox_configuration.Items.Add( Configuration );

                            mListBox[ Configuration ] = new ListBox();
                            mTextBoxGameDirectory[ Configuration ] = "";
                            mTextBoxExecutableDir[ Configuration ] = "";
                            mTextBoxTexturesDir[ Configuration ] = "";
                            mTextBoxExportMapDir[ Configuration ] = "";
                            mTextBoxSrcMapDir[ Configuration ] = "";
                        }
                }
                else
                {
                    for ( int i = 0; i < comboBox_configuration.Items.Count; i++ )
                        if ( configuration.IndexOf( comboBox_configuration.Items[ i ] ) == -1 )
                        {
                            string Configuration = comboBox_configuration.Items[ i ].ToString();

                            mListBox.Remove( Configuration );
                            mTextBoxGameDirectory.Remove( Configuration );
                            mTextBoxExecutableDir.Remove( Configuration );
                            mTextBoxTexturesDir.Remove( Configuration );
                            mTextBoxExportMapDir.Remove( Configuration );
                            mTextBoxSrcMapDir.Remove( Configuration );

                            TempConfiguration = null;
                            textBox_gameDirectory.Text = "";
                            textBox_gameExecutable.Text = "";
                            textBox_texturesDirectory.Text = "";
                            textBox_exportMapDirectory.Text = "";
                            textBox_srcMapDirectory.Text = "";

                            comboBox_configuration.Items.RemoveAt( i );
                            comboBox_configuration.SelectedIndex = -1;
                            listBox_gameDataFiles.Items.Clear();
                        }

                    EnableGeneral( false );
                }
        }

        //-------------------------------------------------------------------------//

        private void comboBox_configuration_SelectedIndexChanged( object sender, EventArgs e )
        {
            ComboBox.ObjectCollection configuration = comboBox_configuration.Items;

            if ( TempConfiguration != null )
            {
                mListBox[ TempConfiguration ].Items.Clear();

                for ( int i = 0; i < listBox_gameDataFiles.Items.Count; i++ )
                    mListBox[ TempConfiguration ].Items.Add( listBox_gameDataFiles.Items[ i ] );

                mTextBoxGameDirectory[ TempConfiguration ] = textBox_gameDirectory.Text.ToString();
                mTextBoxExecutableDir[ TempConfiguration ] = textBox_gameExecutable.Text.ToString();
                mTextBoxTexturesDir[ TempConfiguration ] = textBox_texturesDirectory.Text.ToString();
                mTextBoxExportMapDir[ TempConfiguration ] = textBox_exportMapDirectory.Text.ToString();
                mTextBoxSrcMapDir[ TempConfiguration ] = textBox_srcMapDirectory.Text.ToString();
            }

            if ( comboBox_configuration.SelectedIndex > -1 )
            {
                if ( !IsEnableGeneral )
                    EnableGeneral( true );

                TempConfiguration = configuration[ comboBox_configuration.SelectedIndex ].ToString();
                listBox_gameDataFiles.Items.Clear();

                for ( int i = 0; i < mListBox[ TempConfiguration ].Items.Count; i++ )
                    listBox_gameDataFiles.Items.Add( mListBox[ TempConfiguration ].Items[ i ] );

                textBox_gameDirectory.Text = mTextBoxGameDirectory[ TempConfiguration ].ToString();
                textBox_gameExecutable.Text = mTextBoxExecutableDir[ TempConfiguration ].ToString();
                textBox_texturesDirectory.Text = mTextBoxTexturesDir[ TempConfiguration ];
                textBox_exportMapDirectory.Text = mTextBoxExportMapDir[ TempConfiguration ];
                textBox_srcMapDirectory.Text = mTextBoxSrcMapDir[ TempConfiguration ];
            }
        }

        //-------------------------------------------------------------------------//

        private void button_ok_Click( object sender, EventArgs e ) // OK
        {
            int cameraFOV = Convert.ToInt32( textBox_cameraFOV.Text );

            if ( cameraFOV >= 30 && cameraFOV <= 100 )
            {
                if ( TempConfiguration != null )
                {
                    mListBox[ TempConfiguration ].Items.Clear();

                    for ( int i = 0; i < listBox_gameDataFiles.Items.Count; i++ )
                        mListBox[ TempConfiguration ].Items.Add( listBox_gameDataFiles.Items[ i ] );

                    mTextBoxGameDirectory[ TempConfiguration ] = textBox_gameDirectory.Text.ToString();
                    mTextBoxExecutableDir[ TempConfiguration ] = textBox_gameExecutable.Text.ToString();
                    mTextBoxTexturesDir[ TempConfiguration ] = textBox_texturesDirectory.Text.ToString();
                    mTextBoxExportMapDir[ TempConfiguration ] = textBox_exportMapDirectory.Text.ToString();
                    mTextBoxSrcMapDir[ TempConfiguration ] = textBox_srcMapDirectory.Text.ToString();
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show( "Camera FOV Must Be In The Limit [30;100]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }

        //-------------------------------------------------------------------------//

        public int GetSizeGrid()
        {
            return Convert.ToInt32( comboBox_sizeGrid.Items[ comboBox_sizeGrid.SelectedIndex ] );
        }

        //-------------------------------------------------------------------------//

        public int GetIntensity()
        {
            return trackBar_intensity.Value;
        }

        //-------------------------------------------------------------------------//

        public int GetRenderDistance()
        {
            return trackBar_renderDistance.Value;
        }

        //-------------------------------------------------------------------------//

        public int GetCameraFOV()
        {
            return Convert.ToInt32( textBox_cameraFOV.Text );
        }

        //-------------------------------------------------------------------------//

        public bool GetFilterTexture()
        {
            return checkBox_filterTextures.Checked;
        }

        //-------------------------------------------------------------------------//

        public string GetGameExecutable()
        {
            return textBox_gameExecutable.Text;
        }

        //-------------------------------------------------------------------------//

        public string GetTexturesDirecoty()
        {
            return textBox_texturesDirectory.Text;
        }

        //-------------------------------------------------------------------------//

        public string GetExportMapDirectory()
        {
            return textBox_exportMapDirectory.Text;
        }

        //-------------------------------------------------------------------------//

        public string GetSrcMapDirectory()
        {
            return textBox_srcMapDirectory.Text;
        }

        //-------------------------------------------------------------------------//

        public string GetGameDirectory()
        {
            return textBox_gameDirectory.Text;
        }

        //-------------------------------------------------------------------------//

        public SaveGeneral ToSaveGeneral()
        {
            SaveGeneral saveGeneral = new SaveGeneral();

            var Configuration = comboBox_configuration.Items;

            saveGeneral.SelectConfiguration = TempConfiguration;

            for ( int i = 0; i < Configuration.Count; i++ )
            {
                string nameConfiguration = Configuration[ i ].ToString();
                var GameDataFiles = mListBox[ nameConfiguration ].Items;

                saveGeneral.Configurations.Add( nameConfiguration );
                saveGeneral.GameDataFiles[ nameConfiguration ] = new List<string>();

                for ( int j = 0; j < GameDataFiles.Count; j++ )
                    saveGeneral.GameDataFiles[ nameConfiguration ].Add( GameDataFiles[ j ].ToString() );

                saveGeneral.GameDirectory[ nameConfiguration ] = mTextBoxGameDirectory[ nameConfiguration ];
                saveGeneral.GameExecutableDirectory[ nameConfiguration ] = mTextBoxExecutableDir[ nameConfiguration ];
                saveGeneral.TexturesDirectory[ nameConfiguration ] = mTextBoxTexturesDir[ nameConfiguration ];
                saveGeneral.ExportMapDirectory[ nameConfiguration ] = mTextBoxExportMapDir[ nameConfiguration ];
                saveGeneral.lifeMapMAPDirectory[ nameConfiguration ] = mTextBoxSrcMapDir[ nameConfiguration ];
            }


            return saveGeneral;
        }

        //-------------------------------------------------------------------------//

        public SaveViews ToSaveViews()
        {
            SaveViews saveViews = new SaveViews();

            saveViews.SizeGrid = GetSizeGrid();
            saveViews.Intensity = GetIntensity();
            saveViews.FilterTexture = GetFilterTexture();
            saveViews.RenderDistance = GetRenderDistance();
            saveViews.CameraFOV = GetCameraFOV();

            return saveViews;
        }

        //-------------------------------------------------------------------------//

        public void LoadGeneral( SaveGeneral saveGeneral )
        {
            for ( int i = 0; i < saveGeneral.Configurations.Count; i++ )
            {
                string nameConfiguration = saveGeneral.Configurations[ i ];
                comboBox_configuration.Items.Add( nameConfiguration );

                mListBox[ nameConfiguration ] = new ListBox();

                for ( int j = 0; j < saveGeneral.GameDataFiles[ nameConfiguration ].Count; j++ )
                    mListBox[ nameConfiguration ].Items.Add( saveGeneral.GameDataFiles[ nameConfiguration ][ j ] );

                mTextBoxGameDirectory[ nameConfiguration ] = saveGeneral.GameDirectory[ nameConfiguration ];
                mTextBoxExecutableDir[ nameConfiguration ] = saveGeneral.GameExecutableDirectory[ nameConfiguration ];
                mTextBoxTexturesDir[ nameConfiguration ] = saveGeneral.TexturesDirectory[ nameConfiguration ];
                mTextBoxExportMapDir[ nameConfiguration ] = saveGeneral.ExportMapDirectory[ nameConfiguration ];
                mTextBoxSrcMapDir[ nameConfiguration ] = saveGeneral.lifeMapMAPDirectory[ nameConfiguration ];
            }

            for ( int i = 0; i < comboBox_configuration.Items.Count; i++ )
                if ( comboBox_configuration.Items[ i ].ToString() == saveGeneral.SelectConfiguration )
                {
                    comboBox_configuration.SelectedIndex = i;
                    break;
                }
        }

        //-------------------------------------------------------------------------//

        public void LoadViews( SaveViews saveViews )
        {
            for ( int i = 0; i < comboBox_sizeGrid.Items.Count; i++ )
                if ( comboBox_sizeGrid.Items[ i ].ToString() == saveViews.SizeGrid.ToString() )
                {
                    comboBox_sizeGrid.SelectedIndex = i;
                    break;
                }

            trackBar_intensity.Value = saveViews.Intensity;
            trackBar_renderDistance.Value = saveViews.RenderDistance;
            checkBox_filterTextures.Checked = saveViews.FilterTexture;
            textBox_cameraFOV.Text = saveViews.CameraFOV.ToString();
        }

        //-------------------------------------------------------------------------//

        private void EnableGeneral( bool enable )
        {
            IsEnableGeneral = enable;

            textBox_gameDirectory.Enabled = enable;
            button_gameDirectory.Enabled = enable;
            listBox_gameDataFiles.Enabled = enable;
            button_add.Enabled = enable;
            button_edit.Enabled = enable;
            button_remove.Enabled = enable;
            textBox_gameExecutable.Enabled = enable;
            button_browse.Enabled = enable;
            textBox_texturesDirectory.Enabled = enable;
            button_browseTextureDirectory.Enabled = enable;
            textBox_exportMapDirectory.Enabled = enable;
            button_exportMapDirectory.Enabled = enable;
            textBox_srcMapDirectory.Enabled = enable;
            button_browseSrcMapDirectory.Enabled = enable;
        }

        //-------------------------------------------------------------------------//

        private EditConfiguration editConfiguration = new EditConfiguration();
        private FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private bool IsEnableGeneral = false;
        private string TempConfiguration;
        private Dictionary<string, ListBox> mListBox = new Dictionary<string, ListBox>();
        private Dictionary<string, string> mTextBoxExecutableDir = new Dictionary<string, string>();
        private Dictionary<string, string> mTextBoxGameDirectory = new Dictionary<string, string>();
        private Dictionary<string, string> mTextBoxTexturesDir = new Dictionary<string, string>();
        private Dictionary<string, string> mTextBoxExportMapDir = new Dictionary<string, string>();
        private Dictionary<string, string> mTextBoxSrcMapDir = new Dictionary<string, string>();
    }
}
