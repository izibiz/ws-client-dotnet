using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace izibiz.CONTROLLER.Model
{
    [XmlRoot("GetUserListResponse")]
    public class GibUserListXmlModel
    {

        public GibUserListXmlModel() { Items = new List<User>(); }

        [XmlElement("USER")]
        public List<User> Items { get; set; }
    }

    public class User
    {
        [XmlElement("IDENTIFIER")]
        public string identifier { get; set; }

        [XmlElement("ALIAS")]
        public string alias { get; set; }

        [XmlElement("TITLE")]
        public string title { get; set; }

        [XmlElement("DOCUMENT_TYPE")]
        public string documentTpye { get; set; }
    }



}
