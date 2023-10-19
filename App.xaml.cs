using LanguageClassTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LanguageClassTest
{
    /// <summary>
    /// Свободная реализация смены языка
    /// </summary>
    public partial class App : Application
    {
        private static LanguageModel _languageModel = new LanguageModel();
        public delegate void LanguageUpdate(LanguageModel model);
        public static event LanguageUpdate LanguageUpdated;
        
        public static LanguageModel CurrentLanguage { get => _languageModel; set
            {
                _languageModel = value;
                LanguageUpdated?.Invoke(value);
            }
        }


        public static List<LanguageModel> Languages { get; set; }
    }
}
