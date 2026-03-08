namespace UnitTests.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
    public bool IsActive { get; set; }
}