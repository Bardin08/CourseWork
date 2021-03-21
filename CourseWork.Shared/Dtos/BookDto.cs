using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CourseWork.Shared.Models;

namespace CourseWork.Shared.Dtos
{
    public class BookDto
    {
        public BookDto()
        {
            Author = new AuthorModel();
            KeyWordModels = new List<KeyWordModel>();
        }
        
        public string Id { get; set; }
        [Range(1920, 2021)] 
        public int PublishYear { get; set; } = DateTime.Now.Year;
        [MaxLength(64)]
        public string BookName { get; set; }
        [StringLength(64, MinimumLength = 1, ErrorMessage = "Author name can`t be shorter that 1 symbol or longer than 64")]
        public string AuthorName { get; set; }
        [StringLength(17, MinimumLength = 1, ErrorMessage = "Isbn can`t be shorter that 1 symbol or longer than 17")]
        public string Isbn { get; set; }
        public string KeyWordsString { get; set; }
        public AuthorModel Author { get; set; }
        
        [MaxLength(1024, ErrorMessage = "Description can`t be longer than 1024 characters")]
        public string Description { get; set; }
        public List<KeyWordModel> KeyWordModels { get; set; }

    }
}