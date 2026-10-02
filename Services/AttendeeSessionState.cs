namespace CourseraEventApp.Services;

public sealed class AttendeeSessionState
{
    private readonly HashSet<int> _registeredEventIds = [];

    public Guid SessionId { get; } = Guid.NewGuid();
    public string? FullName { get; private set; }
    public string? Email { get; private set; }
    public IReadOnlyCollection<int> RegisteredEventIds => _registeredEventIds;

    public bool HasRegisteredFor(int eventId) => _registeredEventIds.Contains(eventId);

    public void RememberRegistration(string fullName, string email, int eventId)
    {
        FullName = fullName;
        Email = email;
        _registeredEventIds.Add(eventId);
    }
}
