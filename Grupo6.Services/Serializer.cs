using Grupo6.Entities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupo6.Services
{
    public class Serializer
    {
        public static List<ItemCarrito> XmlToObject(string data)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ItemCarrito>));
            var sr = new StringReader(data);
            return xmlSerializer.Deserialize(sr) as List<ItemCarrito>;
        }

        public static string ObjectToXml(List<ItemCarrito> data)
        {
            var xmlSerializer = new XmlSerializer(data.GetType());
            var sw = new StringWriter();

            xmlSerializer.Serialize(sw, data);

            return sw.ToString();
        }
    }
}
