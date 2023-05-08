using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class DeleteLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
