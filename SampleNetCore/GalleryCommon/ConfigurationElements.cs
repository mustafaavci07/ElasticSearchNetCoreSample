
using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryCommon
{
    public class ConfigurationElements
    {

        private static ConfigurationElements _instance { get; set; }

        public static ConfigurationElements GetInstance()
        {
            if (_instance == null)
            {
                throw new Exception("Configuration Elements Configure Edilmelidir");
            }
            else
                return _instance;
        }

        public IList<string> ElasticSearchHostList { get; set; }

        public static void CreateInstance(IList<string> hostList)
        {
            _instance = new ConfigurationElements()
            {
                ElasticSearchHostList = hostList
            };

        }
        

    }
}
