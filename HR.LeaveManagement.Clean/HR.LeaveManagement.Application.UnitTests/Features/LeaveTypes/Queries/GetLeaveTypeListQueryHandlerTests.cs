using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeListQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockappLogger;

        public GetLeaveTypeListQueryHandlerTests()
        {
            _mockLeaveTypeRepository = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockappLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            //Creating handler
            var handler = new GetLeaveTypesQueryHandler(
                _mapper,
                _mockLeaveTypeRepository.Object,
                _mockappLogger.Object);

            var result = await handler.Handle(new GetLeaveTypesQuery(),
                CancellationToken.None);

            //Asserting the data type that's getting returned and count
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
