using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public record Residence (int Number, string Street, string City, string Province, string PostalCode)
        // Creates a READ-ONLY Class named 'Residence'
        // Can initialize values when created, but cannot alter values after created
    {
        // Method
        public override string ToString()
        {
            return $"{Number},{Street},{City},{Province},{PostalCode}";
        }
    }
}
