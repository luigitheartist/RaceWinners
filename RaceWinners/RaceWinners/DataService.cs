using System.Collections.Generic;
using System.Threading.Tasks;
using RaceWinners.Models;

namespace RaceWinners;

/// <summary>
/// A <b>service</b> that supplies the race results to the rest of the program.
/// </summary>
/// <remarks>
/// <para>
/// A service is a class that does one focused job for other parts of a program. This
/// service's only job is to <i>get the data</i>. It does not print anything, and it does
/// not decide who wins — that is somebody else's job.
/// </para>
/// <para>
/// Any class that uses this service is said to <b>depend</b> on it, so the service is
/// called a <b>dependency</b>. Keeping data loading in its own class means that later we
/// could load the results from a file, a database, or a website by changing <i>only</i>
/// this class. The code that uses the data would not need to change at all.
/// </para>
/// </remarks>
public class DataService
{
    /// <summary>
    /// Gets the race results for every group.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method is <c>async</c>, which means it can wait for slow work (like a network
    /// download) without freezing the program. By convention, async method names end in
    /// <c>Async</c>.
    /// </para>
    /// <para>
    /// It returns a <see cref="Task{TResult}"/> — a "promise" that a
    /// <see cref="List{T}"/> of <see cref="Group"/> objects will be ready later.
    /// Callers use the <c>await</c> keyword to wait for that list.
    /// </para>
    /// </remarks>
    /// <returns>A list with one <see cref="Group"/> for each class that ran the race.</returns>
    public async Task<List<Group>> GetGroupRanksAsync()
    {
        // Pretend we are downloading this data over a network.
        // Task.Delay waits for 1000 milliseconds (1 second) without blocking the program.
        await Task.Delay(1000);

        // Build the list using a "collection expression": the square brackets [ ... ]
        // create a new list and fill it with the items inside, all in one step.
        // Each Group is created with an "object initializer" { Name = ..., Ranks = ... }
        // that sets its properties right away.
        List<Group> groups =
        [
            new Group { Name = "Class A", Ranks = [4, 9, 11, 12, 20, 21, 25, 26, 29, 35, 43, 45, 49, 54, 61, 65, 69, 70, 71] },
            new Group { Name = "Class B", Ranks = [6, 7, 10, 13, 16, 22, 24, 27, 34, 39, 40, 42, 48, 52, 53, 62, 66, 72] },
            new Group { Name = "Class C", Ranks = [1, 3, 14, 18, 19, 23, 28, 30, 32, 41, 44, 47, 50, 56, 60, 63, 64, 68, 73, 74] },
            new Group { Name = "Class D", Ranks = [2, 5, 8, 15, 17, 31, 33, 36, 37, 38, 46, 51, 55, 57, 58, 59, 67] }
        ];

        return groups;
    }
}
