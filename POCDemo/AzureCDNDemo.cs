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
    public static class AzureCDNDemo
    {
        public static void UpdateData()
        {
            // Using Storage Containers //
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            String blobServiceEndPoint = System.Configuration.ConfigurationManager.AppSettings.Get("BlobServiceEndPoint");
            String containerName = System.Configuration.ConfigurationManager.AppSettings.Get("BlobContainerName");
            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Need to give proper name with hierarchy as Azure will not handle the same. It will automatically overwrite the blob content if name is same.
            // hence for different files, we need to create different BlockBob, we need to parse the url and then need to create the hierarchy.
            CloudBlockBlob blockBlob; //container.GetBlockBlobReference("Koala.jpg");

            using (var client = new WebClient())
            {
                // client.Credentials = new NetworkCredential("userid", "password");
                int counter = 1;

                var mongoContext = new MongoDBContext<FeaturedPromotion>();
                List<FeaturedPromotion> lists = mongoContext.MongoRepositoryInstance.GetAll().ToList();

                byte[] file;
                string blobName = String.Empty;
                string[] fileInfo;

                foreach (var item in lists)
                {
                    item.FeaturedPromoImage = item.FeaturedPromoImage.Replace("ts360auth.baker-taylor.com", "ts360.baker-taylor.com");
                    fileInfo = item.FeaturedPromoImage.Split('/');
                    blobName = String.Format("FeaturedPromotion/{0}", HttpUtility.UrlDecode(fileInfo[fileInfo.Length - 1]));
                    blobName = Regex.Replace(blobName, @"[^0-9a-zA-Z/.]+", String.Empty);
                    file = client.DownloadData(item.FeaturedPromoImage);
                    blockBlob = container.GetBlockBlobReference(blobName);
                    blockBlob.UploadFromByteArray(file, 0, file.Length);

                    item.FeaturedPromoImage = String.Format("{0}{1}/{2}", blobServiceEndPoint, containerName, blobName);
                    mongoContext.MongoRepositoryInstance.Update(item);

                    Console.WriteLine(counter++);
                }


                //var mongoContext = new MongoDBContext<PublicationIssue>();
                //List<PublicationIssue> lists = mongoContext.MongoRepositoryInstance.GetAll().ToList();

                //byte[] file;
                //string blobName = String.Empty;
                //string[] fileInfo;

                //foreach (var item in lists)
                //{


                //    item.CoverImageUrl = item.CoverImageUrl.Replace("ts360auth.baker-taylor.com", "ts360.baker-taylor.com");
                //    fileInfo = item.CoverImageUrl.Split('/');
                //    blobName = String.Format("publications/{0}", HttpUtility.UrlDecode(fileInfo[fileInfo.Length - 1]));
                //    blobName = Regex.Replace(blobName, @"[^0-9a-zA-Z/.]+", String.Empty);
                //    file = client.DownloadData(item.CoverImageUrl);
                //    blockBlob = container.GetBlockBlobReference(blobName);
                //    blockBlob.UploadFromByteArray(file, 0, file.Length);

                //    item.CoverImageUrl = String.Format("{0}{1}/{2}", blobServiceEndPoint, containerName, blobName);
                //    mongoContext.MongoRepositoryInstance.Update(item);

                //    Console.WriteLine(counter++);
                //}


                //var mongoContext = new MongoDBContext<Publication>();
                //List<Publication> lists = mongoContext.MongoRepositoryInstance.GetAll().ToList();

                //byte[] file;
                //string blobName = String.Empty;
                //string[] fileInfo;

                //foreach (var item in lists)
                //{

                //    fileInfo = item.IconImageUrl.Split('/');
                //    blobName = String.Format("publications/{0}", HttpUtility.UrlDecode(fileInfo[fileInfo.Length - 1]));
                //    blobName = Regex.Replace(blobName, @"[^0-9a-zA-Z/.]+", String.Empty);
                //    file = client.DownloadData(item.IconImageUrl);
                //    blockBlob = container.GetBlockBlobReference(blobName);
                //    blockBlob.UploadFromByteArray(file, 0, file.Length);

                //    item.IconImageUrl = String.Format("{0}{1}/{2}", blobServiceEndPoint, containerName, blobName);
                //    mongoContext.MongoRepositoryInstance.Update(item);

                //    Console.WriteLine(counter++);
                //}

                //var mongoContext = new MongoDBContext<TitleBar>();
                //List<TitleBar> lists = mongoContext.MongoRepositoryInstance.GetAll().ToList();

                //byte[] file;
                //string blobName = String.Empty;
                //string[] fileInfo;
                //foreach (var item in lists)
                //{

                //    fileInfo = item.SiteLogo.Split('/');
                //    blobName = String.Format("Common/{0}", HttpUtility.UrlDecode(fileInfo[fileInfo.Length - 1]));
                //    blobName = Regex.Replace(blobName, @"[^0-9a-zA-Z/.]+", String.Empty);
                //    file = client.DownloadData(item.SiteLogo);
                //    blockBlob = container.GetBlockBlobReference(blobName);
                //    blockBlob.UploadFromByteArray(file, 0, file.Length);
                //    item.SiteLogo = String.Format("{0}{1}/{2}", blobServiceEndPoint, containerName, blobName);


                //    fileInfo = item.BackgroundImage.Split('/');
                //    blobName = String.Format("Common/{0}", HttpUtility.UrlDecode(fileInfo[fileInfo.Length - 1]));
                //    blobName = Regex.Replace(blobName, @"[^0-9a-zA-Z/.]+", String.Empty);
                //    file = client.DownloadData(item.BackgroundImage);
                //    blockBlob = container.GetBlockBlobReference(blobName);
                //    blockBlob.UploadFromByteArray(file, 0, file.Length);

                //    item.BackgroundImage = String.Format("{0}{1}/{2}", blobServiceEndPoint, containerName, blobName);

                //    mongoContext.MongoRepositoryInstance.Update(item);

                //    Console.WriteLine(counter++);
                //}

                //var mongoContext = new MongoDBContext<Promotion>();
                //List<Promotion> promotions = mongoContext.MongoRepositoryInstance.GetAll().ToList();

                //foreach (var item in promotions)
                //{
                //    byte[] file = client.DownloadData(item.ImageUrl);
                //    string[] fileInfo = item.ImageUrl.Split('/');

                //    if (fileInfo.Length == 8)
                //    {                        
                //        string blobName = String.Format("{0}/{1}/{2}/{3}/{4}", fileInfo[3], fileInfo[4], HttpUtility.UrlDecode(fileInfo[5]), fileInfo[6], fileInfo[7]);
                //        blobName = Regex.Replace(blobName, @"[^0-9a-zA-Z/.]+", String.Empty);
                //        blockBlob = container.GetBlockBlobReference(blobName);
                //        blockBlob.UploadFromByteArray(file, 0, file.Length);

                //        item.ImageUrl = String.Format("{0}{1}/{2}", blobServiceEndPoint, containerName, blobName);
                //        mongoContext.MongoRepositoryInstance.Update(item);

                //        Console.WriteLine(counter++);
                //    }
                //}
            }

            // Save blob contents to a file.
            //using (var fileStream = System.IO.File.Open(@"C:\Users\ksharma\Desktop", System.IO.FileMode.OpenOrCreate))
            //{
            //    blockBlob.DownloadToStream(fileStream);
            //}
        }
    }
}