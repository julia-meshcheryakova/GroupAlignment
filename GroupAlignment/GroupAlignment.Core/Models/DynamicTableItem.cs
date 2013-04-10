
namespace GroupAlignment.Core.Models
{
    using System.Collections.Generic;
    using System.Web.UI;

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
        public DynamicTableItem(int distance, List<Pair> predecessors)
        {
            this.Distance = distance;
            this.Predecessors = predecessors;
        }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Gets or sets the predecessors list.
        /// </summary>
        public List<Pair> Predecessors { get; set; }
    }
}