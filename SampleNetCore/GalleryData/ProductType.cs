using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryData
{
    
    public partial class ProductType
    {
    
        public static void SaveNewProductType(GalleryCommon.ProductType newItem)
        {
            GalleryData.Helpers.DataHelper.GetInstance().ElasticSearchHelper.SaveNewRecord<GalleryCommon.ProductType>(newItem,"ProductType");
        }

    }
}
