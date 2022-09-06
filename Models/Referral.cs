namespace ReferralsApp.Models
{
    public class Referral
    {

        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Note { get; set; }

        public string Referrer { get; set; }

        public static DateTime Created { get; set; }

        public DateTime? LastModified { get; set; } = null!;

        public Referral(string lastName, string firstName, string? note, string referrer)
        {
            LastName = lastName;
            FirstName = firstName;
            Note = note;
            Referrer = referrer;
            Created = DateTime.UtcNow;
        }

    }

}
