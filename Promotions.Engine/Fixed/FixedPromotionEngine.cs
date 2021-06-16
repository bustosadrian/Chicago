using Promotions.Interfaces;
using Promotions.Interfaces.Repositories;
using Promotions.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Promotions.Engine.Fixed
{
    public class FixedPromotionEngine : IPromotionEngine<FixedPromotion>
    {
       
        private List<FixedPromotion> _promotions;

        public FixedPromotionEngine()
        {
            _promotions = new List<FixedPromotion>();
        }
            
        public void AddPromotion(FixedPromotion promotion)
        {
            _promotions.Add(promotion);
        }

        public PromotionResult Run(Cart cart)
        {
            PromotionResult retval = null;

            var remainingCartItems = cart.Items.Select(
                x => new RemainingCartItem() { Sku = x.Sku, Quantity = x.Quantity }).ToList();

            decimal total = 0;
            foreach(var o in _promotions)
            {
                total = Run(o, remainingCartItems);
            }

            total += remainingCartItems.Sum(x => x.Sku.Value * x.Quantity);

            retval = new PromotionResult()
            {
                Total = total,
            };

            return retval;
        }

        private decimal Run(FixedPromotion promotion, List<RemainingCartItem> remainingCartItems)
        {
            decimal retval = 0;

            var conf = promotion.Configuration;
            foreach(var o in conf.SkuPromotions)
            {
                if(remainingCartItems.Count(x => o.Skus.Contains(x.Sku) && x.Quantity >= o.Quantity) == o.Skus.Count)
                {
                    foreach(var j in o.Skus)
                    {
                        var item = remainingCartItems.SingleOrDefault(x => x.Sku.Equals(j) && x.Quantity >= o.Quantity);
                        int subtracted = item.Quantity / o.Quantity;
                        item.Quantity %= o.Quantity;
                        retval += subtracted * o.Value;
                    }
                }
            }

            return retval;
        }
    }

    class RemainingCartItem
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
