using System;
using System.Collections.Generic;
using System.Text;

namespace KsondzykLab2.Models
{
    internal class Person
    {
        private string _name;
        private string _lastName;
        private string _mail;
        private DateTime _birthday;

        public Person(string name, string lastName, string mail, DateTime birthday)
        {
            this._name = name;
            this._lastName = lastName;
            this._mail = mail;
            this._birthday = birthday;
        }
        public Person(string name, string lastName, string mail)
        {
            this._name = name;
            this._lastName = lastName;
            this._mail = mail;
        }
        public Person(string name, string lastName, DateTime birthday)
        {
            this._name = name;
            this._lastName = lastName;
            this._birthday = birthday;
        }

        private readonly bool IsAdult;
        private readonly string SunSiign;
        private readonly string ChineseSign;
        private readonly bool isBirthday;

    }
}