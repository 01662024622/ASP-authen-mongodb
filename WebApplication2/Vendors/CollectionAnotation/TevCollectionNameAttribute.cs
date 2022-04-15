using System;

namespace WebApplication2.Vendors.CollectionAnotation
{
    public class TevCollectionNameAttribute:Attribute
    {
        public TevCollectionNameAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name of collection is null or have white space");
            }

            Name = name;
        }

        /// <summary>
        ///     The name of the table the class is mapped to.
        /// </summary>
        public string Name { get; }
    }
}