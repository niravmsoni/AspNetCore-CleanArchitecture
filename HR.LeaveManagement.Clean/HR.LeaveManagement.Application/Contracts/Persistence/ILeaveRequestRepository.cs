using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository<T> : IGenericRepository<LeaveRequest>
    {

    }
}
