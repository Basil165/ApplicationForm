namespace ApplicationForm.Models
{
    public class UserSubmission
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? Residence { get; set; }
        public string? IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? AboutYourself { get; set; }
        public Boolean rejectedUk { get; set; }
        public List<string>? multipleChoices { get; set; }
        public string? experience { get; set; }
        public DateTime movedUk { get; set; }
        public List<string>? YearOfGraduation { get; set; }
    }
}
