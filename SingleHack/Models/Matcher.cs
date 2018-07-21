using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleHack.Models
{
    public class Matcher
    {
        
        public int ID { get; set; }

        public string Password { get; set; }
        public string Code { get; set;  } 

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
