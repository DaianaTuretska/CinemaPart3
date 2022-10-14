using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Application.MappingProfiles.MongoDbProfiles
{
    public static class MongoReservProfile
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Reserv>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Id).SetSerializer(new GuidSerializer(BsonType.String));
                map.MapMember(x => x.customer_id).SetElementName("customer_id").SetSerializer(new GuidSerializer(BsonType.String));
                map.MapMember(x => x.seance_id).SetElementName("seance_id").SetSerializer(new GuidSerializer(BsonType.String));
                map.MapMember(x => x.place_id).SetElementName("place_id").SetSerializer(new GuidSerializer(BsonType.String)); 
                map.MapMember(x => x.reserv_date).SetElementName("reserv_date");
            });
        }
    }
}
