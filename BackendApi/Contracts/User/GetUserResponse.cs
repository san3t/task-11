namespace BackendApi.Contracts.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? UserEmail { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

    }
}
