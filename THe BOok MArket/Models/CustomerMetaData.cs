using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace THe_BOok_MArket.Models
{
        [Serializable]
        [XmlRoot("customer")]
        public class CustomerMetaData
        {
            [XmlElement("id")]
             public int Customer_ID { get; set; }

            [XmlElement("name")]
            public string Customer_Name { get; set; }

            [XmlElement("surname")]
            public string Customer_Surname { get; set; }

            [XmlElement("email")]
            public string Customer_Email { get; set; }

            [XmlElement("contact")]
            public string Customer_Contact { get; set; }

        }

        [MetadataType(typeof(CustomerMetaData))]
        public partial class Customer
        {

        }
    }