using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Retrieve Domain object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //Verify that record exists

            //Remove from DB
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            //Return record Id
            return Unit.Value;
        }
    }
}
