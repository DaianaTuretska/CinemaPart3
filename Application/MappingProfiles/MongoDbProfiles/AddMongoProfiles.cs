namespace Application.MappingProfiles.MongoDbProfiles
{
    public static class AddMongoProfiles
    {
        public static void Configure()
        {
            MongoReservProfile.Configure();
        }
    }
}
