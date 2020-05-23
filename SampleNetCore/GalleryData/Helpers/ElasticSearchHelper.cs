using System;
using System.Collections.Generic;
using System.Text;
using Elasticsearch.Net;
using GalleryCommon;
using GalleryCommon.BaseClasses;
using Nest;


namespace GalleryData.Helpers
{


    //log için belki ayrı elasctic cluster olabilir.
    //birden fazla node adres connection settings' e verilebilir.
    //bu adresler arasında uygun olan node' a gidilebilir.round robin algoritması çalışır
    public class ElasticSearchHelper
    {
        public SimpleMethodResult<bool> SaveNewRecord<T>(T record,string name) where T:class
        {
            try
            {
                IndexResponse response = this._ClientInstance.Index<T>(new IndexRequest<T>(record, name));

                if (response.IsValid)
                {
                    return new SimpleMethodResult<bool>() { Result = true };
                }
                else
                {
                    throw new Exception(response.ServerError.Error.ToString());
                   
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        private ElasticClient _ClientInstance { get; set; }

        private static readonly object lockObject = new object();

        private ConfigurationElements config { get; set; }

        public  ElasticSearchHelper(ConfigurationElements elasticConfig)
        {
            this.config = elasticConfig;
            if (this._ClientInstance == null)
            {
                this._ClientInstance = GetInstance();
               
            }
        }
     

        public ElasticClient GetInstance()
        {
            lock (lockObject)
            {
                if (_ClientInstance != null)
                    return this._ClientInstance;
                else
                {
                    lock(lockObject)
                    {

                        IList<Uri> connectionUris = new List<Uri>();
                        if (this.config.ElasticSearchHostList != null)
                        {

                            foreach(string node in this.config.ElasticSearchHostList)
                            {
                                connectionUris.Add(new System.Uri(node));
                            }

                            var connPool = new SniffingConnectionPool(connectionUris);

                            ConnectionSettings connSettings = new ConnectionSettings(connPool).DefaultIndex("ProductType");

                            this._ClientInstance = new ElasticClient(connSettings);
                            return this._ClientInstance;
                        }
                        else
                        {
                            throw new Exception("Elastic Search Node'ları Tanımlanmamış");
                        }

                    }
                }
            }
        }


    }

    public class DataHelper
    {
        private static object lockForElasticSearchHelper = new object();

        public  ElasticSearchHelper ElasticSearchHelper { get; private set; }

        private static DataHelper _instance { get; set; }

        public static DataHelper GetInstance()
        {
            lock (lockForElasticSearchHelper) {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    throw new Exception("Helper Nesnesi Konfigure Edilmelidir.");
                }
            }
            
        }

        public static DataHelper CreateInstance(ConfigurationElements elasticConfig)
        {
            _instance = new DataHelper(elasticConfig);
            return _instance;
        }

        private DataHelper()
        {
            ElasticSearchHelper = null;
            _instance = null;
        }

        public DataHelper(ConfigurationElements elasticConfig)
        {
            _instance = new DataHelper();
           _instance.ElasticSearchHelper = new ElasticSearchHelper(elasticConfig);
        }


    }

    //public class Custom
}
