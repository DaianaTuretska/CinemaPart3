namespace Application.Interfaces.ServicesInterfaces
{
    public interface IReservService
    {
        public Task<bool> CheckReserv(Guid userid, Guid reserv);
    }
}
