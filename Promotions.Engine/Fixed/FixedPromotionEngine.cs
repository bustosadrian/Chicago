using Promotions.Interfaces;
using Promotions.Model.Entities;
using System.Collections.Generic;

namespace Promotions.Engine.Fixed
{
    public class FixedPromotionEngine : IPromotionEngine<FixedPromotion>
    {
        private List<FixedPromotion> _promotions;

        public void AddPromotion(FixedPromotion promotion)
        {
            _promotions.Add(promotion);
        }

        public PromotionResult Run(Cart cart)
        {
            PromotionResult retval = null;

            

            return retval;
        }

        private bool IsValid(FixedPromotion promotion, Cart cart)
        {
            bool retval = false;



            return retval;
        }
    }
}
