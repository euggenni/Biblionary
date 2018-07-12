using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblionary.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string DateReg { get; set; }
        public bool CanComment { get; set; }
        public bool CanRead { get; set; }
    }
}
