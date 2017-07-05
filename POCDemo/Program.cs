using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using System.Net;
using BT.TS360.BLL.Entities;
using BT.TS360.BLL;
using System.Text.RegularExpressions;
using System.Web;
using System.Reflection;

namespace POCDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            GetNewMyObject("BT.TS360.BLL.Entities.Promotion");
            // Azure CDN Integration //
            //AzureCDNDemo.UpdateData();

            // Sharepoint-MongoDB Integration //
            SharePointToMongoDemo sharePointToMongoDemo = new SharePointToMongoDemo();
            sharePointToMongoDemo.GetListFromSP();
            sharePointToMongoDemo.GetListFromMongo();
        }

        public static void GetNewMyObject(string pattern)
        {

            var result = System.Activator.CreateInstance(Type.GetType(pattern));

             
        }
    }

    public class MyDummyClass
    {
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
    }
}