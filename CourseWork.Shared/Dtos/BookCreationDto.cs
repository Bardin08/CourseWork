using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseWork.Shared.Models;

namespace CourseWork.Shared.Dtos
{
    public class BookCreationDto : BookDto
    {
        public UserModel Author { get; set; }
        [MaxLength(1024, ErrorMessage = "Description can`t be longer than 1024 characters")]
        public string Description { get; set; }
        
        public new List<KeyWordModel> KeyWordModels { get; set; }
    }
}