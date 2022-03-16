using AutoMapper;
using eTicaret.Core.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
/*
        public async Task<IActionResult> Checkout(Cart model)
        {
        
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(Cart model)
        {
        
            var payment = PaymentProcess(model);
            if (payment.Status == "success") {

                SaveOrder(model, paymeny, userId);
                ClearCart(userId);
                return Ok("Success");
            }
            return BadRequest();
        }
*/
        private Payment PaymentProcess(Cart model)
        {
            
                Options options = new Options();
                options.ApiKey = "sandbox-D58SvNumDURFcbAz9AwyjQd44v1e8Xsg";
                options.SecretKey = "sandbox-p8jwHdFXk9VEDifaXY0Mxmi9WBcFMPEc";
                options.BaseUrl = "https://sandbox-api.iyzipay.com";

                CreatePaymentRequest request = new CreatePaymentRequest();
                request.Locale = Locale.TR.ToString();
                request.ConversationId = "123456789";
                request.Price = "1";
                request.PaidPrice = "2.2";
                request.Currency = Currency.TRY.ToString();
                request.Installment = 1;
                request.BasketId = "B67832";
                request.PaymentChannel = PaymentChannel.WEB.ToString();
                request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

                PaymentCard paymentCard = new PaymentCard();
                paymentCard.CardHolderName = "Batu";
                paymentCard.CardNumber = "5528790000000008";
                paymentCard.ExpireMonth = "12";
                paymentCard.ExpireYear = "2030";
                paymentCard.Cvc = "123";
                paymentCard.RegisterCard = 0;
                request.PaymentCard = paymentCard;

                Buyer buyer = new Buyer();
                buyer.Id = "BY789";
                buyer.Name = "John";
                buyer.Surname = "Doe";
                buyer.GsmNumber = "+905350000000";
                buyer.Email = "email@email.com";
                buyer.IdentityNumber = "74300864791";
                buyer.LastLoginDate = "2015-10-05 12:43:35";
                buyer.RegistrationDate = "2013-04-21 15:12:09";
                buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                buyer.Ip = "85.34.78.112";
                buyer.City = "Istanbul";
                buyer.Country = "Turkey";
                buyer.ZipCode = "34732";
                request.Buyer = buyer;

                Address shippingAddress = new Address();
                shippingAddress.ContactName = "Jane Doe";
                shippingAddress.City = "Istanbul";
                shippingAddress.Country = "Turkey";
                shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                shippingAddress.ZipCode = "34742";
                request.ShippingAddress = shippingAddress;

                Address billingAddress = new Address();
                billingAddress.ContactName = "Jane Doe";
                billingAddress.City = "Istanbul";
                billingAddress.Country = "Turkey";
                billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                billingAddress.ZipCode = "34742";
                request.BillingAddress = billingAddress;

                List<BasketItem> basketItems = new List<BasketItem>();
                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = "BI101";
                firstBasketItem.Name = "Binocular";
                firstBasketItem.Category1 = "Collectibles";
                firstBasketItem.Category2 = "Accessories";
                firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                firstBasketItem.Price = "0.3";
                basketItems.Add(firstBasketItem);

                BasketItem secondBasketItem = new BasketItem();
                secondBasketItem.Id = "BI102";
                secondBasketItem.Name = "Game code";
                secondBasketItem.Category1 = "Game";
                secondBasketItem.Category2 = "Online Game Items";
                secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
                secondBasketItem.Price = "0.5";
                basketItems.Add(secondBasketItem);

                BasketItem thirdBasketItem = new BasketItem();
                thirdBasketItem.Id = "BI103";
                thirdBasketItem.Name = "Usb";
                thirdBasketItem.Category1 = "Electronics";
                thirdBasketItem.Category2 = "Usb / Cable";
                thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                thirdBasketItem.Price = "0.2";
                basketItems.Add(thirdBasketItem);
                request.BasketItems = basketItems;

                return Payment.Create(request, options);

            
        }
    } }
