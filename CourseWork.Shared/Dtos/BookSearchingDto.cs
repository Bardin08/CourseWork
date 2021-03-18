namespace CourseWork.Shared.Dtos
{
    public class BookSearchingDto : BookDto
    {
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