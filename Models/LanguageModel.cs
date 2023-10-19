using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LanguageClassTest.Models
{
    public class Field<T>
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public T Value { get; set; }

        public static implicit operator Field<T>(string name)
        {
            return new Field<T> { Name = name};
        }

        public static implicit operator Field<T>((string, T) value)
        {
            return new Field<T> { Name = value.Item1, Value = value.Item2 };
        }

        public static explicit operator T(Field<T> field)
        {
            return field.Value;
        }
    }

    //Модель языка
    public class LanguageModel
    {
        [XmlElement("Language")]
        public Field<string> LanguageName { get; set; } = "Русский";

        [XmlElement("LanguageCode")]
        public Field<string> Code { get; set; } = "ru-RU";

        //Сопоставление Name элемента в XAML с необходимым для передачи значением.
        [XmlArray()]
        public List<Field<string>> Translate { get; set; } =
        new List<Field<string>>
        {
            ("Element1", "Привет"),
            ("Element2", "Друг")
        };

    }

}
