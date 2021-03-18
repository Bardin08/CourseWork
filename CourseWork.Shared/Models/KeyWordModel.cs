namespace CourseWork.Shared.Models
{
    public class KeyWordModel
    {
        /// <summary>
        /// Keyword Id
        /// </summary>
        /// <remarks>
        /// Represented by a GUID in a string view
        /// </remarks>
        public string Id { get; set; }
        /// <summary>
        /// Keyword string representation
        /// </summary>
        public string Word { get; set; }
    }
}
