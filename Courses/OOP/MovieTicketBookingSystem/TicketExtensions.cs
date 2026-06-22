using System.Text;

namespace MovieTicketBookingSystem;

/*
 3. Useful Utilities Without Modifying Existing Classes — The team needs to add some handy features to the 
 existing Ticket types without touching their source code. For example: a method to generate a formatted receipt 
 string from any ticket, and a method that takes an array of tickets and returns the total revenue. These should 
 feel like they belong to the Ticket class when you call them, even though they are defined elsewhere.
 */
public static class TicketExtensions
{
    extension(Ticket value)
    {
        public string GenerateReceipt()
        {
            StringBuilder receiptInfo = new StringBuilder();
            
            receiptInfo.Append("========== RECEIPT ==========\n");
            receiptInfo.Append($" Movie    : {value.MovieName}\n");
            receiptInfo.Append($" Type     : {value.Type}\n");
            receiptInfo.Append($" Price    : {value.Price}\n");
            receiptInfo.Append($" Final    : {value.PriceAfterTax}\n");
            receiptInfo.Append($" Status   : {value.TicketStatus}\n");
            receiptInfo.Append("=============================\n");
            
            return receiptInfo.ToString();
        }

        public decimal CalculateTotalValue(Ticket[] arrayOfTickets)
        {
            decimal sum = 0;
            for (int i = 0; i < arrayOfTickets.Length; i++)
            {
                sum += arrayOfTickets[i].Price;
            }

            return sum;
        }
    }
}