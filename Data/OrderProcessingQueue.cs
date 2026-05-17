using System.Linq;
using SDA_559ir.Models;

namespace SDA_559ir.Data
{
    internal sealed class OrderProcessingQueue
    {
        private readonly Queue<OrderListRow> _queue = new Queue<OrderListRow>();

        public int Count => _queue.Count;

        public void Rebuild(IEnumerable<OrderListRow> newOrders)
        {
            _queue.Clear();

            foreach (var order in newOrders.OrderBy(GetQueueSortKey).ThenBy(o => o.OrderId))
                _queue.Enqueue(order);
        }

        public OrderListRow? PeekOrDefault()
        {
            return _queue.Count == 0 ? null : _queue.Peek();
        }

        public OrderListRow? DequeueOrDefault()
        {
            return _queue.Count == 0 ? null : _queue.Dequeue();
        }

        private static DateTime GetQueueSortKey(OrderListRow order)
        {
            return DateTime.TryParse(order.CreatedAt, out var createdAt)
                ? createdAt
                : DateTime.MinValue;
        }
    }
}
