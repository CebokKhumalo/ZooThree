using System.ComponentModel.DataAnnotations;

namespace ZooThree.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}