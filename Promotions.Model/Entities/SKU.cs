using System.Collections.Generic;

namespace Promotions.Model.Entities
{
    public class SKU
    {
        public string Id
        {
            get;
            set;
        }

        public decimal Value
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            return obj is SKU sKU &&
                   Id == sKU.Id;
        }

        public override int GetHashCode()
        {
            int hashCode = 1325046378;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }
    }
}
