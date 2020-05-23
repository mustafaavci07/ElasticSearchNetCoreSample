using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryCommon.BaseClasses
{
    public class SimpleMethodResult<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
