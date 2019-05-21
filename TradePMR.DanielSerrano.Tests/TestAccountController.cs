using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data;
using TradePMR.DanielSerrano.Data.Models;
using TradePMR.DanielSerrano.WebApp.Api;

namespace TradePMR.DanielSerrano.Tests
{
    [TestClass]
    public class TestAccountController
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
            var controller = new AccountsController(context);

            // act
            var result = controller.Get(new Data.Models.AccountQueryParameter()
            {
                Name = "Steve"
            });
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as IEnumerable<Account>).ToArray();

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length > 0);
            Assert.AreEqual("Steve", data[0].Name);
        }

        [TestMethod]
        public void TestGet()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new AccountsController(context);

            // act
            var result = controller.Get(new Data.Models.AccountQueryParameter()
            {
                Name = "Steve",
                Skip = 0,
                Take = 1
            });
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as IEnumerable<Account>).ToArray();

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Length == 1);
            Assert.AreEqual("Steve", data[0].Name);
        }

        [TestMethod]
        public void TestGetSkip0Take1()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new AccountsController(context);
            var p = new AccountQueryParameter()
            {
                Skip = 0,
                Take = 1
            };

            // act
            var okResult = controller.Get(p) as OkObjectResult;
            var data = (okResult.Value as IEnumerable<Account>).ToArray();

            // assert
            Assert.AreEqual(1, data.Count());
            Assert.AreEqual(1, data[0].Id);
            Assert.AreEqual("Steve", data[0].Name);
        }

        [TestMethod]
        public void TestGetById()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new AccountsController(context);

            // act
            var okResult = controller.Get(1) as OkObjectResult;
            var data = (okResult.Value as Account);

            // assert
            Assert.IsNotNull(data);
            Assert.AreEqual(1, data.Id);
            Assert.AreEqual("Steve", data.Name);
        }

        [TestMethod]
        public void TestAdd()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new AccountsController(context);

            var account = new Account()
            {
                Id = 4,
                Name = "Dan",
            };

            // act
            var result = controller.Post(account);
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as Account);

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.AreEqual("Dan", account.Name);
            Assert.AreEqual(4, account.Id);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new AccountsController(context);

            var account = new Account()
            {
                Id = 2,
                Name = "Dan2",
            };

            // act
            var result = controller.Put(2, account);
            var okResult = result as OkObjectResult;
            var data = (okResult.Value as Account);

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.AreEqual("Dan2", account.Name);
            Assert.AreEqual(2, account.Id);
        }

        [TestMethod]
        public void TestDelete()
        {
            // arrange
            var context = CreateDbContext();
            var controller = new AccountsController(context);

            // act
            var result = controller.Delete(2);

            var okResult = result as OkObjectResult;
            var data = (okResult.Value as Account);

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(data);
            Assert.AreEqual("George", data.Name);
            Assert.AreEqual(2, data.Id);

            Assert.IsTrue(!context.Accounts.Any(x => x.Id == 2));
        }

    }
}
