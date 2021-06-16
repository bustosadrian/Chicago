using System;
using System.Collections.Generic;
using System.Text;

namespace Promotions.Model.Entities
{
    public class CartItem
    {
        public SKU Sku
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }
}
