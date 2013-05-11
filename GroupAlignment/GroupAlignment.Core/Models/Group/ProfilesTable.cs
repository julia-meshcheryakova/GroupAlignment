
namespace GroupAlignment.Core.Models.Group
{
    using System.Collections.Generic;

    using global::GroupAlignment.Core.Extensions;

    /// <summary>
    /// The table of profiles alignments. Index - numbers of profiles used.
    /// </summary>
    public class ProfilesTable : Dictionary<Index, ProfileTableItem>
    {
    }
}