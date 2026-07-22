// Exercise 5: Print Queue Simulator
namespace PrintQueueSimulator;

class Program
{
    // Simulate a printer queue 
    static void Main(string[] args)
    {
        
        // Create a Queue<string>
        Queue<string> printerQueue = [];
        
        // and enqueue 5 documents: "Report.pdf", "Invoice.pdf", "Letter.docx", "Resume.pdf", "Photo.jpg"
        printerQueue.Enqueue("Report.pdf");
        printerQueue.Enqueue("Invoice.pdf");
        printerQueue.Enqueue("Letter.docx");
        printerQueue.Enqueue("Resume.pdf");
        printerQueue.Enqueue("Photo.jpg");
        
        // 1. Print the queue contents and Count
        foreach (var itemToPrint in printerQueue)
            Console.WriteLine(itemToPrint);
        
        Console.WriteLine();
        
        Console.WriteLine($"Count of Printer Queue: {printerQueue.Count}");

        // 2. Use Peek to see which document will print next (without removing)
        Console.WriteLine();
        Console.WriteLine($"Peeking the Printer Queue: {printerQueue.Peek()}");
        
        // 3. Process the queue: Dequeue each document and print "Printing: [name]"
        while (printerQueue.Count > 0)
        {
            var dequeuedItem = printerQueue.Dequeue();
            Console.WriteLine($"Printing: {dequeuedItem}");
        }
        
        // 4. Try TryDequeue on the now-empty queue — what happens?
        Console.WriteLine();

        bool canEmptyQueueBeDequeued = printerQueue.TryDequeue(out string? dequeudItem);
        Console.WriteLine($"Can empty queue be Dequeued? {(canEmptyQueueBeDequeued ? "Yes" : "No")}");
        // It outputs: "Can empty queue be Dequeued? No" because that an empty queue cannot be dequeued.
        //  But the advantage is that it will not throw an error because it returns `true` if there's an item in
        //   the queue and this item can be dequeued or `false` if there's no item in the queue then it means that
        //   we cannot dequeue the queue because it has no items.
    }
}