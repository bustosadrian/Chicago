using System.Collections.Generic;

namespace Promotions.Model.Entities
{
    public class Cart
    {
        public int Id
        {
            get;
            set;
        }

        public List<CartItem> Items
        {
            get;
            set;
        }
    }
}
