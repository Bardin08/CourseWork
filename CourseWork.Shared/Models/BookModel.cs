﻿using System.Collections.Generic;

namespace CourseWork.Shared.Models
{
    /// <summary>
    /// Represents book model
    /// </summary>
    public class BookModel
    {
        /// <summary>
        /// Unique book identifier
        /// </summary>
        /// <remarks>
        /// Represented by a GUID in a string view
        /// </remarks>
        public string Id { get; init; }
        /// <summary>
        /// International standard book number
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// Book name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Book description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Book author
        /// </summary>
        /// <remarks>
        /// Represented by <see cref="AuthorModel"/>
        /// </remarks>
        public AuthorModel Author { get; init; }
        /// <summary>
        /// Book publish year
        /// </summary>
        public int PublishYear { get; set; }
        /// <summary>
        /// A list of <see cref="KeyWordModel"/>
        /// </summary>
        public List<KeyWordModel> KeyWords { get; init; }
    }
}
