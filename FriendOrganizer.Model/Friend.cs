
namespace FriendOrganizer.Model
{
    public class Friend
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public int? FavoriteLanguageId { get; set; }

        public ProgrammingLanguage? FavoriteLanguage { get; set; }
    }
}
