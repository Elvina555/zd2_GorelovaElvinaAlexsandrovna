using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2
{
    class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        //конструктор
        public Contact(string name, string phone, string surname)
        {
            Name = name;
            Phone = phone;
            Surname = surname;
        }
        //метод для вывода информации
        public override string ToString()
        {
            return $"Имя:{Name} Фамилия: {Phone} Номер телефона: {Surname}";
        }
      
    }
}
