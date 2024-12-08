namespace IdentityApp.Web.Models.Repositories
{
    public class UserFeature
    {
        public Guid UserId { get; set; }
        public string Gender { get; set; } = default!;

        public AppUser AppUser { get; set; } = default!;
    }
}