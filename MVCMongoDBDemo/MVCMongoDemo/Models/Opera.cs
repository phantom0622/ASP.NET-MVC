using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MVCMongoDemo.Models
{
    public class Opera
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        public double OperaID { get; set; }

        public string Title { get; set; }

        public double Year { get; set; }

        public string Composer { get; set; }
    }
}