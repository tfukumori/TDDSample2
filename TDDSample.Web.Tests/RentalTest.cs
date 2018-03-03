using System;
using Xunit;
using TDDSample.Web.Models.Rentals;

namespace TDDSample.Web.Tests
{
    public class RentalTest
    {
        private readonly Movie _movieNewRelease;
        private readonly Movie _movieRegular;
        private readonly Customer _customer;

        public RentalTest()
        {
            _movieNewRelease = new Movie("スターウォーズ", MovieRentalType.NewRelease);
            _customer = new Customer("太郎");
            _movieRegular = new Movie("ドラえもん", MovieRentalType.Regular);
        }

        [Fact]
        public void 新作を一泊したら300円()
        {
            _customer.AddRental(new Rental(_movieNewRelease, 1));

            var result = _customer.Statement();

            Assert.Equal("300 円", result);
        }

        [Fact]
        public void 新作を三泊したら900円()
        {
            _customer.AddRental(new Rental(_movieNewRelease, 3));

            var result = _customer.RentalFee();

            Assert.Equal("900", result);
        }

        [Fact]
        public void 新作を四泊したら1200円カンマが入る()
        {
            _customer.AddRental(new Rental(_movieNewRelease, 4));

            var result = _customer.Statement();

            Assert.Equal("1200 円", result);
        }

        [Fact]
        public void 普通を二泊借りたら200円()
        {
            _customer.AddRental(new Rental(_movieRegular, 2));

            var result = _customer.Statement();

            Assert.Equal("200 円", result);
        }

        [Fact]
        public void 新作一泊普通を一泊借りたら500円パターン1()
        {
            _customer.AddRental(new Rental(_movieRegular, 1));
            _customer.AddRental(new Rental(_movieNewRelease, 1));

            var result = _customer.Statement();

            Assert.Equal("500 円", result);
        }

        [Fact]
        public void 新作一泊普通を一泊借りたら500円パターン2()
        {
            _customer.AddRental(new Rental(_movieNewRelease, 1));
            _customer.AddRental(new Rental(_movieRegular, 1));

            var result = _customer.Statement();

            Assert.Equal("500 円", result);
        }

        [Fact]
        public void 新作一泊普通を二泊借りたら500円パターン1()
        {
            _customer.AddRental(new Rental(_movieRegular, 2));
            _customer.AddRental(new Rental(_movieNewRelease, 1));

            var result = _customer.Statement();

            Assert.Equal("500 円", result);
        }

        [Fact]
        public void 新作一泊普通を二泊借りたら500円パターン2()
        {
            _customer.AddRental(new Rental(_movieNewRelease, 1));
            _customer.AddRental(new Rental(_movieRegular, 2));

            var result = _customer.Statement();

            Assert.Equal("500 円", result);
        }

        [Fact]
        public void 新作一泊普通を三泊借りたら600円()
        {
            _customer.AddRental(new Rental(_movieNewRelease, 1));
            _customer.AddRental(new Rental(_movieRegular, 3));

            var result = _customer.Statement();

            Assert.Equal("700 円", result);
        }
    }
}