
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;

    using global::GroupAlignment.Core.Extensions;

    /// <summary>
    /// The dynamic table item.
    /// </summary>
    public class DynamicTableItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTableItem"/> class.
        /// </summary>
        public DynamicTableItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTableItem"/> class.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="predecessors">The predecessors list.</param>
        /// <param name="current">The current pair.</param>
        public DynamicTableItem(double distance, List<Index> predecessors, Index current = null)
        {
            this.Distance = distance;
            this.Current = current;
            this.Predecessors = predecessors;
        }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Gets or sets the current pair.
        /// </summary>
        public Index Current { get; set; }

        /// <summary>
        /// Gets or sets the predecessors list.
        /// </summary>
        public List<Index> Predecessors { get; set; }
    }
}