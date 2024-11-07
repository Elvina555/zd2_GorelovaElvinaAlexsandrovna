using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace pr2
{
    class PhoneBookLoader
    {
        //Метод для загрузки данных из файла и добавления
        public static void Load(PhoneBook phoneBook)
        {
            try
            {
                if (File.Exists("file.txt"))//проверка на существующий файл
                {
                    var lines = File.ReadAllLines("file.txt");
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        var contact = new Contact(parts[0], parts[1], parts[2]);
                        phoneBook.AddContact(contact);
                    }
                }
                else
                {
                    MessageBox.Show("файл не найден");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке");
            }
        }

        //Метод для сохранения контактов 
        public static void Save(PhoneBook phoneBook)
        {
            var line = phoneBook.GetAllContacts()
                                 .Select(c => $"{c.Name},{c.Phone},{c.Surname}");
            File.WriteAllLines("file.txt", line);
        }

    }
}
