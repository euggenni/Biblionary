using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblionary.Entities
{
    public class Comment
    {
        public int IdComment { get; set; }
        public int Book { get; set; }
        public string User { get; set; }
        public float Note { get; set; }
        public string Text { get; set; }
        public string TimeAdd { get; set; }
    }
}
