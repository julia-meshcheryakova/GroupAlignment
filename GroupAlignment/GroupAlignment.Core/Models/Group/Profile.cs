﻿
namespace GroupAlignment.Core.Models.Group
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The profile item.
    /// </summary>
    public class Profile : List<ProfileItem>, IEquatable<Profile>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The indexer override.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Nucleotide"/>.</returns>
        public new ProfileItem this[int index]
        {
            get
            {
                return index > this.Count || index <= 0 ? null : base[index - 1];
            }
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Profile);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">The other pair.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Equals(Profile other)
        {
            return true;
        }
    }
}
