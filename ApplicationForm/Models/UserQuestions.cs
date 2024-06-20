namespace ApplicationForm.Models
{
    public class UserQuestions
    {
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
        public List<string> Options { get; set; } // Used for Dropdown and Multiple Choice
    }
   
}
