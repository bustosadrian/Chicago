using Promotions.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
