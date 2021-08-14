using E_Store.Business.Classes;

namespace E_Store.Business.Managers
{
    using System.Linq;
    using System;
    using System.Web;

    using Newtonsoft.Json;

    using Extensions;
    using E_Store.Data.Interfaces.Repositories;
    using E_Store.Data.Classes;
    using Interfaces;
    using Data.Models;
    
    using Microsoft.AspNetCore.Http;
    
    public class OrderManager : IOrderManager
    {
        private readonly IEOrderRepository eOrderRepository;
        private readonly IHttpContextAccessor context;
        private readonly IProductRepository productRepository;
        private readonly IProductEOrderRepository productEOrderRepository;

        public OrderManager(IEOrderRepository eOrderRepository, 
            IHttpContextAccessor httpContext,
            IProductRepository productRepository,
            IProductEOrderRepository productEOrderRepository)
        {
            this.eOrderRepository = eOrderRepository;
            this.context = httpContext;
            this.productRepository = productRepository;
            this.productEOrderRepository = productEOrderRepository;
        }
        
        public EOrder CreateOrder()
        {
            var token = Guid.NewGuid().ToString();

            var order = new EOrder()
            {
                Token = token,
                Created = DateTime.UtcNow,
                StateId = OrderState.Created
            };
            
            this.eOrderRepository.Insert(order);

            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["order_id"] = order.Id.ToString();
            queryString["token"] = token;

            var options = new CookieOptions()
            {
                Expires = DateTime.Now.Add(TimeSpan.FromDays(365))
            };
            
            this.context.HttpContext?.Response
                .Cookies
                .Append("order", JsonConvert.SerializeObject(queryString, Formatting.Indented), options);

            return order;
        }

        public EOrder GetOrder(int? orderId = null, bool create = true)
        {
            if (orderId.HasValue)
                return this.eOrderRepository.FindById(orderId.Value);

            var attemptRetrieve = this.context.HttpContext?.Session.GetInt32("orderId");

            if (attemptRetrieve.HasValue)
                return this.eOrderRepository.FindById(attemptRetrieve.Value);

            var id = 0;
            string token = null;
            var fromCookie = this.context.HttpContext.GetCookie("order");

            if (fromCookie != string.Empty)
            {
                var queryString = HttpUtility.ParseQueryString(fromCookie);
                int.TryParse(queryString.Get("order_id"), out id);

                token = queryString.Get("token");
            }

            if (!create && id == 0)
                return null;

            var order = this.eOrderRepository.FindOrderByIdTokenState(id, token, OrderState.Created) 
                        ?? CreateOrder();
            
            this.context.HttpContext?.Session.SetInt32("orderId", order.Id);
            return order;
        }

        public bool IsProductAvailable(int productId)
        {
            var product = this.productRepository.FindById(productId);

            if (product == null)
                return false;

            return !product.Hidden &&
                   product.CategoryProducts.Any(x => !x.Category.Hidden) &&
                   product.Stock > 0;
        }

        public void AddProducts(int productId, int quantity, int? orderId = null, bool ignoreHiddenProducts = false)
        {
            var order = GetOrder(orderId);

            if (quantity <= 0)
                throw new Exception("Cannot add a negative number of items");

            if (!ignoreHiddenProducts && !IsProductAvailable(productId))
                throw new Exception("The product is not available");

            var item = this.productEOrderRepository.FindByOrderIdProductId(order.Id, productId);

            if (item == null)
            {
                this.productEOrderRepository.Insert(new ProductEOrder()
                {
                    ProductId = productId,
                    EOrderId = order.Id,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
                this.productEOrderRepository.Update(item);
            }
        }

        public OrderSummary GetOrderSummary(int? orderId = null)
        {
            var order = GetOrder(orderId, false);

            if (order == null)
                return new OrderSummary() {Products = 0, Price = 0};

            var items = this.productEOrderRepository
                .FindByOrderId(order.Id)
                .ToList();

            var result = new OrderSummary
            {
                Products = items.Sum(x => x.Quantity),
                Price = items.Sum(x => x.Quantity * x.Product.Price)
            };

            return result;
        }
    }
}