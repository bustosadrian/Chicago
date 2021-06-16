using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Promotions.Engine.Fixed;
using Promotions.Interfaces;
using Promotions.Interfaces.Repositories;
using Promotions.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Promotions.Tests
{
    public class FixedPromotionsTest
    {
        private ServiceProvider provider;

        private ISKURepository _skuRepository;
        

        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            
            BuildRepositories();

            services.AddSingleton(BuildPromotionEngine());
            provider = services.BuildServiceProvider();
        }

        private void BuildRepositories()
        {
            _skuRepository = A.Fake<ISKURepository>();
            A.CallTo(() => _skuRepository.List()).Returns(
                new List<SKU>()
            {
                new SKU() { Id = "A", Value = 50},
                new SKU() { Id = "B", Value = 30},
                new SKU() { Id = "C", Value = 20},
                new SKU() { Id = "D", Value = 15},
            });
        }

        private IPromotionEngine BuildPromotionEngine()
        {
            FixedPromotionEngine retval = null;

            retval = new FixedPromotionEngine();
            retval.AddPromotion(new FixedPromotion()
            {
                Configuration = new FixedPromotionConfiguration()
                {
                    SkuPromotions = new List<SKUPromotion>
                    {
                        new SKUPromotion()
                        {
                            Skus = new List<SKU> { _skuRepository.List().Single( x=> x.Id == "A") },
                            Quantity = 3,
                            Value = 130,
                        },
                        new SKUPromotion()
                        {
                            Skus = new List<SKU> { _skuRepository.List().Single( x=> x.Id == "B") },
                            Quantity = 2,
                            Value = 45,
                        },
                        new SKUPromotion()
                        {
                            Skus = new List<SKU> {
                                _skuRepository.List().Single( x=> x.Id == "C"),
                                _skuRepository.List().Single( x=> x.Id == "D"),
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
                        Sku = _skuRepository.List().Single( x=> x.Id == "A"),
                        Quantity = 1,
                    },
                    new CartItem()
                    {
                        Sku = _skuRepository.List().Single( x=> x.Id == "B"),
                        Quantity = 1,
                    },
                    new CartItem()
                    {
                        Sku = _skuRepository.List().Single( x=> x.Id == "C"),
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
                        Sku = _skuRepository.List().Single( x=> x.Id == "A"),
                        Quantity = 5,
                    },
                    new CartItem()
                    {
                        Sku = _skuRepository.List().Single( x=> x.Id == "B"),
                        Quantity = 5,
                    },
                    new CartItem()
                    {
                        Sku = _skuRepository.List().Single( x=> x.Id == "C"),
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
