using System.Collections.Generic;
using System.Xml.Serialization;

namespace Base.Data.Models
{
    [XmlRoot("DataSets")]
    public class LogInDataModel
    {
        [XmlElement("DataSet")] public List<LogInDataSet> LogInDataSets { get; set; }
    }

    public class LogInDataSet
    {
        [XmlAttribute("Id")] public string Id { get; set; }

        [XmlElement("Username")] public string Username { get; set; }
        [XmlElement("Password")] public string Password { get; set; }
        [XmlElement("Region")] public string Region { get; set; }
    }
}
