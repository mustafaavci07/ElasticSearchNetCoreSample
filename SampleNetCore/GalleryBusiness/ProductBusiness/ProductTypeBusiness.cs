using GalleryCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBusiness.ProductBusiness
{
    public class ProductTypeBusiness : BaseBusinessClass <GalleryCommon.ProductType>
    {
        public override ProductType SaveItem(ProductType item)
        {
            GalleryData.ProductType.SaveNewProductType(item);
            return item;
        }

        public IList<ProductType> GetAllActiveProductTypes()
        {
            throw new NotImplementedException();
        }


        public override List<ProductType> Search(string query)
        {
            throw new NotImplementedException();
        }

        public override int Delete(int idToDelete)
        {
            throw new NotImplementedException();
        }



    }
}
