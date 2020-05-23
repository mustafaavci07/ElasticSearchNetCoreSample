using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryBusiness
{
    public abstract class BaseBusinessClass <ModelType>
    {
        //Logger
        public abstract ModelType SaveItem(ModelType item);

        public abstract int Delete(int idToDelete);

        public abstract List<ModelType> Search(string query);



    }
}
