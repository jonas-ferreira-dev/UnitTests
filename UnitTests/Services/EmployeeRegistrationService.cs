using UnitTests.Dtos;
using UnitTests.Models;

namespace UnitTests.Services;

public class EmployeeRegistrationService : IEmployeeRegistrationService
{
    private readonly List<Employee> _employees;
    private readonly List<string> _registrations = new();

    public EmployeeRegistrationService(List<Employee> employees)
    {
        _employees = employees;
    }

    public void Register(User user, RegisterEmployeeRequest request)
    {
        if (!user.IsActive)
        {
            throw new InvalidOperationException("User is inactive.");
        }

        if (user.EmployeeId != request.TargetEmployeeId)
        {
            throw new UnauthorizedAccessException("User cannot register another employee.");
        }

        var employeeExists = _employees.Any(e => e.Id == request.TargetEmployeeId);

        if (!employeeExists)
        {
            throw new InvalidOperationException("Employee does not exist.");
        }

        _registrations.Add(request.Data);
    }

    public int GetSavedRegistrationCount()
    {
        return _registrations.Count;
    }
}