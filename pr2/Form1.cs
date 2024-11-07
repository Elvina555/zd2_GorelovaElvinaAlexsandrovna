using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace pr2
{
    public partial class Form1 : Form
    {
        PhoneBook phoneBook = new PhoneBook();
        public Form1()
        {
            InitializeComponent();
        }

        //Метод для загрузки контактов
        private void LoadContact()
        {
            PhoneBookLoader.Load(phoneBook);
            listBox1.Items.Clear();
            foreach (var contact in phoneBook.GetAllContacts())
            {
                listBox1.Items.Add(contact); 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadContact();
        }
        //метод для проверки, что только буквы
        private bool IsAllLetters(string inp)
        {
            foreach (var ch in inp)
            {
                if (!char.IsLetter(ch))
                {
                    return false;
                }
            }
            return true;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "") //проверка на пустые поля
            {
                string name = textBox1.Text;
                string surname = textBox2.Text;
                string phone = textBox3.Text;
                if (!IsAllLetters(name))//используем метод с проверкой
                {
                    MessageBox.Show("Только буквы в имени!!!");
                    return;
                }
                if (!IsAllLetters(surname))
                {
                    MessageBox.Show("Только буквы в фамилии!!!");
                    return;
                }
                if (phone.Length != 11)//проверка на номер телефона
                {
                    MessageBox.Show("Номер телефона должен содержать 11 цифр.");
                    return; 
                }
                
                
                Contact contact = new Contact(name, surname, phone);
                if (phoneBook.AddContact(contact))//проверка на существующий контак
                {
                    PhoneBookLoader.Save(phoneBook);
                    listBox1.Items.Add(contact);
                    MessageBox.Show("Контакт добавлен");
                }
                else
                    MessageBox.Show("Контакт уже существует");
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }


        }

        //удаление контакта
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contact = (Contact)listBox1.SelectedItem;
            phoneBook.RemoveContact(contact);
            PhoneBookLoader.Save(phoneBook);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        //редактирование контата 
        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contact = (Contact)listBox1.SelectedItem;
            contact.Name = textBox1.Text;
            contact.Surname = textBox3.Text;
            contact.Phone = textBox2.Text;
            PhoneBookLoader.Save(phoneBook);
            listBox1.Items[listBox1.SelectedIndex] = contact;
        }

        //поиск контакта
        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string onename = textBox1.Text;
            string twoname =$"{onename}";
            var contact = phoneBook.PoiskContact(twoname);
            if(contact.Count>0) //проверка на существующий контакт 
            {
                string mess = "Найден:";
                foreach(var con in contact)
                {
                    mess += $"{con}";
                }
                MessageBox.Show(mess);
            }
            else
            {
                MessageBox.Show("Контак не найден");
            }
        }

        //выход 
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
