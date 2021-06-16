using Promotions.Model.Entities;

namespace Promotions.Interfaces
{
    public interface IPromotionEngine
    {
        PromotionResult Run(Cart cart);
    }
    public interface IPromotionEngine<T> : IPromotionEngine where T : Promotion
    {
        void AddPromotion(T promotion);
        
    }
}
