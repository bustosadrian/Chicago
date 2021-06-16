using Promotions.Model.Entities;

namespace Promotions.Interfaces
{
    public interface IPromotionEngine
    {
        void AddPromotion(Promotion promotion);

        PromotionResult Run(Cart cart);
    }
}
