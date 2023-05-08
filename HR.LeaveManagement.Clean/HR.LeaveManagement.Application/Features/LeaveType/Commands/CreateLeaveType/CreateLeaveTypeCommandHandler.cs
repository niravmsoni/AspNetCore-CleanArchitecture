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
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //Convert to DTO object
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            //Save to DB
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            //Return record Id
            return leaveTypeToCreate.Id;
        }
    }
}
