using CourseWork.Domain.Models.Enums;

namespace CourseWork.Domain.Models
{
    public class UserModel
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
        /// <summary>
        /// User role
        /// </summary>
        /// <remarks>
        /// Represented by a <see cref="UserRole"/>
        /// </remarks>
        public UserRole Role { get; set; }
    }
}
