namespace LibrarySystem.API.Requests
{
    public class UpdateMemberRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone {  get; set; }
        public string? Address { get; set; }



    }
}
