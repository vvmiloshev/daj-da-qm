using System.Text;
using VSP__559ir_MyProject.Data;

namespace VSP__559ir_MyProject.Views
{
    /// <summary>
    /// Tab view that renders a printable preview of a saved order.
    /// Provides both a rich-text render for UI and a plain text builder for other uses.
    /// </summary>
    public partial class NewOrderPreviewTabView : UserControl
    {
        private readonly OrderRepository _orderRepo = new OrderRepository();
        private long? _orderId;

        public NewOrderPreviewTabView()
        {
            InitializeComponent();

            // Ensure RichTextBox behaves like a read-only receipt viewer
            rtbPreview.ReadOnly = true;
            rtbPreview.DetectUrls = false;
            rtbPreview.HideSelection = true;
        }

        /// <summary>
        /// Sets the id of the order to preview.
        /// Call RefreshPreview after setting to update the UI.
        /// </summary>
        public void SetOrderId(long orderId)
        {
            _orderId = orderId;
        }

        /// <summary>
        /// Fetches receipt data for the configured order and updates the preview.
        /// Shows a user-friendly message if no order is available.
        /// </summary>
        public void RefreshPreview()
        {
            if (_orderId == null)
            {
                SetPlain("No saved order to preview.");
                return;
            }

            var data = _orderRepo.GetReceiptData(_orderId.Value);
            if (data == null)
            {
                SetPlain("Order not found.");
                return;
            }

            RenderReceiptRich(data);
        }

        /// <summary>
        /// Renders the receipt using the RichTextBox with basic styling (bold headings).
        /// Keeps rendering logic simple and non-destructive to selection.
        /// </summary>
        private void RenderReceiptRich(ReceiptData d)
        {
            rtbPreview.SuspendLayout();

            rtbPreview.Clear();

            var normal = new Font(rtbPreview.Font, FontStyle.Regular);
            var bold = new Font(rtbPreview.Font, FontStyle.Bold);

            AppendLine("DAJ DA YAM", bold);
            AppendLine("Order receipt", normal);

            AppendLine(new string('-', 32), normal);
            AppendLine($"Order ID: {d.OrderId}", normal);
            AppendLine($"Created: {d.CreatedAt}", normal);
            AppendLine($"Status: {d.StatusText}", normal);
            AppendLine($"Deliver at: {d.DeliverAt}", normal);
            AppendLine(new string('-', 32), normal);

            AppendLine("Customer", bold);
            AppendLine(d.CustomerName, normal);
            AppendLine(d.CustomerPhone, normal);
            AppendLine(d.DeliveryAddress, normal);
            AppendLine(new string('-', 32), normal);

            AppendLine("Items", bold);

            decimal total = 0m;
            foreach (var it in d.Items)
            {
                var lineTotal = it.UnitPriceEur * it.Qty;
                total += lineTotal;

                AppendLine(it.ProductName, normal);
                AppendLine($"  {it.Qty} x {it.UnitPriceEur:0.00} EUR = {lineTotal:0.00} EUR", normal);
            }

            AppendLine(new string('-', 32), normal);
            AppendLine($"TOTAL: {total:0.00} EUR", bold);
            AppendLine(new string('-', 32), normal);

            AppendLine("Courier", bold);
            AppendLine(d.CourierName, normal);

            // Reset selection so text is not highlighted
            rtbPreview.SelectionStart = 0;
            rtbPreview.SelectionLength = 0;

            rtbPreview.ResumeLayout();
        }

        /// <summary>
        /// Appends a line to the rich text box using the provided font.
        /// Encapsulates selection font manipulation into a single helper.
        /// </summary>
        private void AppendLine(string text, Font font)
        {
            rtbPreview.SelectionFont = font;
            rtbPreview.AppendText(text + Environment.NewLine);
        }

        /// <summary>
        /// Convenience method to show a plain single-line message in the preview.
        /// </summary>
        private void SetPlain(string text)
        {
            rtbPreview.Clear();
            rtbPreview.SelectionFont = new Font(rtbPreview.Font, FontStyle.Regular);
            rtbPreview.AppendText(text);
        }

        /// <summary>
        /// Builds a plain-text version of the receipt and returns it as a string.
        /// Useful for printing or copy/paste scenarios where RTF is not desired.
        /// </summary>
        private static string BuildReceipt(ReceiptData d)
        {
           
            var sb = new StringBuilder();

            sb.AppendLine("DAJ DA YAM");
            sb.AppendLine("Order receipt");
            sb.AppendLine(new string('-', 32));
            sb.AppendLine($"Order ID: {d.OrderId}");
            sb.AppendLine($"Created: {d.CreatedAt}");
            sb.AppendLine($"Status: {d.StatusText}");
            sb.AppendLine($"Deliver at: {d.DeliverAt}");
            sb.AppendLine(new string('-', 32));

            sb.AppendLine("Customer");
            sb.AppendLine(d.CustomerName);
            sb.AppendLine(d.CustomerPhone);
            sb.AppendLine(d.DeliveryAddress);
            sb.AppendLine(new string('-', 32));

            sb.AppendLine("Items");

            decimal total = 0m;
            foreach (var it in d.Items)
            {
                var lineTotal = it.UnitPriceEur * it.Qty;
                total += lineTotal;

                sb.AppendLine(it.ProductName);
                sb.AppendLine($"  {it.Qty} x {it.UnitPriceEur:0.00} EUR = {lineTotal:0.00} EUR");
            }

            sb.AppendLine(new string('-', 32));
            sb.AppendLine($"TOTAL: {total:0.00} EUR");
            sb.AppendLine(new string('-', 32));

            sb.AppendLine("Courier");
            sb.AppendLine(d.CourierName);

            return sb.ToString();
        }
    }
}
