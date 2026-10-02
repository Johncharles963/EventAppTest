using CourseraEventApp.Models;

namespace CourseraEventApp.Data;

public static class EventCatalog
{
    public static IReadOnlyList<Event> All { get; } =
    [
        new Event(
            1,
            "Future of Work Summit",
            new DateTime(2026, 11, 12),
            "The Glasshouse, New York",
            "Conference",
            "A day of bold ideas and practical conversations about how teams, workplaces, and technology are changing."),
        new Event(
            2,
            "Designing Tomorrow",
            new DateTime(2026, 11, 19),
            "The Foundry, Chicago",
            "Workshop",
            "Join creative leaders for hands-on sessions that turn emerging trends into thoughtful, human-centered design."),
        new Event(
            3,
            "Winter Lights Gala",
            new DateTime(2026, 12, 5),
            "The Conservatory, San Francisco",
            "Gala",
            "An evening of seasonal dining, live music, and good company in a luminous garden setting."),
        new Event(
            4,
            "Founders & Friends",
            new DateTime(2027, 1, 21),
            "The Hoxton, Austin",
            "Networking",
            "A relaxed evening for founders, makers, and curious minds to make meaningful connections.")
    ];

    public static Event? FindById(int id) => All.FirstOrDefault(eventItem => eventItem.Id == id);
}
