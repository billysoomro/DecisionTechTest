using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DecisionTech.ShoppingCart.Domain;
using DecisionTech.ShoppingCart.Interfaces;

namespace DecisionTech.ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<IOrderProcessor>().ImplementedBy<OrderProcessor>());
            container.Register(Component.For<IShop>().ImplementedBy<Shop>());
            container.Register(Component.For<IBread>().ImplementedBy<Bread>());
            container.Register(Component.For<IButter>().ImplementedBy<Butter>());
            container.Register(Component.For<IMilk>().ImplementedBy<Milk>());

            var orderProcessor = container.Resolve<IOrderProcessor>();
            var shop = container.Resolve<IShop>();

            Console.WriteLine(shop.MainText());
            var basket = Console.ReadLine();

            Console.WriteLine(orderProcessor.ProcessOrders(basket));
            Console.ReadLine();
        }
    }
}
