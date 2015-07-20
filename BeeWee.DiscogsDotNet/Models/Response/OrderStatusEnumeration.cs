

namespace BeeWee.DiscogsDotNet.Models
{
    public enum OrderStatusEnumeration
    {
        All,
        New_Order,
        Buyer_Contacted,
        Invoice_Sent,
        Payment_Pending,
        Payment_Received,
        Shipped,
        Merged,
        Order_Changed,
        Refund_Sent,
        Cancelled,
        /*
        Cancelled_(Non-Paying_Buyer),
        Cancelled_(Item_Unavailable),
        Cancelled_(Per_Buyer's_Request),
        Cancelled_(Refund_Received)
        */
    }
}