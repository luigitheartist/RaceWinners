using System;
using System.Threading.Tasks;

namespace RaceWinners;

/// <summary>
/// The starting point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// The first method that runs when the program starts.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>Main</c> is marked <c>async Task</c> so that it can <c>await</c> other async
    /// methods, such as <see cref="DataService.GetGroupRanksAsync"/>.
    /// </para>
    /// <para>
    /// Notice that <c>Main</c> does not know <i>where</i> the race data comes from. It asks
    /// its dependency, the <see cref="DataService"/>, for the data and then works with
    /// whatever comes back.
    /// </para>
    /// </remarks>
    /// <param name="args">Command-line arguments (not used by this program).</param>
    static async Task Main(string[] args)
    {
        // Create the service this program depends on.
        DataService dataService = new DataService();

        // Ask the service for the data. "await" pauses here until the data is ready.
        var groups = await dataService.GetGroupRanksAsync();

        // Print each group and its runners' overall finishing places.
        foreach (var group in groups)
        {
            // string.Join glues the numbers together with ", " between them.
            var ranks = string.Join(", ", group.Ranks);

            Console.WriteLine($"{group.Name} - [{ranks}]");
        }

        // YOUR TURN: Rank each group from first to last place.
        // Decide what "fair" means before you start writing code!
        
        
        // Set up variables to add up the top 7 students of each class
        int a = 0, b = 0, c = 0, d = 0;
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < 7; j++)
                {
                    a += groups[i].Ranks[j];
                }
            }

            if (i == 1)
            {
                for (int j = 0; j < 7; j++)
                {
                    b += groups[i].Ranks[j];
                }
            }

            if (i == 2)
            {
                for (int j = 0; j < 7; j++)
                {
                    c += groups[i].Ranks[j];
                }
            }

            if (i == 3)
            {
                for (int j = 0; j < 7; j++)
                {
                    d += groups[i].Ranks[j];
                }
            }
        }

        // Set up final and "positioning" arrays and sort values by least to greatest, then do the same for the class letters
        
        int[] rankVal = { a, b, c, d };
        int[] itemp = { a, b, c, d };
        string[] classes = { "Class A", "Class B", "Class C", "Class D" };
        rankVal.Sort();
        string[] classRanking = { "a", "b", "c", "d" };
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (itemp[i] == rankVal[j])
                    classRanking[i] = classes[j];
            }
            
        }
        // Print formatted ranking list
        Console.WriteLine("\n\n      - CLASS RANKINGS - ");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"P{i+1}: {classRanking[i]} ({rankVal[i]} pts for top 7)");
        }
        
        
        
           




    }
}
