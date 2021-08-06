using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AguiarGames.Api.Entity
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string Id { get; set; }
        
        [BsonElement("title")]
        public string Title { get; set; }
        
        [BsonElement("release")]
        public DateTime Release { get; set; }

        [BsonElement("offer")]
        public bool Offer { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("imagesUrl")]
        public string[] ImagesUrl { get; set; }

        [BsonElement("priceHistory")]
        public PriceHistory[] PriceHistory { get; set; }
    }

    public class PriceHistory
    {
        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }
    }
}