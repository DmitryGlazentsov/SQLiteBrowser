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
using System.Windows.Shapes;

namespace SQLiteBrowser
{
    /// <summary>
    /// Interaction logic for CreateTableWindow.xaml
    /// </summary>

    //public class dataTypesEnum:List<string>
    //{
    //    public dataTypesEnum() { 
    //        this.Add("INTEGER");
    //        this.Add("TEXT");
    //        this.Add("BLOB");
    //        this.Add("REAL");
    //        this.Add("NUMERIC");
    //    }
    //}

    
    public partial class CreateTableWindow : Window
    {
        public CreateTableWindow()
        {
            InitializeComponent();
        }

        List<Attribute> attributeList;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var editingDbTablesWindow = this;
            attributeList = new List<Attribute>();
            dataGrid.ItemsSource = attributeList;

            editingDbTablesWindow.Content = mainGridOfEditWindow;
            editingDbTablesWindow.Show();
        }

        private void addAttributeBtn_Click(object sender, RoutedEventArgs e)
        {
            attributeList.Add(
                new Attribute
                {
                    attributeName = String.Empty,
                    typeOfAttribute = String.Empty,
                    autoIncrementProperty = false,
                    isNullAttribute = false,
                    uniqeProperty = false
                });

            dataGrid.ItemsSource = attributeList;
        }
        private void removeAttributeBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dataGrid.SelectedItem;
            foreach (var item in attributeList)
            {
                //if(item.attributeName == selectedItem.
            }

        }
        private void toUpAttributeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void toDownAttributeBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
