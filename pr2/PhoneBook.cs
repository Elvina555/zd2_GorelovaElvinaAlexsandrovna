using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2
{
    class PhoneBook
    {
        private List<Contact> contacts = new List<Contact>();
        public PhoneBook()
        {
            contacts= new List<Contact>();
        }
        //перегрузка метода
        public void AddContact(string name,string surname, string phone)
        {
            Contact contact = new Contact(name, surname, phone);
            contacts.Add(contact);
        }
        //метод для добавления с помощью Linq
        public bool AddContact(Contact contact)
        {
            bool check = true;
            //проверка на уникальность
            foreach(var con in contacts)
            {
                if(con.Phone==contact.Phone)
                {
                    check = false;
                    break;
                     
                }
            }
            if (check)
            {
                contacts.Add(contact);
                return check;
            }
            else
                return check;
        }
        //метод для удаления с помощью Linq
        public void RemoveContact(Contact contact)
        {
            contacts.Remove(contact);
        }
        //метод для поска с помощью Linq
        public List<Contact> PoiskContact(string name)
        {
            return contacts.Where(k => $"{k.Name.ToLower()}" == name.ToLower()).ToList();
        }
        //метод для извлечения всех контактов
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

    }
}
