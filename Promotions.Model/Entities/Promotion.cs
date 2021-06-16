namespace Promotions.Model.Entities
{
    public class Promotion
    {
        public int Id
        {
            get;
            set;
        }
    }

    public abstract class Promotion<T> : Promotion where T : PromotionConfiguration
    {
        public T Configuration
        {
            get;
            set;
        }
    }
}
