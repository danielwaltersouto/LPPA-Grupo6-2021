using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Web;
using System.Data;

namespace Grupo6.Services


/*HttpCOntext puede no validar bien el using de system.web---agregar a mano*/
{
    public enum State { Info, Error, BizChange, UserChange, Critical, }

    /*sumar mas contenido de ser necesario a las enumeraciones*/


    public class Logger
    {

        public string C1 { get; set; }
        public string C2 { get; set; }
        public string C3 { get; set; }
        public string C4 { get; set; }



        public static void WriteLog(State St, object AccionController, string IdMsj)
        {

            string DatePath = Logger.GetNameFile();
            string PathXML = HttpContext.Current.Server.MapPath("~/LogXML/" + DatePath);
            String ArcXML = PathXML + "/" + DatePath + ".xml";

            try
            {
                if (!Directory.Exists(PathXML))
                {
                    Directory.CreateDirectory(PathXML);

                    //estructura basica para el xml, no guarda solo prologo

                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement root = doc.DocumentElement;
                    doc.InsertBefore(xmlDeclaration, root);
                    XmlElement element1 = doc.CreateElement(string.Empty, "logger", string.Empty);
                    doc.AppendChild(element1);

                    doc.Save(ArcXML);


                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(ArcXML);
                    XmlNode nodeLog = doc.CreateElement("Log");

                    XmlNode nodeSeverity = doc.CreateElement("Severity");
                    nodeSeverity.InnerText = St.ToString();

                    XmlNode nodeController = doc.CreateElement("Controller");
                    nodeController.InnerText = AccionController.ToString();

                    XmlNode nodeIdMsj = doc.CreateElement("IdMsj");
                    nodeIdMsj.InnerText = IdMsj;

                    XmlNode nodeFecha = doc.CreateElement("Date");
                    nodeFecha.InnerText = DateTime.Now.ToString();

                    nodeLog.AppendChild(nodeSeverity);
                    nodeLog.AppendChild(nodeController);
                    nodeLog.AppendChild(nodeFecha);
                    nodeLog.AppendChild(nodeIdMsj);

                    doc.SelectSingleNode("logger").AppendChild(nodeLog);
                    doc.Save(ArcXML);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        /*--------Nombre de Directorio----*/



        private static string GetNameFile()

        {
            string nombre = "";

            nombre = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day;

            return nombre;
        }

        /*--------XML++++++++++READ----*/

        private List<Logger> ReadLog(string fecha)

        {

            Logger logger = new Logger();
            List<Logger> loggers = new List<Logger>();



            return (loggers);
        }


        private List<Logger> ReadLog(string fecha, string state)

        {

            Logger logger = new Logger();
            List<Logger> loggers = new List<Logger>();



            return (loggers);


        }





    }

}



