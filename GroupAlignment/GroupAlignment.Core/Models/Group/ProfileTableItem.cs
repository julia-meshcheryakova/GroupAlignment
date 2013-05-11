
namespace GroupAlignment.Core.Models.Group
{
    /// <summary>
    /// The dynamic table item.
    /// </summary>
    public class ProfileTableItem : DynamicTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileTableItem"/> class.
        /// </summary>
        public ProfileTableItem()
        {   
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileTableItem"/> class.
        /// </summary>
        /// <param name="first">The first profile.</param>
        /// <param name="second">The second profile.</param>
        public ProfileTableItem(Profile first, Profile second)
        {
            this.First = first;
            this.Second = second;
        }

        /// <summary>
        /// Gets or sets the first profile.
        /// </summary>
        public Profile First { get; set; }

        /// <summary>
        /// Gets or sets the second profile.
        /// </summary>
        public Profile Second { get; set; }
    }
}