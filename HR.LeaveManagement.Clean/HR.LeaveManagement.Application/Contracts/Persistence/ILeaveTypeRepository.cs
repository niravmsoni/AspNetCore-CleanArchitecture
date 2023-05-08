using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    //Domain specific operations to go here. For ex: If any method specific is required for LeaveTypeDomain, it'd go here
    //All generic CRUD methods would inherit from IGenericRepository
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {

    }
}
