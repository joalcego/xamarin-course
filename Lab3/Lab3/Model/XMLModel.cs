using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3.Model
{
    public class XMLModel
    {
        public XMLModel()
        {
        }

        public async static Task<ObservableCollection<CDModel>> FindPeople()
        {
            try
            {
                ObservableCollection<CDModel> lstXml = new ObservableCollection<CDModel>();

                await Task.Factory.StartNew(delegate {

                    XDocument doc = XDocument.Load("catalog.xml");

                    var result = doc.Descendants("CD");

                    foreach (var item in result)
                    {
                        var a = item.Descendants("TITLE").AsEnumerable().FirstOrDefault();
                        lstXml.Add(new CDModel { Title = a.Value });
                    }
                });


                return lstXml;
            }
            catch
            {
                return null;
            }
        }
    }
}
