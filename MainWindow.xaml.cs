using LanguageClassTest.Models;
using LanguageClassTest.Services;
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

namespace LanguageClassTest
{
    public partial class MainWindow : Window
    {
        LanguageModel language;
        public MainWindow()
        {
            InitializeComponent();

            language = new LanguageModel();
            
            App.LanguageUpdated += LangUpdate;
        }
        
         //Оповещаемый метод
        private void LangUpdate(Models.LanguageModel lang)
        {
            //поиск по name'ам
            foreach (var item in lang.Translate)
            {
                //поиск всех TEXTBLOCK с нужным Name
                var txtblocks = UIFinder.FindVisualChildren<TextBlock>(xGrid).FirstOrDefault(x => x.Name == item.Name);
                if (txtblocks != null)
                {
                    txtblocks.Text = item.Value;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
            //Проверка системы на русском
            App.CurrentLanguage = new LanguageModel();
            language = new LanguageModel()
            {
                Translate = new List<Field<string>>()
                {
                    ("Element1", "Привет"),
                    ("Element2", "Друг"),
                }
            };
            App.CurrentLanguage = language;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //Проверка системы на китайском
            App.CurrentLanguage = new LanguageModel();
            language = new LanguageModel() { Translate = new List<Field<string>>()
                {
                    ("Element1", "你好"),
                    ("Element2", "朋友"),
                }
            };
            var txt = XmlConverter.ToXaml(language);
            System.IO.File.WriteAllText(@"C:\Users\student1\Desktop\lol.txt", txt);
            App.CurrentLanguage = language;
        }
    }
}
