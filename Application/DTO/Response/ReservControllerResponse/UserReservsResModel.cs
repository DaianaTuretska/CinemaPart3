namespace Application.DTO.Response.ReservControllerResponse
{ 
    public class UserReservsResModel
    {
        public Guid Id { get; set; }
        public Guid customer_id { get; set; }
        public Guid seance_id { get; set; }
        public Guid place_id { get; set; }
        public DateTime reserv_date { get; set; }
        public bool CheckYourReserv { get; set; }
    }
}
