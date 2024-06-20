using ApplicationForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationForm.Controllers
{
    public class UserDataController : Controller
    {
        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            var questions = new List<UserQuestions>
            {
                new UserQuestions { QuestionType = "date", QuestionText = "What is your date of birth?" },
                new UserQuestions { QuestionType = "dropdown", QuestionText = "What is your nationality?", Options = new List<string> { "Nigeria", "Zambia", "Argentina" } },
                new UserQuestions { QuestionType = "textbox", QuestionText = "Please tell us about yourself" },
                 new UserQuestions { QuestionType = "textbox", QuestionText = "First Name" },
                  new UserQuestions { QuestionType = "textbox", QuestionText = "Last Name" },
                     new UserQuestions { QuestionType = "textbox", QuestionText = "Email" },
                new UserQuestions { QuestionType = "multiple choice", QuestionText = "What are your hobbies?", Options = new List<string> { "Reading", "Traveling", "Cooking" } }
            };

            return Ok(questions);
        }

        [HttpPost("submit")]
        public IActionResult SubmitUser([FromBody] UserSubmission userSubmission)
        {
            if (ModelState.IsValid)
            {
                
                return Ok(new { message = "Submission successful!" });
            }

            return BadRequest(ModelState);
        }


    }
}
