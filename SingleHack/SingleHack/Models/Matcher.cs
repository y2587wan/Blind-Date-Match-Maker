using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleHack.Models
{
    public class Matcher
    {
        //private string code;
        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string Password { get; set; }
        public string Code { get; set; }
        /*
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = RandomString(5);
            }
        }
        */


    }

}
