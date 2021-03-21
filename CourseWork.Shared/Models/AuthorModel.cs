namespace CourseWork.Shared.Models
{
    /// <summary>
    /// Represents an author model
    /// </summary>
    public class AuthorModel
    {
        /// <summary>
        /// User model unique identifier 
        /// </summary>
        /// <remarks>
        /// Represented by a GUID in a string view
        /// </remarks>
        public string Id { get; set; }
        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }
    }
}
