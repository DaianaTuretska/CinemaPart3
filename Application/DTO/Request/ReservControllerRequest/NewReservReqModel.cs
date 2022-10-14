namespace Application.DTO.Request.ReservControllerRequest
{
    public class NewReservReqModel
    {

        public Guid customer_id { get; set; }
        public Guid seance_id { get; set; }
        public Guid place_id { get; set; }
        public DateTime reserv_date { get; set; }
  
    }
}
