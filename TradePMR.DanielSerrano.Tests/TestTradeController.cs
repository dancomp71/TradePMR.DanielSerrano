using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data;
using TradePMR.DanielSerrano.Data.Models;
using TradePMR.DanielSerrano.WebApp.Api;

namespace TradePMR.DanielSerrano.Tests
{
    [TestClass]
    public class TestTradeController
    {
        private TradePMRDbContext CreateDbContext(string name = null)
        {
            if (name == null)
            {
                name = Guid.NewGuid().ToString();
            }
            DbContextOptions<TradePMRDbContext> options = new DbContextOptionsBuilder<TradePMRDbContext>()
                .UseInMemoryDatabase(name)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .EnableSensitiveDataLogging()
                .Options;
            var db = new TradePMRDbContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        [TestMethod]
        public void TestGetAll()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);

            // act
            var result = controller.Get(new Data.Models.TradeQueryParameter() { });
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as IEnumerable<Trade>).ToArray();

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 2);
            Assert.AreEqual(1, data[0].Id);
        }

        [TestMethod]
        public void TestGetTradesByAccountId()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);

            // act
            var result = controller.Get(new Data.Models.TradeQueryParameter()
            {
                AccountId = 1
            });
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as IEnumerable<Trade>).ToArray();

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length == 2);
            Assert.AreEqual(1, data[0].Id);
        }

        [TestMethod]
        public void TestGetSkip0Take1()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);
            var p = new TradeQueryParameter()
            {
                Skip = 0,
                Take = 1
            };

            // act
            var okResult = controller.Get(p) as OkObjectResult;
            var data = (okResult.Value as IEnumerable<Trade>).ToArray();

            // assert
            Assert.AreEqual(1, data.Count());
            Assert.AreEqual(1, data[0].Id);
            Assert.AreEqual(1, data[0].AccountId);
        }

        [TestMethod]
        public void TestGetById()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);

            // act
            var okResult = controller.Get(1) as OkObjectResult;
            var data = (okResult.Value as Trade);

            // assert
            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.Id);
        }

        [TestMethod]
        public void TestAdd()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);

            var trade = new Trade()
            {
                Id = 4,
                AccountId = 1,
                Action = TradeActions.Buy,
                Quantity = 1,
                Symbol = "MSFT"
            };

            // act
            var result = controller.Post(trade);
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as Trade);

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(data);
            Assert.AreEqual(4, trade.Id);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);

            var trade = ((controller.Get(2) as OkObjectResult).Value as Trade);
            trade.Quantity = 15;

            // act
            var result = controller.Put(2, trade);
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as Trade);

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.AreEqual(2, trade.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);

            // act
            var result = controller.Delete(2);

            var okResult = result as OkObjectResult;
            var trade = (okResult.Value as Trade);

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(trade);
            Assert.AreEqual(2, trade.Id);

            Assert.IsTrue(!context.Trades.Any(x => x.Id == 2));
        }

        [TestMethod]
        public void TestUpdateAccountIdValidationError()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new TradesController(context);

            var trade = new PutTradeParameter
            {
                Id = 2,
                AccountId = 1,
                Action = TradeActions.Sell,
                Quantity = 10,
                Symbol = "GE"
            };

            // act
            var result = controller.Put(2, trade);
            var brRequest = result as BadRequestObjectResult;
            var data = (brRequest.Value as IEnumerable<ValidationResult>).ToArray();

            // assert
            Assert.IsNotNull(brRequest);
            Assert.AreEqual(400, brRequest.StatusCode);

            Assert.AreEqual("AccountId cannot be modified", data[0].ErrorMessage);
            Assert.AreEqual(2, trade.Id);
        }

    }
}
