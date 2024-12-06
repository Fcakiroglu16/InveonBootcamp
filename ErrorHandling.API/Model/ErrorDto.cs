namespace ErrorHandling.API.Model
{
    public class ErrorDto
    {
        public string Message { get; set; }

        public int MachineId { get; set; }

        public int UserId { get; set; }
    }
}