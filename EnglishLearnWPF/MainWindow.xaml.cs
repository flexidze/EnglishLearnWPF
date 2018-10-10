﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;     /// для streamreader, streamwriter
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
using System.Windows.Forms;
using System.Collections.ObjectModel; /// <Необходимо для observable Collection>
///using ;
/// 
/// </summary>


namespace EnglishLearnWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Dict
    {
        public string english { get; set; }
        public string russian { get; set; }
        public bool learned { get; set; }
    }


    /// public class 

    public partial class MainWindow : Window
    {
        ObservableCollection<Dict> myDict = new ObservableCollection<Dict>
            {
                new Dict { english = "1", russian = "1", learned = false }
            };

        public MainWindow()
        {
              InitializeComponent();
        }

        public void loadDict(object sender, RoutedEventArgs e)
        {
            bool tr = false;
            string nameFile = "c:/temp/123.txt";
            string tempString="";
            StreamReader sr = new StreamReader(nameFile);
                   Hello.Content= tr;
            
            tempString = sr.ReadLine();
            while (tempString!=null)
            {
                string[] arrString = tempString.Split(':');
                myDict.Add(new Dict { english = arrString[0], russian = arrString[1], learned = Boolean.Parse(arrString[2]) });///
                tempString = sr.ReadLine();
                button3.Background = new SolidColorBrush(Colors.Green);
                button3.Content = "rgergrt";
            }
    dataGrid.ItemsSource = myDict;

            sr.Close();

        }

        public void Button2_Click(object sender, RoutedEventArgs e)
        {

            dataGrid.ItemsSource = myDict;

        }

        private void DataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)

        {

            StreamWriter sr = new StreamWriter("c:/temp/123.txt");
            dataGrid.ItemsSource = myDict;
            foreach (Dict Dict in myDict)
                     sr.WriteLine(Dict.english+":"+Dict.russian+":"+Dict.learned);

            sr.Close();
            Hello.Background = new SolidColorBrush(Colors.Red);                ;
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(dataGrid, "moi file");
            }
        }
    }
}
