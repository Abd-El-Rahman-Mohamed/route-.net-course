// Exercise 2: Leaderboard
namespace Leaderboard;

class Program
{
    // Create a leaderboard that automatically sorts players by score.
    static void Main(string[] args)
    {
        // 1. Add: 500="Ahmed", 200="Sara", 800="Ali", 350="Mona"
        SortedList<int, string> leaderboard = new()
        {
            [500] = "Ahmed",
            [200] = "Sara",
            [800] = "Ali",
            [350] = "Mona"
        };
        
        // 2. Print all entries (they should be sorted by score automatically)
        Console.WriteLine("--- Leaderboard Entries ---");
        foreach (KeyValuePair<int, string> leaderboardItem in leaderboard)
            Console.WriteLine($"{{{leaderboardItem.Key}, {leaderboardItem.Value}}}");
        
        // 3. Access the first key and first value 
        int firstLeaderboardItemKey = leaderboard.Keys[0];
        string firstLeaderboardItemValue = leaderboard.Values[0];
        Console.WriteLine();
        Console.WriteLine($"First Leaderboard Item : {{{firstLeaderboardItemKey}, {firstLeaderboardItemValue}}}");

        int lastLeaderboardItemKey = leaderboard.Keys[^1];
        string lastLeaderboardItemValue = leaderboard.Values[^1];
        Console.WriteLine($"Last Leaderboard Item : {{{lastLeaderboardItemKey}, {lastLeaderboardItemValue}}}");
        
        // 4. Check if score 500 exists
        bool isThereScoreEquals500 = leaderboard.ContainsKey(500);
        Console.WriteLine();
        Console.WriteLine($"Is there Score equals 500? {isThereScoreEquals500}");
        
        // 5. Safely get the player with score 999
        bool isTherePlayerWithScore999 = leaderboard.TryGetValue(999, out string playerWithScore999);
        if (isTherePlayerWithScore999)
        {
            Console.WriteLine();
            Console.WriteLine($"Player with Score 999: {playerWithScore999}");
        }
        
        // 6. Remove the player with score 200 and print the updated list
        leaderboard.Remove(200);
        Console.WriteLine("");
        Console.WriteLine("--- The Updated List ---");
        foreach (KeyValuePair<int, string> leaderboardItem in leaderboard)
            Console.WriteLine($"{{{leaderboardItem.Key}, {leaderboardItem.Value}}}");
    }
}