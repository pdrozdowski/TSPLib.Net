namespace TspLibNet.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Exception thrown when tour is not valid
    /// </summary>
    public class TourInvalidException : Exception
    {
        /// <summary>
        /// Creates a new instance of a TourInvalidException class.
        /// </summary>
        public TourInvalidException()
        {
        }

        /// <summary>
        /// Creates a new instance of a TourInvalidException class.
        /// </summary>
        /// <param name="message">Exception message</param>
        public TourInvalidException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of a TourInvalidException class.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public TourInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
