﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryCommon.BaseClasses
{
    public class BaseModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string UpdatedBy { get; set; }
    }
}
