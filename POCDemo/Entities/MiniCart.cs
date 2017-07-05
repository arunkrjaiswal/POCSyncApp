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

#endregion

#endregion

namespace BT.TS360.BLL.Entities
{
    public class MiniCart
    {
        Boolean ShowPrimaryCart { get; set; }

        Boolean ShowSubmitOrderButton { get; set; }

        String SiteUrl { get; set; }

        String NoPrimaryCartText { get; set; }

        String BasketNameTruncate { get; set; }

        String BasketName { get; set; }

        String CartDetailUrl { get; set; }

        String CheckoutUrl { get; set; }

        String Price { get; set; }

        String NoOfItems { get; set; }

        String TotalItems { get; set; }

        String CartStatus { get; set; }

        Boolean IsCartContainsMixGridItems { get; set; }

        String PrimaryCartId { get; set; }

        Boolean IsPricing { get; set; }

        String ShowAddToCartTooltip { get; set; }

        Boolean DisableSubmitOrderButton { get; set; }

        Boolean ShowMiniCartSummaryTotalInfo { get; set; }

        Int32 BasketFreezeLevel { get; set; }
        Int32 GridDistributionOption { get; set; }
    }
}
