using AutoMapper;
using BT.TS360.BLL;
using BT.TS360.BLL.Entities;
using MongoDB.Driver;
using POCDemo.Entities.SP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace POCDemo
{
    public static class UpdateEntities
    {
        public static void UpdateElist<SourceListType, DestListType>() where SourceListType : BaseList where DestListType : BaseList
        {
            var mongoSourceContext = new MongoDBContext<SourceListType>();
            var mongoDestContext = new MongoDBContext<DestListType>();
            List<SourceListType> sourceList = mongoSourceContext.MongoRepositoryInstance.GetAll().ToList();
            List<DestListType> destList = Mapper.Map<List<SourceListType>, List<DestListType>>(sourceList);
            mongoDestContext.MongoRepositoryInstance.InsertAll(destList.AsQueryable().Where(x => true).ToList());
        }
    }
}
