using Promotions.Model.Entities;
using System.Collections.Generic;

namespace Promotions.Engine.Fixed
{
    public class FixedPromotionConfiguration : PromotionConfiguration
    {
        public List<SKUPromotion> SkuPromotions
        {
            get;
            set;
        }
    }
}
