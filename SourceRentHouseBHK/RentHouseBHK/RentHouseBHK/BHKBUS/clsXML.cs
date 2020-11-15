using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RentHouseBHK.BHKBUS
{
    class clsXML
    {
        public static void CreateXMLDocumentConfig(string _NameFile)
        {
            if (_NameFile.Equals("Config.xml"))
            {
                XDocument doc = new XDocument(new XElement("DATA",
                                                    new XElement("SERVER", ""),
                                                    new XElement("DATABASE", ""),
                                                    new XElement("USER", ""),
                                                    new XElement("PASSWORD", "")
                                                    )
                                                );
                string sPathFile = Application.StartupPath + "\\" + _NameFile;
                doc.Save(sPathFile);
            }
        }

        public static XmlDocument UpdateXMLDocument(XmlDocument XMLDoc, string TagName, string NewValue)
        {
            XmlNodeList node = XMLDoc.GetElementsByTagName(TagName);
            if (node.Count != 0)
            {
                foreach (XmlNode XMLNode in node)
                {
                    if (XMLNode.ChildNodes.Item(0) == null)
                    {
                        XMLNode.InnerText = NewValue;
                    }
                    else
                    {
                        XMLNode.ChildNodes.Item(0).InnerText = NewValue;
                    }
                }
            }
            return XMLDoc;
        }

        public static string GetXMLNodeValue(XmlDocument XMLDoc, string TagName)
        {
            string strResult = "";
            XmlNodeList node = XMLDoc.GetElementsByTagName(TagName);

            if (node.Count != 0)
            {
                strResult = node.Item(0).InnerText.Trim();
            }
            else
            {
                strResult = "";
            }

            return strResult;
        }
    }
}
