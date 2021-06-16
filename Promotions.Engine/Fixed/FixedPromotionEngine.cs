using Promotions.Interfaces;
using Promotions.Model.Entities;

namespace Promotions.Engine.Fixed
{
    public class FixedPromotionEngine : BaseEngine, IPromotionEngine
    {
        public void AddPromotion(Promotion promotion)
        {
            throw new System.NotImplementedException();
        }

        public PromotionResult Run(Cart cart)
        {
            throw new System.NotImplementedException();
        }
    }
}
