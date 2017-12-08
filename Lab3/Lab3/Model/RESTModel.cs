using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace Lab3.Model
{
    public class RESTModel
    {
        public RESTModel()
        {
        }

        public static ObservableCollection<CDModel> FindPeople()
        {
            return new ObservableCollection<CDModel>();
        }
    }
}
