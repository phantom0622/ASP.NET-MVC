using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace MVCMongoDemo.Models
{
    public class OperaDB
    {
        public String connectionString = "mongodb://localhost:27017";
        //public String DataBaseName = "local";
        public String DataBaseName = "testdb";
        //====================================================

        public MongoDatabase Database;

        public OperaDB()
	    {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            Database = server.GetDatabase(DataBaseName);
	    }

        public MongoCollection<Opera> Datas
        {
            get
            {
                var Datas = Database.GetCollection<Opera>("Opera");

                return Datas;
            }
        }

    }
}