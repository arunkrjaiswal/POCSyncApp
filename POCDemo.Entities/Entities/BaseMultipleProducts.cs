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
using System.Collections.Generic;

#endregion

#region Application Specific

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class BaseMultipleProducts : BaseList
    {
        private string _btKeyList;

        private int _numberOfProducts;

        /// <summary>
        /// Gets or sets the bt key list.
        /// </summary>
        /// <value>
        /// The bt key list.
        /// </value>
        public string BTKeyList
        {
            get
            {
                return _btKeyList;
            }
            set
            {
                _btKeyList = value;
                if (_btKeyList != null)
                {
                    var splitedItems = _btKeyList.Split(new[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var btKeyList = new List<string>();
                    foreach (var splitedItem in splitedItems)
                    {
                        var trimmedBtKey = splitedItem.Trim();
                        if (!btKeyList.Contains(trimmedBtKey))
                        {
                            btKeyList.Add(trimmedBtKey);
                        }
                    }
                    _numberOfProducts = btKeyList.Count;
                    _btKeyList = String.Join("|", btKeyList.ToArray());
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of products.
        /// </summary>
        /// <value>
        /// The number of products.
        /// </value>
        public int NumberOfProducts
        {
            get { return _numberOfProducts; }
            set { _numberOfProducts = value; }
        }
    }
}
