using System;
using GeometryGym.Ifc;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;

namespace IFC2JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseIfc dbIfc = new DatabaseIfc(@"C:\Users\101746\Documents\窗.ifc");
            foreach (var ele in dbIfc.Context.Extract<IfcElement>())
            {
                var property = ele.FindProperty("");
                var newProperty = new IfcPropertySingleValue(dbIfc,"HirukawaID","");
                ele.AddAggregated(newProperty);
            }
            StreamWriter sw = new StreamWriter(@"C:\Users\101746\Documents\窗.ifc.json");
            sw.Write(dbIfc.JSON);
            sw.Close();
        }
    }
}
