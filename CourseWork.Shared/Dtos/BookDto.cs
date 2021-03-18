using System;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Shared.Dtos
{
    public abstract class BookDto
    {
        public string Id { get; set; }
        [Range(1920, 2021)] public int PublishYear { get; set; } = DateTime.Now.Year;
        [MaxLength(64)]
        public string BookName { get; set; }
        [StringLength(64, MinimumLength = 1, ErrorMessage = "Author name can`t be shorter that 1 symbol or longer than 64")]
        public string AuthorName { get; set; }
        [StringLength(17, MinimumLength = 1, ErrorMessage = "ISBN can`t be shorter that 1 symbol or longer than 17")]
        public string Isbn { get; set; }
        public string KeyWords { get; set; }
    }
}