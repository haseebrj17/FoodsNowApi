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
            FranchiseManager = 3,
            FranchiseUser = 3,
            Customer = 4
        }
    }
}
