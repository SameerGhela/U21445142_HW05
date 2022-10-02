using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Points {get;set;}
        public string Author { get; set; }
        public string Type { get; set; }

    }
}