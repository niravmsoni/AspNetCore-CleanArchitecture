using AutoMapper;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly IMapper _mapper;

        public LeaveTypeService(IClient client,
            IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }

        public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            try
            {
                //Need to map from LeaveTypeVM to LeaveTypeCommand
                var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertAPIExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteLeaveType(int id)
        {
            try
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertAPIExceptions<Guid>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var leaveTypes = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(leaveTypes);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            //LeaveTypes will be of LeaveTypeDTO. For converting it to LeaveTypeVM, we'll use AutoMapper
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);
                await _client.LeaveTypesPUTAsync(id.ToString(), updateLeaveTypeCommand);
                return new Response<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertAPIExceptions<Guid>(ex);
            }
        }
    }
}
