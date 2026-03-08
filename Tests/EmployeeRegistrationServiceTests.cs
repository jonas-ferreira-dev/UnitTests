using UnitTests.Dtos;
using UnitTests.Models;
using UnitTests.Services;
using Xunit;

namespace TestProject1;

public class EmployeeRegistrationServiceTests
{
    [Fact]
    public void Register_ShouldThrowException_WhenUserTriesToRegisterAnotherEmployee()
    {
        // Arrange
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Employee A" },
            new Employee { Id = 2, Name = "Employee B" }
        };

        var service = new EmployeeRegistrationService(employees);

        var user = new User
        {
            Id = 1,
            Username = "john",
            EmployeeId = 1,
            IsActive = true
        };

        var request = new RegisterEmployeeRequest
        {
            LoggedUserEmployeeId = 1,
            TargetEmployeeId = 2,
            Data = "Test data"
        };

        // Act & Assert
        var exception = Assert.Throws<UnauthorizedAccessException>(() =>
            service.Register(user, request));

        Assert.Equal("User cannot register another employee.", exception.Message);
    }

    [Fact]
    public void Register_ShouldNotThrowException_WhenUserRegistersOwnEmployee()
    {
        // Arrange
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Employee A" }
        };

        var service = new EmployeeRegistrationService(employees);

        var user = new User
        {
            Id = 1,
            Username = "john",
            EmployeeId = 1,
            IsActive = true
        };

        var request = new RegisterEmployeeRequest
        {
            LoggedUserEmployeeId = 1,
            TargetEmployeeId = 1,
            Data = "Valid registration"
        };

        // Act
        var exception = Record.Exception(() => service.Register(user, request));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Register_ShouldThrowException_WhenEmployeeDoesNotExist()
    {
        // Arrange
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Employee A" }
        };

        var service = new EmployeeRegistrationService(employees);

        var user = new User
        {
            Id = 1,
            Username = "john",
            EmployeeId = 99,
            IsActive = true
        };

        var request = new RegisterEmployeeRequest
        {
            LoggedUserEmployeeId = 99,
            TargetEmployeeId = 99,
            Data = "Test data"
        };

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() =>
            service.Register(user, request));

        Assert.Equal("Employee does not exist.", exception.Message);
    }

    [Fact]
    public void Register_ShouldThrowException_WhenUserIsInactive()
    {
        // Arrange
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Employee A" }
        };

        var service = new EmployeeRegistrationService(employees);

        var user = new User
        {
            Id = 1,
            Username = "john",
            EmployeeId = 1,
            IsActive = false
        };

        var request = new RegisterEmployeeRequest
        {
            LoggedUserEmployeeId = 1,
            TargetEmployeeId = 1,
            Data = "Test data"
        };

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() =>
            service.Register(user, request));

        Assert.Equal("User is inactive.", exception.Message);
    }

    [Fact]
    public void Register_ShouldSaveData_WhenAllRulesAreValid()
    {
        // Arrange
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Employee A" }
        };

        var service = new EmployeeRegistrationService(employees);

        var user = new User
        {
            Id = 1,
            Username = "john",
            EmployeeId = 1,
            IsActive = true
        };

        var request = new RegisterEmployeeRequest
        {
            LoggedUserEmployeeId = 1,
            TargetEmployeeId = 1,
            Data = "Saved successfully"
        };

        // Act
        service.Register(user, request);

        // Assert
        Assert.Equal(1, service.GetSavedRegistrationCount());
    }
}