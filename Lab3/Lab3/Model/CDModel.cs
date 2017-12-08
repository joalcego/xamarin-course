using System;
using System.Collections.ObjectModel;
namespace Lab3.Model
{
    public class CDModel
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public CDModel()
        {
        }
    }
}
