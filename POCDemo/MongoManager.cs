using BT.TS360.BLL;
using BT.TS360.BLL.Entities;
using BT.TS360.BLL.Entities.SP;
using BT.TS360.Common.Utils;
using MongoDB.Bson;
using POCDemo.Entities.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCDNDemo
{
    public class MongoManager
    {
        #region Initial List import

        public void PushInitialRecords()
        {
            // Publication Menu
            PushInitialPublications();
            PushInitialPublicationIssues();
            PushInitialPublicationCategories();

            // Promotions Menu
            PushFeaturedPromotions();
            PushPromotions();

            // List Menu
            PushInitialELists();
            PushEListSubcategory();
            PushFeaturedBTeLists();



            //// Done till here //

            //PushLibrariansCorner();
            // New Release Calendar Menu
            //PushInitialNewReleaseCalendar();
            //PushHolidays();

            // Standing Order Service

            //FixImageURL();
        }

        #region Publications

        private void PushInitialPublications()
        {

            var mongoContext = new MongoDBContext<StagingPublication>();
            List<StagingPublication> spLists = mongoContext.MongoRepositoryInstance.GetAll().ToList();

            var mongoContext1 = new MongoDBContext<Publication>();
            List<Publication> mongoDBLists = mongoContext1.MongoRepositoryInstance.GetAll().ToList();

            if (mongoDBLists != null && mongoDBLists.Any())
            {
                return;
            }

            Publication insertItem;
            foreach (StagingPublication item in spLists)
            {
                insertItem = new Publication
                {
                    AdName = item.AdName,
                    ApprovedDate = DateTime.Now,
                    Approver = item.Approver,
                    Comment = item.Comment,
                    ContentOwner = item.ContentOwner,
                    DisplayOrder = item.DisplayOrder,
                    ExpirationDate = DateTime.Now,
                    IsDefault = item.IsDefault,
                    ItemStatus = item.ItemStatus,
                    ItemType = item.ItemType,
                    Metadata = item.Metadata,
                    Path = item.FileDirRef,
                    PublishedDate = item.PublishedDate,
                    StartDate = item.StartDate,
                    Title = item.Title,
                    Version = item.Version,
                    Description = item.Description,
                    IconImageUrl = item.IconImageUrl == null ? String.Empty : item.IconImageUrl.Url,
                    SPListId = item.ID
                };

                mongoContext1.MongoRepositoryInstance.Insert(insertItem);
            }
        }

        private void PushInitialPublicationIssues()
        {
            List<StagingPublicationIssue> existing_PublicationIssues = new MongoDBContext<StagingPublicationIssue>().MongoRepositoryInstance.GetAll().ToList();

            List<PublicationIssue> existing = new MongoDBContext<PublicationIssue>().MongoRepositoryInstance.GetAll().ToList();

            if (existing.IsNotNull() && existing.Any())
            {
                return;
            }

            PublicationIssue publicationIssue;
            foreach (StagingPublicationIssue item in existing_PublicationIssues)
            {
                publicationIssue = new PublicationIssue
                {
                    AdName = item.AdName,
                    ApprovedDate = DateTime.Now,
                    Approver = item.Approver,
                    Comment = item.Comment,
                    ContentOwner = item.ContentOwner,
                    CoverImageUrl = item.CoverImageUrl,
                    DisplayOrder = item.DisplayOrder,
                    ExpirationDate = DateTime.Now,
                    IsDefault = item.IsDefault,
                    ItemStatus = item.ItemStatus,
                    ItemType = item.ItemType,
                    Metadata = item.Metadata,
                    Path = item.FileDirRef,
                    PdfFileUrl = item.PdfFileUrl,
                    Publication = item.Publication == null ? String.Empty : item.Publication.LookupValue,
                    PublicationId = new MongoDBContext<Publication>().MongoRepositoryInstance.GetCollectionByKey("Title", item.Publication.LookupValue).FirstOrDefault().Id,
                    PublishedDate = item.PublishedDate,
                    StartDate = item.StartDate,
                    Title = item.Title,
                    Version = item.Version,
                    SPListId = item.ID
                };
                new MongoDBContext<PublicationIssue>().MongoRepositoryInstance.Insert(publicationIssue);
            }
        }


        private void PushInitialPublicationCategories()
        {
            List<StagingPublicationCategory> spLists = new MongoDBContext<StagingPublicationCategory>().MongoRepositoryInstance.GetAll().ToList();

            List<PublicationCategory> mongoDBLists = new MongoDBContext<PublicationCategory>().MongoRepositoryInstance.GetAll().ToList();

            if (mongoDBLists.IsNotNull() && mongoDBLists.Any())
            {
                return;
            }

            PublicationCategory insertItem;
            foreach (StagingPublicationCategory item in spLists)
            {
                insertItem = new PublicationCategory
                {
                    AdName = item.AdName,
                    ApprovedDate = DateTime.Now,
                    Approver = item.Approver,
                    Comment = item.Comment,
                    ContentOwner = item.ContentOwner,
                    DisplayOrder = item.DisplayOrder,
                    ExpirationDate = DateTime.Now,
                    IsDefault = item.IsDefault,
                    ItemStatus = item.ItemStatus,
                    ItemType = item.ItemType,
                    Metadata = item.Metadata,
                    Path = item.FileDirRef,
                    PublishedDate = item.PublishedDate,
                    StartDate = item.StartDate,
                    Title = item.Title,
                    Version = item.Version,
                    PublicationIssue = item.PublicationIssue == null ? String.Empty : item.PublicationIssue.LookupValue,
                    SPListId = item.SPListId,
                    PublicationSubCategories = GetPublicationSubCategories(item.Title),
                    PublicationIssueId = GetPublicationIssueIdByIssueName(item.PublicationIssue.LookupValue),
                };

                new MongoDBContext<PublicationCategory>().MongoRepositoryInstance.Insert(insertItem);
            }
        }

        private String GetPublicationIssueIdByIssueName(string publicationIssue)
        {
            PublicationIssue result = new MongoDBContext<PublicationIssue>().MongoRepositoryInstance.GetCollectionByKeysElemMatch("Title", publicationIssue).FirstOrDefault();
            if (result.IsNotNull())
            {
                return result.Id;
            }

            return String.Empty;
        }

        private List<PublicationSubCategory> GetPublicationSubCategories(string title)
        {
            List<PublicationSubCategory> result = new List<PublicationSubCategory>();
            List<StagingPublicationSubCategory> existingSubCat = new MongoDBContext<StagingPublicationSubCategory>().MongoRepositoryInstance.GetCollectionByKey("PublicationCategory.LookupValue", title).ToList();

            if (existingSubCat.IsNotNull() && existingSubCat.Any())
            {
                existingSubCat = existingSubCat.DistinctBy(key => key.Title).ToList();

                existingSubCat.ForEach(item =>
                {
                    result.Add(new PublicationSubCategory
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.FileDirRef,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        BTKeyList = item.BTKeyList.IsNotNull() ? item.BTKeyList.Split('|') : new string[] { },
                        DisplayOrder = item.DisplayOrder,
                        PublicationCategory = item.PublicationCategory.LookupValue,
                        SPListId = item.ID
                    });
                }
                );
            }
            return result;
        }

        #endregion  Publications

        #region Promotions

        private void PushPromotions()
        {
            List<StagingPromotion> sharePointPromotions = new MongoDBContext<StagingPromotion>().MongoRepositoryInstance.GetAll().ToList();

            List<Promotion> existing = new MongoDBContext<Promotion>().MongoRepositoryInstance.GetAll().ToList();

            if (existing.IsNotNull() && existing.Any())
            {
                return;
            }

            if (sharePointPromotions.IsNotNull() && sharePointPromotions.Any())
            {
                sharePointPromotions.ForEach(item =>
                {
                    Promotion promotion = new Promotion
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        DisplayOrder = item.DisplayOrder,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.FileDirRef,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        ButtonWebtrendsTag = Convert.ToString(item.ButtonWebtrendsTag),
                        DetailText = item.DetailText,
                        ImageUrl = Convert.ToString(item.ImageUrl),
                        ImageWebtrendsTag = Convert.ToString(item.ImageWebtrendsTag),
                        PromotionCode = Convert.ToString(item.PromotionCode),
                        SummaryText = item.SummaryText,
                        SPListId = item.ID
                    };

                    new MongoDBContext<Promotion>().MongoRepositoryInstance.Insert(promotion);
                });
            }
        }

        private void PushFeaturedPromotions()
        {
            List<StagingFeaturedPromotion> sharePointPromotions = new MongoDBContext<StagingFeaturedPromotion>().MongoRepositoryInstance.GetAll().ToList();

            List<FeaturedPromotion> existing = new MongoDBContext<FeaturedPromotion>().MongoRepositoryInstance.GetAll().ToList();

            if (existing.IsNotNull() && existing.Any())
            {
                return;
            }

            if (sharePointPromotions.IsNotNull() && sharePointPromotions.Any())
            {
                sharePointPromotions.ForEach(item =>
                {
                    FeaturedPromotion featuredPromotion = new FeaturedPromotion
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.FileDirRef,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        BTKeys = item.BTKeys.IsNotNull() ? item.BTKeys.Split('|') : new string[] { },
                        FeaturedPromoBackground = Convert.ToString(item.FeaturedPromoBackg),
                        FeaturedPromoImage = item.FeaturedPromoImage == null ? String.Empty : item.FeaturedPromoImage.Url,
                        FeaturedPromoText = item.FeaturedPromoText,
                        FeaturedPromotionURL = item.FeaturedPromotionURL,
                        DisplayOrder = item.DisplayOrder,
                        SPListId = item.ID
                    };
                    new MongoDBContext<FeaturedPromotion>().MongoRepositoryInstance.Insert(featuredPromotion);
                });
            }
        }

        #endregion Promotions

        #region NewReleaseCalendar

        private void PushInitialNewReleaseCalendar()
        {
            List<Existing_NewReleaseCalendar> sharePointPromotions = new MongoDBContext<Existing_NewReleaseCalendar>().MongoRepositoryInstance.GetAll().ToList();

            List<NewReleaseCalendar> existing = new MongoDBContext<NewReleaseCalendar>().MongoRepositoryInstance.GetAll().ToList();

            if (existing.IsNotNull() && existing.Any())
            {
                return;
            }

            if (sharePointPromotions.IsNotNull() && sharePointPromotions.Any())
            {
                Random rand = new Random();
                int month = rand.Next(1, 20);
                sharePointPromotions.ForEach(item =>
                {
                    NewReleaseCalendar newReleaseCalendar = new NewReleaseCalendar
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Today.AddDays(-5),
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        DisplayOrder = item.DisplayOrder,
                        ExpirationDate = DateTime.Today.AddDays(-5),
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.Path,
                        PublishedDate = DateTime.Today.AddDays(-5),
                        StartDate = DateTime.Today.AddDays(-5),
                        Title = item.Title,
                        Version = item.Version,
                        SPListId = item.SPListId,
                        BTKeyList = item.BTKeyList.Split('|', ','),
                        Description = item.Description,
                        ModifiedBy = item.ModifiedBy,
                        ReleaseDate = DateTime.Today.AddDays(month),
                        TopRelease = item.TopRelease,
                    };
                    new MongoDBContext<NewReleaseCalendar>().MongoRepositoryInstance.Insert(newReleaseCalendar);
                });
            }
        }

        private void PushHolidays()
        {
            List<Existing_Holidays> sharePointList = new MongoDBContext<Existing_Holidays>().MongoRepositoryInstance.GetAll().ToList();

            List<Holidays> existing = new MongoDBContext<Holidays>().MongoRepositoryInstance.GetAll().ToList();

            if (existing.IsNotNull() && existing.Any())
            {
                return;
            }

            if (sharePointList.IsNotNull() && sharePointList.Any())
            {
                sharePointList.ForEach(item =>
                {
                    Holidays newItem = new Holidays
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        DisplayOrder = item.DisplayOrder,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.Path,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        SPListId = item.SPListId,
                        Date = DateTime.Now,
                        Holiday = item.Holiday,
                        HolidayText = item.HolidayText,
                    };
                    new MongoDBContext<Holidays>().MongoRepositoryInstance.Insert(newItem);
                });
            }
        }

        #endregion NewReleaseCalendar

        #region ELists

        private void PushInitialELists()
        {
            List<StagingeListCategory> sharePointData = new MongoDBContext<StagingeListCategory>().MongoRepositoryInstance.GetAll().ToList();
            List<EListCategory> existingMongoDBData = new MongoDBContext<EListCategory>().MongoRepositoryInstance.GetAll().ToList();

            if (existingMongoDBData.IsNotNull() && existingMongoDBData.Any())
            {
                return;
            }

            if (sharePointData.IsNotNull() && sharePointData.Any())
            {
                sharePointData.ForEach(item =>
                {
                    EListCategory data = new EListCategory
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        DisplayOrder = item.DisplayOrder,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.FileDirRef,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        ItemCount = GetCount(item.Title),
                        SPListId = item.ID
                    };
                    new MongoDBContext<EListCategory>().MongoRepositoryInstance.Insert(data);
                });
            };
        }


        public void PushEListSubcategory()
        {
            List<StagingeListSubcategory> sharePointData = new MongoDBContext<StagingeListSubcategory>().MongoRepositoryInstance.GetAll().ToList();

            List<EListSubCategory> existingMongoDBData = new MongoDBContext<EListSubCategory>().MongoRepositoryInstance.GetAll().ToList();
            if (existingMongoDBData.IsNotNull() && existingMongoDBData.Any())
            {
                return;
            }
            if (sharePointData.IsNotNull() && sharePointData.Any())
            {

                sharePointData.ForEach(item =>
                {
                    EListSubCategory insertItem = new EListSubCategory
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        DisplayOrder = item.DisplayOrder,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.FileDirRef,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        EListCategory = item.eListCategory == null ? String.Empty : item.eListCategory.LookupValue,
                        ELists = GetElists(item.Title),
                        SPListId = item.SPListId,
                        EListCategoryId = GetElistCategoryId(item),
                    };
                    new MongoDBContext<EListSubCategory>().MongoRepositoryInstance.Insert(insertItem);
                });
            }
        }


        private String GetElistCategoryId(StagingeListSubcategory item)
        {
            EListCategory d = new MongoDBContext<EListCategory>().MongoRepositoryInstance.GetCollectionByKey("Title", item.eListCategory.LookupValue).FirstOrDefault();
            if (d.IsNotNull())
                return d.Id;
            else // For garbage Data .
                return ObjectId.GenerateNewId().ToString();
        }

        public void PushFeaturedBTeLists()
        {
            List<StagingFeaturedBTeLists> sharePointData = new MongoDBContext<StagingFeaturedBTeLists>().MongoRepositoryInstance.GetAll().ToList();
            List<FeaturedBTeList> existingMongoDBData = new MongoDBContext<FeaturedBTeList>().MongoRepositoryInstance.GetAll().ToList();

            if (existingMongoDBData.IsNotNull() && existingMongoDBData.Any())
            {
                return;
            }

            if (sharePointData.IsNotNull() && sharePointData.Any())
            {
                sharePointData.ForEach(item =>
                {
                    FeaturedBTeList data = new FeaturedBTeList
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.FileDirRef,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        ListCategory = item.BTListCategory == null ? String.Empty : item.BTListCategory.LookupValue,                        
                        ListName = item.BTListName == null ? String.Empty : item.BTListName.LookupValue,
                        ListSubCategory = item.BTListSubCategory == null ? String.Empty : item.BTListSubCategory.LookupValue,
                        SPListId = item.ID,
                        DisplayOrder = item.DisplayOrder,
                        EListId = GetEListIdByName(item.BTListName.LookupValue),                        
                    };

                    new MongoDBContext<FeaturedBTeList>().MongoRepositoryInstance.Insert(data);
                });
            }
        }

        public void PushLibrariansCorner()
        {
            List<Existing_LibrariansCorner> sharePointData = new MongoDBContext<Existing_LibrariansCorner>().MongoRepositoryInstance.GetAll().ToList();
            List<LibrariansCorner> existingMongoDBData = new MongoDBContext<LibrariansCorner>().MongoRepositoryInstance.GetAll().ToList();

            if (existingMongoDBData.IsNotNull() && existingMongoDBData.Any())
            {
                return;
            }

            if (sharePointData.IsNotNull() && sharePointData.Any())
            {
                sharePointData.ForEach(item =>
                {
                    LibrariansCorner data = new LibrariansCorner
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.Path,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        ListCategory = item.ListCategory,
                        ListName = item.ListName,
                        ListSubCategory = item.ListSubCategory,
                        DisplayOrder = item.DisplayOrder,
                        SPListId = item.SPListId,
                        EListId = GetEListIdByName(item.ListName)
                    };

                    new MongoDBContext<LibrariansCorner>().MongoRepositoryInstance.Insert(data);
                });
            }
        }

        /// <summary>
        /// GetEListCount
        /// </summary>
        /// <param name="eListCategoryTitle"></param>
        /// <returns></returns>
        private Int32 GetCount(string eListCategoryTitle)
        {
            Int32 count = 0;
            List<StagingeListSubcategory> sharePointData = new MongoDBContext<StagingeListSubcategory>().MongoRepositoryInstance.GetCollectionByKey("eListCategory.LookupValue", eListCategoryTitle).ToList();
            if (sharePointData.IsNotNull() && sharePointData.Any())
            {
                sharePointData.ForEach(item =>
                {
                    count = count + GetElistsCount(item.Title);
                });
            }
            return count;
        }

        private Int32 GetElistsCount(string subCategoryTitle)
        {
            return new MongoDBContext<StagingeList>().MongoRepositoryInstance.GetCollectionByKey("eListSubcategory.LookupValue", subCategoryTitle).ToList().Count;
        }

        private List<EListSubCategory> GetEListSubcategory(string eListCategoryTitle)
        {
            List<Existing_EListSubcategory> sharePointData = new MongoDBContext<Existing_EListSubcategory>().MongoRepositoryInstance.GetCollectionByKey("eListCategory", eListCategoryTitle).ToList();
            List<EListSubCategory> result = new List<EListSubCategory>();
            if (sharePointData.IsNotNull() && sharePointData.Any())
            {
                sharePointData.ForEach(item =>
                {
                    EListSubCategory data = new EListSubCategory
                    {
                        AdName = item.AdName,
                        ApprovedDate = DateTime.Now,
                        Approver = item.Approver,
                        Comment = item.Comment,
                        ContentOwner = item.ContentOwner,
                        DisplayOrder = item.DisplayOrder,
                        ExpirationDate = DateTime.Now,
                        IsDefault = item.IsDefault,
                        ItemStatus = item.ItemStatus,
                        ItemType = item.ItemType,
                        Metadata = item.Metadata,
                        Path = item.Path,
                        PublishedDate = item.PublishedDate,
                        StartDate = item.StartDate,
                        Title = item.Title,
                        Version = item.Version,
                        EListCategory = item.eListCategory,
                        ELists = GetElists(item.Title),
                        SPListId = item.SPListId,

                    };

                    result.Add(data);
                });
            }

            return result;
        }

        private List<EList> GetElists(string subCategoryTitle)
        {
            List<Existing_EList> sharePointData = new MongoDBContext<Existing_EList>().MongoRepositoryInstance.GetCollectionByKey("ListSubcategory", subCategoryTitle).ToList();

            return sharePointData.Select(item => new EList
            {
                AdName = item.AdName,
                ApprovedDate = DateTime.Now,
                Approver = item.Approver,
                Comment = item.Comment,
                ContentOwner = item.ContentOwner,
                DisplayOrder = item.DisplayOrder,
                ExpirationDate = DateTime.Now,
                IsDefault = item.IsDefault,
                ItemStatus = item.ItemStatus,
                ItemType = item.ItemType,
                Metadata = item.Metadata,
                Path = item.Path,
                PublishedDate = item.PublishedDate,
                StartDate = item.StartDate,
                Title = item.Title,
                Version = item.Version,
                EListCategory = item.ListCategory,
                EListSubCategory = item.ListSubcategory,
                BTKeyList = item.BTKeyList.IsNotNull() ? item.BTKeyList.Split('|') : new string[] { },
                SPListId = item.SPListId,
                EListId = ObjectId.GenerateNewId().ToString()
            }).ToList();
        }

        private String GetEListIdByName(string listName)
        {
            StagingeList result = new MongoDBContext<StagingeList>().MongoRepositoryInstance.GetCollectionByKey("Title", listName).FirstOrDefault();

            if (result.IsNotNull())
            {
                return result.Id;
            }

            return String.Empty;
        }

        #endregion ELists

        public void FixImageURL()
        {
            List<Promotion> promotions = new MongoDBContext<Promotion>().MongoRepositoryInstance.GetAll().ToList();
            List<FeaturedPromotion> featuredPromotions = new MongoDBContext<FeaturedPromotion>().MongoRepositoryInstance.GetAll().ToList();
            List<Publication> publications = new MongoDBContext<Publication>().MongoRepositoryInstance.GetAll().ToList();

            foreach (Promotion item in promotions)
            {
                item.ImageUrl = String.IsNullOrWhiteSpace(item.ImageUrl) ? String.Empty : item.ImageUrl.Replace("ts360auth.baker-taylor.com", "ts360.baker-taylor.com");

                new MongoDBContext<Promotion>().MongoRepositoryInstance.Update(item);
            }
            foreach (FeaturedPromotion item in featuredPromotions)
            {
                item.FeaturedPromotionURL = String.IsNullOrWhiteSpace(item.FeaturedPromotionURL) ? String.Empty : item.FeaturedPromotionURL.Replace("ts360auth.baker-taylor.com", "ts360.baker-taylor.com");
                item.FeaturedPromoImage = String.IsNullOrWhiteSpace(item.FeaturedPromoImage) ? String.Empty : item.FeaturedPromoImage.Replace("ts360auth.baker-taylor.com", "ts360.baker-taylor.com");

                new MongoDBContext<FeaturedPromotion>().MongoRepositoryInstance.Update(item);
            }

            foreach (Publication item in publications)
            {
                item.IconImageUrl = String.IsNullOrWhiteSpace(item.IconImageUrl) ? String.Empty : item.IconImageUrl.Replace("ts360auth.baker-taylor.com", "ts360.baker-taylor.com");

                new MongoDBContext<Publication>().MongoRepositoryInstance.Update(item);
            }
        }

        #endregion Initial List import
    }
}
