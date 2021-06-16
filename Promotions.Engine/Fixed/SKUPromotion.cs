using Promotions.Model.Entities;
using System.Collections.Generic;

namespace Promotions.Engine.Fixed
{
    public class SKUPromotion
    {
        public List<SKU> Skus
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public decimal Value
        {
            get;
            set;
        }
    }
}
