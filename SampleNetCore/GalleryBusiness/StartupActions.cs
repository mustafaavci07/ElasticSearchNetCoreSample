using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using System;
using System.Collections.Generic;

namespace GalleryBusiness
{
    public class StartupActions
    {
        public IList<string> ElasticSearchHostList { get; set; }
        public StartupActions(IConfiguration configParams)
        {
            this.ElasticSearchHostList = configParams.GetSection("ElasticSearchHosts:HostLists").Get<List<string>>();
            GalleryCommon.ConfigurationElements.CreateInstance(this.ElasticSearchHostList);
            GalleryData.Helpers.DataHelper.CreateInstance(GalleryCommon.ConfigurationElements.GetInstance());
        }
    }
}
