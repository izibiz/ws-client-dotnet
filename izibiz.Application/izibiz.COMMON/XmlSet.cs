using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace izibiz.COMMON
{
  public  class XmlSet
    {

        public static string xmlChangeIdValue(string xmlInv, string newInvId)
        {
            XDocument doc = XDocument.Parse(xmlInv);

            foreach (XElement element in doc.Descendants().Where(
                   e => e.Name.LocalName.ToString().Equals("ID")
                   && e.Parent.Name.LocalName.ToString().Equals("Invoice")
                   ))
            {
                element.Value = newInvId;
                break;
            }

            return doc.ToString();

            /////////////////////////////////////

            //XmlDocument document = new XmlDocument();
            //document.LoadXml(xmlInv);

            //XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);
            //manager.AddNamespace("cbc", "urn:ID");

            //document.SelectSingleNode("//Invoice/cbc:ID").InnerText = "New Value";
            //////////////////////////////////////////////////////////////





            //XmlDocument document = new XmlDocument();
            //document.LoadXml(xmlInv);
            //XPathNavigator navigator = document.CreateNavigator();

            //XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
            //         manager.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");

            //foreach (XPathNavigator nav in navigator.Select("cbc:ID", manager))
            //{
            //    nav.SetValue("gooo");
            //    break;
            //}

          //  return document.ToString();


        }

    }
}
