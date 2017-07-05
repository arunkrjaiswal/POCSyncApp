using AutoMapper;
using AzureCDNDemo;
using BT.TS360.BLL;
using BT.TS360.BLL.Entities;
using Microsoft.BusinessData.MetadataModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using POCDemo.Entities.SP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POCDemo
{
    public class SharePointToMongoDemo
    {
        public IMongoDatabase MongoDatabase
        {
            get
            {
                String connectionString = ConfigurationManager.AppSettings.Get("MongoDbConnectionString").Replace("{DB_NAME}", DatabaseName); var client = new MongoClient(connectionString);
                MongoUrl mongoUrl = MongoUrl.Create(connectionString);
                return client.GetDatabase(mongoUrl.DatabaseName);
            }
        }

        public String DatabaseName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("MongoDBName");
            }
        }

        public String WebFullURL
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("WebFullURL");
            }
        }

        public String UserName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("UserName");
            }
        }

        public String Password
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Password");
            }
        }

        public void GetListFromSP()
        {
            IMongoCollection<BsonDocument> mongoCollection = null;

            // Call For SharePoint
            ClientContext context = new ClientContext(WebFullURL);
            context.Credentials = new NetworkCredential(UserName, Password);

            // The SharePoint web at the URL.
            Web web = context.Web;
            ListCollection listcoll = context.Web.Lists;

            // Retrieve all lists from the server. 
            // Execute query. 
            context.Load(listcoll);
            context.ExecuteQuery();

            CamlQuery query = CamlQuery.CreateAllItemsQuery();

            // Enumerate the web.Lists. 
            foreach (List list in web.Lists)
            {
                ListItemCollection listcollection = list.GetItems(query);
                context.Load(listcollection);
                context.ExecuteQuery();

                if (listcollection != null && listcollection.Any())
                {
                    foreach (var item in listcollection)
                    {
                        var docs = BsonDocument.Parse(
            Newtonsoft.Json.JsonConvert.SerializeObject(item.FieldValues));

                        mongoCollection = MongoDatabase.GetCollection<BsonDocument>(String.Format("Staging{0}", list.Title.Replace(" ", String.Empty)));

                        // TODO : Need to update the below code to insert multiple entities.
                        mongoCollection.InsertOne(docs);

                        Console.WriteLine(String.Format("{0} pushed Successfully!", list.Title));
                    }

                }
            }
        }


        /// <summary>
        /// GetListFromMongo
        /// </summary>
        public void GetListFromMongo()
        {
            String connectionString = ConfigurationManager.AppSettings.Get("MongoDbConnectionString").Replace("{DB_NAME}", DatabaseName);
            MapperConfig.InitializeMap();
            
            MongoManager obj = new MongoManager();                        
            obj.PushInitialRecords();             
            
            //UpdateEntities.UpdateElist<StagingeList, EList>();
            //UpdateEntities.UpdateElist<StagingeListCategory, EListCategory>();
            //UpdateEntities.UpdateElist<StagingeListSubcategory, EListSubCategory>();
            

        }
    }
}