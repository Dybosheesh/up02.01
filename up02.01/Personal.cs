using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up02._01
{
    internal class Personal
    {
        public int id { get; set; }
        public string ident { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string post { get; set; }

        public Personal() { }

        public Personal(string ident, string name, string surname, string patronymic, string post)
        {
            this.ident = ident;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.post = post;
        }
    }
}
