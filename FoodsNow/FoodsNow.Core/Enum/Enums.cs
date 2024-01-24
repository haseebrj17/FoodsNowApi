namespace FoodsNow.Core.Enum
{
    public class Enums
    {
        public enum OrderStatus
        {
            OrderPlaced = 1,
            InProcess = 2,
            ReadyForDelivery = 3,
            Shipped = 4,
            Delivered = 5,
        }

        public enum UserRole
        {
            SuperAdmin = 1,
            Client = 2,
            FranchiseUser = 3,
            Customer = 4,
            FranchiseManager = 5,
            Team = 6
        }

        public enum Timings
        {
            Lunch = 1,
            Dinner = 2,
            LunchAndDinner = 3
        }

        public enum CategoryType
        {
            Brand = 1,
            SubCategory = 2,
            Category = 3
        }

        public enum PackageType
        {
            Basic = 1,
            Standard = 2,
            Premium = 3
        }

        public enum OrderType
        {
            Delivery = 1,
            PickUp = 2
        }

        public enum Status
        {
            Active = 1,
            InActive = 0
        }

        public enum DiscountType
        {
            Percentage = 1,
            FixedAmount = 2,
            BuyOneGetOne = 3,
            Seasonal = 4,
            Volume = 5,
            FirstTimeCustomer = 6,
            Loyalty = 7
        }
    }
}