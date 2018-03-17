using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleHack.Models
{
    public enum Gender
    {
        Male, Female
    }

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public string Code { get; set; }
        public string Comment { get; set; }
    }
}
