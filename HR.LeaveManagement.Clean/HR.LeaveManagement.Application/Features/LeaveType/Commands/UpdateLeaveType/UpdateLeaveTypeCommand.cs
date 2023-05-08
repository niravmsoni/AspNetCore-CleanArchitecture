using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    //Return type Unit since we can't return void from MediatR
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
