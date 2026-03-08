using UnitTests.Dtos;
using UnitTests.Models;

namespace UnitTests.Services;

public interface IEmployeeRegistrationService
{
    void Register(User user, RegisterEmployeeRequest request);
}