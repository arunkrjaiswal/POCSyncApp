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

namespace POCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Azure CDN Integration //
            //AzureCDNDemo.UpdateData();

            // Sharepoint-MongoDB Integration //
            SharePointToMongoDemo sharePointToMongoDemo = new SharePointToMongoDemo();
            //sharePointToMongoDemo.GetListFromSP();
            sharePointToMongoDemo.GetListFromMongo();
        }
    }
}