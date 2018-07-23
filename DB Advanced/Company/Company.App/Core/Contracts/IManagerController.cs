namespace Company.App.Core.Contracts
{
    using Company.App.Core.DTOs;

    public interface IManagerController
    {
        void SetManager(int employeeId, int managerId);

        ManagerDto GetManagerInfo(int employeeId);
    }
}
