using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Promotions.Engine.Fixed;
using Promotions.Interfaces;
using Promotions.Model.Entities;
using System.Collections.Generic;

namespace Promotions.Tests
{
    public class FixedPromotionsTest
    {
        private ServiceProvider provider;


        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPromotionEngine>(BuildPromotionEngine());
            provider = services.BuildServiceProvider();
        }

        private IPromotionEngine BuildPromotionEngine()
        {
            IPromotionEngine retval = null;

            var engine = new FixedPromotionEngine();
            engine.AddPromotion(new FixedPromotion()
            {
                Configuration = new FixedPromotionConfiguration()
                {
                    SkuPromotions = new List<SKUPromotion>
                    {
                        new SKUPromotion()
                        {
                            Skus = new List<SKU> { new SKU() { Id = "A" } },
                            Quantity = 3,
                            Value = 130,
                        },
                        new SKUPromotion()
                        {
                            Skus = new List<SKU> { new SKU() { Id = "B" } },
                            Quantity = 2,
                            Value = 45,
                        },
                        new SKUPromotion()
                        {
                            Skus = new List<SKU> {
                                new SKU() { Id = "C" },
                                new SKU() { Id = "D" },
                            },
                            Quantity = 1,
                            Value = 30,
                        }
                    }
                }
            });

            return retval;
        }

        [Test]
        public void TestScenarioA()
        {
            var engine = provider.GetRequiredService<IPromotionEngine>();
            Cart cart = new Cart()
            {
                Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        Sku = new SKU() { Id = "A"},
                        Quantity = 1,
                    },
                    new CartItem()
                    {
                        Sku = new SKU() { Id = "B"},
                        Quantity = 1,
                    },
                    new CartItem()
                    {
                        Sku = new SKU() { Id = "C"},
                        Quantity = 1,
                    },
                }
            };
            PromotionResult result = engine.Run(cart);
            Assert.NotNull(result);
            Assert.AreEqual(result.Total, 100);
        }

        [Test]
        public void TestScenarioB()
        {
            var engine = provider.GetRequiredService<IPromotionEngine>();
            Cart cart = new Cart()
            {
                Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        Sku = new SKU() { Id = "A"},
                        Quantity = 5,
                    },
                    new CartItem()
                    {
                        Sku = new SKU() { Id = "B"},
                        Quantity = 5,
                    },
                    new CartItem()
                    {
                        Sku = new SKU() { Id = "C"},
                        Quantity = 1,
                    },
                }
            };
            PromotionResult result = engine.Run(cart);
            Assert.NotNull(result);
            Assert.AreEqual(result.Total, 370);
        }
    }
}
