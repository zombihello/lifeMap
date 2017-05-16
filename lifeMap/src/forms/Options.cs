using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            trackBar_intensity.Value = 30;
            trackBar_renderDistance.Value = 1000;
            checkBox_filterTextures.Checked = true;
            textBox_cameraFOV.Text = 45.ToString();
        }

        //-------------------------------------------------------------------------//

        private void button_browse_Click( object sender, EventArgs e ) // BROWSE GAME EXECUTABLE
        {
            folderBrowser.Description = "Select Game Executable Directory (ex C:\\Game):";

            if ( folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                textBox_gameExecutable.Text = folderBrowser.SelectedPath;
        }

        //-------------------------------------------------------------------------//

        private void button_browseTextureDirectory_Click( object sender, EventArgs e ) // BROWSE TEXTURES DIRECTORY
        {
            folderBrowser.Description = "Select Textures Directory (ex C:\\Game\\Textures):";

            if ( folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                textBox_texturesDirectory.Text = folderBrowser.SelectedPath;
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
                            mTextBoxExecutableDir.Remove( Configuration );
                            mTextBoxTexturesDir.Remove( Configuration );
                            mTextBoxExportMapDir.Remove( Configuration );
                            mTextBoxSrcMapDir.Remove( Configuration );

                            TempConfiguration = null;
                            textBox_gameExecutable.Text = "";
                            textBox_texturesDirectory.Text = "";
                            textBox_exportMapDirectory.Text = "";
                            textBox_srcMapDirectory.Text = "";

                            comboBox_configuration.Items.RemoveAt( i );
                            comboBox_configuration.SelectedIndex = -1;
                            listBox_gameDataFiles.Items.Clear();
                        }
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

                mTextBoxExecutableDir[ TempConfiguration ] = textBox_gameExecutable.Text.ToString();
                mTextBoxTexturesDir[ TempConfiguration ] = textBox_texturesDirectory.Text.ToString();
                mTextBoxExportMapDir[ TempConfiguration ] = textBox_exportMapDirectory.Text.ToString();
                mTextBoxSrcMapDir[ TempConfiguration ] = textBox_srcMapDirectory.Text.ToString();
            }

            TempConfiguration = configuration[ comboBox_configuration.SelectedIndex ].ToString();
            listBox_gameDataFiles.Items.Clear();

            for ( int i = 0; i < mListBox[ TempConfiguration ].Items.Count; i++ )
                listBox_gameDataFiles.Items.Add( mListBox[ TempConfiguration ].Items[ i ] );

            textBox_gameExecutable.Text = mTextBoxExecutableDir[ TempConfiguration ].ToString();
            textBox_texturesDirectory.Text = mTextBoxTexturesDir[ TempConfiguration ];
            textBox_exportMapDirectory.Text = mTextBoxExportMapDir[ TempConfiguration ];
            textBox_srcMapDirectory.Text = mTextBoxSrcMapDir[ TempConfiguration ];
        }

        //-------------------------------------------------------------------------//

        private void button_ok_Click( object sender, EventArgs e ) // OK
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        //-------------------------------------------------------------------------//

        public int GetSizeGrid()
        {
            return Convert.ToInt32( comboBox_sizeGrid.Items[ comboBox_sizeGrid.SelectedIndex ]);
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

        private EditConfiguration editConfiguration = new EditConfiguration();
        private FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private string TempConfiguration;
        private Dictionary<string, ListBox> mListBox = new Dictionary<string, ListBox>();
        private Dictionary<string, string> mTextBoxExecutableDir = new Dictionary<string, string>();
        private Dictionary<string, string> mTextBoxTexturesDir = new Dictionary<string, string>();
        private Dictionary<string, string> mTextBoxExportMapDir = new Dictionary<string, string>();
        private Dictionary<string, string> mTextBoxSrcMapDir = new Dictionary<string, string>();
    }
}
