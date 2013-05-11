namespace GroupAlignment.Core.Extensions
{
    using System;

    /// <summary>
    /// The pair.
    /// </summary>
    public class Index : Tuple<int, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        /// <param name="item1">The item 1.</param>
        /// <param name="item2">The item 2.</param>
        public Index(int item1, int item2)
            : base(item1, item2)
        {
        }
    }
}
