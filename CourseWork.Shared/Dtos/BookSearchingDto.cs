using System;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Domain.Dtos
{
    public class BookSearchingDto
    {
        [Range(1920, 2021)] public int PublishYear { get; set; } = DateTime.Now.Year;
        [MaxLength(64)]
        public string BookName { get; set; }
        [StringLength(64, MinimumLength = 1, ErrorMessage = "Author name can`t be shorter that 1 symbol or longer than 64")]
        public string AuthorName { get; set; }
        [StringLength(17, MinimumLength = 1, ErrorMessage = "ISBN can`t be shorter that 1 symbol or longer than 17")]
        public string Isbn { get; set; }
        public string KeyWords { get; set; }
        
        public bool SearchByName { get; set; }
        public bool SearchByAuthor { get; set; }
        public bool SearchByPublishYear { get; set; }
        public bool SearchByKeyWords { get; set; }
        public bool SearchByIsbn { get; set; }

        public int SearchingCriteriaAmount
        {
            get
            {
                var criteriaAmount = 0;

                if (SearchByName) criteriaAmount++;
                if (SearchByAuthor) criteriaAmount++;
                if (SearchByPublishYear) criteriaAmount++;
                if (SearchByKeyWords) criteriaAmount++;
                if (SearchByIsbn) criteriaAmount++;

                return criteriaAmount;
            }
        }

    }
}