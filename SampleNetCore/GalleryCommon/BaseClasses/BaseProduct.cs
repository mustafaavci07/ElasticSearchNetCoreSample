using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryCommon.BaseClasses
{
    public class BaseProduct:BaseModel
    {
        public ProductType ProductType { get; set; }
        public double Price { get; set; }
        public Variant Variants { get; set; }

    }
}
