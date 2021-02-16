using Base.Data.Models;
using System;
using System.IO;
using System.Linq;

namespace Base.Utils
{
    public class DataReader
    {
        public LogInDataSet GetLogInData(int dataSetId)
        {
            var data = XmlDataReader.DeserializeXMLFileToObject<LogInDataModel>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data\LogIn.xml"));
            return data.LogInDataSets.Where(l => int.Parse(l.Id) == dataSetId).FirstOrDefault();
        }     
    }
}
