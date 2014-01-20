namespace TspLibNet.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Graph exception thrown when graph is not consistent
    /// </summary>
    public class GraphException : Exception
    {
        /// <summary>
        /// Creates a new instance of a GraphException class.
        /// </summary>
        public GraphException()
        {
        }

        /// <summary>
        /// Creates a new instance of a GraphException class.
        /// </summary>
        /// <param name="message">Exception message</param>
        public GraphException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of a GraphException class.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public GraphException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
