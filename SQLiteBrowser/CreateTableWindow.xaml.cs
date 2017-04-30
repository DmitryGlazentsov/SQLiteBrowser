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
            dataGrid.Items.Refresh();
        }
        private void removeAttributeBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Attribute)dataGrid.SelectedItem;
            attributeList.Remove(selectedItem);
            dataGrid.Items.Refresh();
        }
        private void toUpAttributeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var selectedItem = (Attribute)dataGrid.SelectedItem;
                var indexOfSelectedItem = attributeList.IndexOf(selectedItem);
                
                if(indexOfSelectedItem > 0)
                {
                    Attribute tmp = attributeList[indexOfSelectedItem-1];
                    attributeList[indexOfSelectedItem - 1] = selectedItem;
                    attributeList[indexOfSelectedItem] = tmp;
                }
                dataGrid.Items.Refresh();
            }
            
        }
        private void toDownAttributeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                var selectedItem = (Attribute)dataGrid.SelectedItem;
                var indexOfSelectedItem = attributeList.IndexOf(selectedItem);

                if(indexOfSelectedItem < dataGrid.Items.Count-1)
                { 
                    Attribute tmp = attributeList[indexOfSelectedItem + 1];
                    attributeList[indexOfSelectedItem + 1] = selectedItem;
                    attributeList[indexOfSelectedItem] = tmp;
                }
            }
            dataGrid.Items.Refresh();
        }

        private void dataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var rowsCount = dataGrid.Items.Count;
            for(int i =0; i<rowsCount; i++)
            {
                attributeList[i] = (Attribute)dataGrid.Items.GetItemAt(i);
            }
        }
    }
}
