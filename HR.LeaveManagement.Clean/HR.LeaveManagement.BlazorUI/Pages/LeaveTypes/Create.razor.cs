using Microsoft.AspNetCore.Components;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using Blazored.Toast.Services;

namespace HR.LeaveManagement.BlazorUI.Pages.LeaveTypes
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }
        
        [Inject]
        ILeaveTypeService _client { get; set; }

        [Inject]
        IToastService toastService { get; set; }

        public string Message { get; private set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();
        async Task CreateLeaveType()
        {
            var response = await _client.CreateLeaveType(leaveType);
            if (response.Success)
            {
                //Show Toast message
                toastService.ShowSuccess("Leave Type created Successfully");
                toastService.ShowToast(ToastLevel.Info, "Test");

                _navManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }
    }
}