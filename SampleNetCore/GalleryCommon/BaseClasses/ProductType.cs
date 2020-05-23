using GalleryCommon.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryCommon
{
    public partial class ProductType: BaseModel
    {
        public string TypeName { get; set; }
        public long? MainProductTypeId { get; set; }


    }
}
