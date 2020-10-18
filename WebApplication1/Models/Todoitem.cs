using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Todoitem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int IsComplete { get; set; }
    }
}
