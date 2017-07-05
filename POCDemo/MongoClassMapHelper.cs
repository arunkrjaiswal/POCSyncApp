#region Header Comment Block

// Copyright  Baker & Taylor. 2017
// All rights are reserved.  Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical or otherwise, is prohibited
// without the prior written consent of the copyright owner.
// 
// Filename:
// Purpose:   
//
// Revisions:
// Author           Date                Comment
// ------           ----------          -------------------------------------------------

#endregion

#region Namespaces

#region System Defined

using System;

#endregion

#region Application Specific

using BT.TS360.BLL.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

#endregion

#endregion

namespace BT.TS360.BLL.Helpers
{
    public static class MongoClassMapHelper
    {
        private static readonly Object Lock = new Object();

        /// <summary>
        /// Registers the convention packs.
        /// </summary>
        public static void RegisterConventionPacks()
        {
            lock (Lock)
            {
                var conventionPack = new ConventionPack { new IgnoreIfNullConvention(true) };
                ConventionRegistry.Register("ConventionPack", conventionPack, t => true);
            }
        }

        /// <summary>
        /// Setups the mappings.
        /// </summary>
        public static void SetupClassMap()
        {
            lock (Lock)
            {

                if (!BsonClassMap.IsClassMapRegistered(typeof(BaseList)))
                {
                    BsonClassMap.RegisterClassMap<BaseList>(
                        (classMap) =>
                        {
                            classMap.AutoMap();
                            classMap.MapIdProperty(p => p.Id);
                            classMap.MapExtraElementsProperty(p => p.Metadata);
                        });
                }
            }
        }
    }
}
