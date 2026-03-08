namespace UnitTests.Dtos
{
    public class RegisterEmployeeRequest
    {
        public int LoggedUserEmployeeId { get; set; }
        public int TargetEmployeeId { get; set; }
        public string Data { get; set; } = string.Empty;

    }
}
