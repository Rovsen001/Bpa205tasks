using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{

    using System;
    using System.Collections.Generic;

    public class BaseEntity<TId>
    {
        public TId Id { get; set; }

        public override bool Equals(object obj)
        {

            if (obj is BaseEntity<TId> other)
            {
                return EqualityComparer<TId>.Default.Equals(Id, other.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }
    }







}
