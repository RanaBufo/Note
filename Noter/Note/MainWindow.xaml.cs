using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Note
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            InitializeComponent();
        }

        int x = 0, y = 0;
        string str = "", str1 = "";
        private void f1(object sender, RoutedEventArgs e)
        {
            if(x == 0) {
                TranslateTransform trans = new TranslateTransform();
                H.RenderTransform = trans;
                DoubleAnimation OpenY = new DoubleAnimation(0, 170, TimeSpan.FromSeconds(1));
                trans.BeginAnimation(TranslateTransform.YProperty, OpenY);
                x = 1;
            }
            else
            {
                TranslateTransform trans = new TranslateTransform();
                H.RenderTransform = trans;
                DoubleAnimation OpenY = new DoubleAnimation(0, -170, TimeSpan.FromSeconds(1));
                trans.BeginAnimation(TranslateTransform.YProperty, OpenY);
                x = 0;
            }
            

        }
        
        private void fOpen(object sender, RoutedEventArgs e)
        {
            if (t1.Text != "" || str1 != t1.Text)
            {
                string messageBoxText = "Ты хочешь сохранить файл?";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult res;

                res = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);

                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        // User pressed Cancel
                        break;
                    case MessageBoxResult.OK:
                        if (str != "" )
                        {
                            File.WriteAllText(str, String.Empty);
                            File.WriteAllText(str, t1.Text);
                        }
                        else
                        {
                            // Configure save file dialog box
                            Microsoft.Win32.SaveFileDialog ggg = new Microsoft.Win32.SaveFileDialog();
                            ggg.FileName = "Document"; // Default file name
                            ggg.DefaultExt = ".txt"; // Default file extension
                            ggg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                            // Show save file dialog box
                            Nullable<bool> resul = ggg.ShowDialog();

                            // Process save file dialog box results
                            if (resul == true)
                            {
                                // Save document
                                string filename = ggg.FileName;
                                str = filename;
                                File.WriteAllText(filename, t1.Text);

                            }
                            y = 0;
                        }
                        break;
                }
            }

            if (str != "" & str1 != t1.Text) { 
                
            }
           
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    // Open document
                    string filename = dlg.FileName;
                    StreamReader sr = new StreamReader(filename);
                    t1.Text = sr.ReadToEnd();
                    str1 = t1.Text;
                    str = filename;
                    sr.Close();

                }
            
            TranslateTransform trans = new TranslateTransform();
            H.RenderTransform = trans;
            DoubleAnimation OpenY = new DoubleAnimation(0, -170, TimeSpan.FromSeconds(1));
            trans.BeginAnimation(TranslateTransform.YProperty, OpenY);
            x = 0;
        }

        private void fSave(object sender, RoutedEventArgs e)
        {
            if(str != "" & y == 1)
            {
                File.WriteAllText(str, String.Empty);
                File.WriteAllText(str, t1.Text);
            }
            TranslateTransform trans = new TranslateTransform();
            H.RenderTransform = trans;
            DoubleAnimation OpenY = new DoubleAnimation(0, -170, TimeSpan.FromSeconds(1));
            trans.BeginAnimation(TranslateTransform.YProperty, OpenY);
            x = 0;
        }

        private void xxx(object sender, RoutedEventArgs e)
        {
            if (t1.Text != "" || str1 != t1.Text)
            {
                string messageBoxText = "Ты хочешь сохранить файл?";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult res;

                res = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);

                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        // User pressed Cancel
                        break;
                    case MessageBoxResult.OK:
                        if (str != "")
                        {
                            File.WriteAllText(str, String.Empty);
                            File.WriteAllText(str, t1.Text);
                        }
                        else
                        {
                            // Configure save file dialog box
                            Microsoft.Win32.SaveFileDialog ggg = new Microsoft.Win32.SaveFileDialog();
                            ggg.FileName = "Document"; // Default file name
                            ggg.DefaultExt = ".txt"; // Default file extension
                            ggg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                            // Show save file dialog box
                            Nullable<bool> resul = ggg.ShowDialog();

                            // Process save file dialog box results
                            if (resul == true)
                            {
                                // Save document
                                string filename = ggg.FileName;
                                str = filename;
                                File.WriteAllText(filename, t1.Text);

                            }
                            y = 0;
                        }
                        break;
                }
            }
            Application.Current.Shutdown();
        }

        private void fSaveAs(object sender, RoutedEventArgs e)
        {
            if (str != "" || y == 1 || (str == "" & t1.Text != ""))
            {
                // Configure save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;
                    str = filename;
                    File.WriteAllText(filename, t1.Text);

                }
                y = 0;
            }
            TranslateTransform trans = new TranslateTransform();
            H.RenderTransform = trans;
            DoubleAnimation OpenY = new DoubleAnimation(0, -170, TimeSpan.FromSeconds(1));
            trans.BeginAnimation(TranslateTransform.YProperty, OpenY);
            x = 0;
        }

        private void fNew(object sender, RoutedEventArgs e)
        {
            if (t1.Text != "" || str1 != t1.Text)
            {
                string messageBoxText = "Ты хочешь сохранить файл?";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult res;

                res = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);

                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        // User pressed Cancel
                        break;
                    case MessageBoxResult.OK:
                        if (str != "")
                        {
                            File.WriteAllText(str, String.Empty);
                            File.WriteAllText(str, t1.Text);
                        }
                        else
                        {
                            // Configure save file dialog box
                            Microsoft.Win32.SaveFileDialog ggg = new Microsoft.Win32.SaveFileDialog();
                            ggg.FileName = "Document"; // Default file name
                            ggg.DefaultExt = ".txt"; // Default file extension
                            ggg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                            // Show save file dialog box
                            Nullable<bool> resul = ggg.ShowDialog();

                            // Process save file dialog box results
                            if (resul == true)
                            {
                                // Save document
                                string filename = ggg.FileName;
                                str = filename;
                                File.WriteAllText(filename, t1.Text);

                            }
                            y = 0;
                        }
                        break;
                }
            }
            t1.Text = "";
            str = "";
            str1 = "";
            y = 1;
            TranslateTransform trans = new TranslateTransform();
            H.RenderTransform = trans;
            DoubleAnimation OpenY = new DoubleAnimation(0, -170, TimeSpan.FromSeconds(1));
            trans.BeginAnimation(TranslateTransform.YProperty, OpenY);
            x = 0;
        }
    }
}
