using System;
using System.Collections.Generic;

namespace TDDSample.Web.Models.Rentals
{
    public sealed class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        /**
         * レンタル金額を円で返す。
         */
        public string Statement()
        {
            return $"{RentalFee():N0} 円";
        }

        public string RentalFee()
        {
            var 料金 = 0M;

            foreach (var item in _rentals)
            {
                switch (item.Movie.RentalType)
                {
                    case MovieRentalType.Children:
                        break;
                    case MovieRentalType.Regular:
                        料金 += GetRentalFee普通(item);
                        break;
                    case MovieRentalType.NewRelease:
                        料金 += GetRentalFee新作(item);
                        break;
                    default:
                        break;
                }
            }

            return 料金.ToString();
        }

        private decimal GetRentalFee新作(Rental item)
        {
            var 料金 = item.DaysRented * 300M;
            return 料金;
        }

        private decimal GetRentalFee普通(Rental item)
        {
            var 料金 = 200M;
            if (item.DaysRented <= 2)
            {
                return 料金;
            }
            else
            {
                return (item.DaysRented - 2) * 200M;
            }

            throw new InvalidOperationException();
        }
    }
}