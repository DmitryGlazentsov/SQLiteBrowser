using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace SQLiteBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            structureData.ColumnWidth = new DataGridLength(150);
        }

        private void openDbFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            string filePath;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "SQLite database files (*.sqlite)| *.sqlite";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                if ((filePath = openFileDialog1.FileName) != null)
                {
                    try
                    {
                        string connectionString = @"Data source=" + filePath;

                        using (SQLiteConnection myDbConnection = new SQLiteConnection(connectionString)) {
                            myDbConnection.Open();

                            const string tableCountQuery = "SELECT COUNT(*) FROM sqlite_master WHERE type='table'";
                            SQLiteCommand tableCountCmd = new SQLiteCommand(tableCountQuery, myDbConnection);
                            int nTables = Convert.ToInt32(tableCountCmd.ExecuteScalar());

                            TreeViewItem topLevelHeader = new TreeViewItem() { Header = "Таблицы " + "(" + nTables + ")" };
                            treeView.Items.Add(topLevelHeader);

                            var dataAboutTablesFromSchema = myDbConnection.GetSchema("Tables");
                            var tablesNamesList = new List<string>();

                            foreach (System.Data.DataRow row in dataAboutTablesFromSchema.Rows)
                            {
                                var name = row[2].ToString();
                                tablesNamesList.Add(name);
                            }

                            foreach (var tableName in tablesNamesList)
                            {
                                topLevelHeader.Items.Add(new TreeViewItem() { Header = tableName, Tag = tableName });
                            }
                            foreach (TreeViewItem midLevelItem in topLevelHeader.Items)
                            {
                                using (var cmd = new SQLiteCommand("PRAGMA table_info(" + midLevelItem.Tag + ")", myDbConnection))
                                {
                                    var table = new System.Data.DataTable();
                                    SQLiteDataAdapter adp = null;
                                    try
                                    {
                                        adp = new SQLiteDataAdapter(cmd);
                                        adp.Fill(table);
                                        for (int i = 0; i < table.Rows.Count; i++)
                                        {
                                            midLevelItem.Items.Add(new TreeViewItem() { Header = table.Rows[i]["name"] + " " + table.Rows[i]["type"], Tag = table.Rows[i]["name"] });
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Something going wrong...\n Original error: " + ex.Message);
                                    }
                                }
                            }
                            myDbConnection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something going wrong... \n Original error: " + ex.Message);
                    }
                }

            }
        }

        private void createNewDbBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //DataGrid dataGridWithAttributes;
        private void createTable1_Click(object sender, RoutedEventArgs e)
        {

            CreateTableWindow createTableWindow = new CreateTableWindow();
            createTableWindow.Show();
        }
    }
}
