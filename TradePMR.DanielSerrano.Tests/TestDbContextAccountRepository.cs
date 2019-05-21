using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TradePMR.DanielSerrano.Common;
using TradePMR.DanielSerrano.Data;
using TradePMR.DanielSerrano.Data.Interfaces;
using TradePMR.DanielSerrano.Data.Models;
using TradePMR.DanielSerrano.Data.Repositories;

namespace TradePMR.DanielSerrano.Tests
{
    [TestClass]
    public class TestDbContextAccountRepository
    {
        private TradePMRDbContext CreateDbContext(string name = null)
        {
            if(name == null)
            {
                name = Guid.NewGuid().ToString();
            }
            DbContextOptions<TradePMRDbContext> options = new DbContextOptionsBuilder<TradePMRDbContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TradePMR;Integrated Security=True;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .EnableSensitiveDataLogging()
                .Options;
            var db = new TradePMRDbContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        [TestMethod]
        public void TestAccountGetAll()
        {
            // arrange
            IAccountRepository repo = new AccountRepository(CreateDbContext());

            // act
            var result = repo.GetAll().ToArray();

            // assert
            Assert.AreEqual(1, result[0].Id);
        }

        [TestMethod]
        public void TestAccountQueryByName()
        {
            // arrange
            IAccountRepository repo = new AccountRepository(CreateDbContext());

            // act
            var result = repo.Query(new AccountQueryParameter() { Name = "Steve" }).ToArray();

            // assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(1, result[0].Id);
        }

        [TestMethod]
        public void TestAccountQueryByName_Skip0Take1()
        {
            // arrange
            IAccountRepository repo = new AccountRepository(CreateDbContext());

            // act
            var result = repo.Query(new AccountQueryParameter() {
                Name = "Steve",
                Skip = 0,
                Take = 1
            }).ToArray();

            // assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(1, result[0].Id);
        }

        [TestMethod]
        public void TestAccount_Add()
        {
            // arrange
            IAccountRepository repo = new AccountRepository(CreateDbContext());

            var account = new Account()
            {
                Id = 0,
                Name = "Dan"
            };

            // act
            var result = repo.Add(account);

            // assert
            Assert.AreEqual(3, account.Id);
        }

        [TestMethod]
        public void TestAccount_Update()
        {
            // arrange
            IAccountRepository repo = new AccountRepository(CreateDbContext());

            // act
            var account = repo.GetById(1);
            account.Name = "Dan2";
            account = repo.Update(account);

            // assert
            Assert.AreEqual(1, account.Id);
            Assert.AreEqual("Dan2", account.Name);
        }

        [TestMethod]
        public void TestAccount_Delete()
        {
            // arrange
            IAccountRepository repo = new AccountRepository(CreateDbContext());

            // act
            var account = repo.Delete(1);
            var accounts = repo.GetAll();

            // assert
            Assert.AreEqual(1, account.Id);
            Assert.AreEqual(1, accounts.Count());
        }
    }
}
