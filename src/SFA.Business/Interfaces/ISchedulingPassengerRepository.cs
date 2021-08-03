using SFA.Business.Models;

namespace SFA.Business.Interfaces
{
    public interface ISchedulingPassengerRepository : IRepository<SchedulingPassenger>
    {
        IPassengerRepository Passenger { get; }
        ISchedulingRepository Scheduling { get; }
    }
}