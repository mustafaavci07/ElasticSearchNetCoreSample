using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleNetCore.Helpers
{
    public class BusinessCallHelper
    {
        public delegate TResultType callBusinessDelagate<TBusinessType, TResultType>(TBusinessType buss);

        public delegate void callBusinessDelagate <TBusinessType>(TBusinessType buss);
        public static TResultType CallBusiness<TBusinessType,TResultType>(callBusinessDelagate<TBusinessType,TResultType> caller )
        {
            TBusinessType bussObj = (TBusinessType)Activator.CreateInstance(typeof(TBusinessType));
            TResultType result = caller(bussObj);
            return result;
                     
        }

        public static void CallBusiness<TBusinessType>(callBusinessDelagate<TBusinessType> caller)
        {
            TBusinessType bussObj = (TBusinessType)Activator.CreateInstance(typeof(TBusinessType));
            caller(bussObj);
        }
    }
}
