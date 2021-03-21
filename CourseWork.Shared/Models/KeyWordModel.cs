namespace CourseWork.Shared.Models
{
    /// <summary>
    /// Represents a keyword model
    /// </summary>
    public record KeyWordModel
    {
        /// <summary>
        /// Keyword Id
        /// </summary>
        /// <remarks>
        /// Represented by a GUID in a string view
        /// </remarks>
        public string Id { get; init; }
        /// <summary>
        /// Keyword string representation
        /// </summary>
        public string Word { get; init; }
        
        public static implicit operator string(KeyWordModel model)
        {
            return model.Word;
        }
    }
}
