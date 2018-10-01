using System;

namespace OldMacDonald.Song
{
    /// <summary>
    /// A custom exception class for the library.
    /// </summary>
    public class SongException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SongException"/> class.
        /// </summary>
        public SongException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SongException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The exception which caused this exception.</param>
        public SongException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SongException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public SongException(string message)
            : this(message, null)
        {
        }
    }
}
