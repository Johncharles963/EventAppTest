namespace CourseraEventApp.Services;

public sealed class AttendanceTracker
{
    private readonly object _gate = new();
    private readonly HashSet<(Guid SessionId, int EventId)> _registrations = [];
    private readonly Dictionary<int, int> _attendanceByEvent = [];

    public bool TryRegister(Guid sessionId, int eventId, out int attendanceCount)
    {
        if (sessionId == Guid.Empty)
        {
            throw new ArgumentException("A valid attendee session is required.", nameof(sessionId));
        }

        if (eventId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(eventId), "Event ID must be positive.");
        }

        lock (_gate)
        {
            if (!_registrations.Add((sessionId, eventId)))
            {
                attendanceCount = _attendanceByEvent[eventId];
                return false;
            }

            attendanceCount = _attendanceByEvent.TryGetValue(eventId, out var currentCount)
                ? currentCount + 1
                : 1;
            _attendanceByEvent[eventId] = attendanceCount;
            return true;
        }
    }

    public int GetAttendanceCount(int eventId)
    {
        lock (_gate)
        {
            return _attendanceByEvent.TryGetValue(eventId, out var count) ? count : 0;
        }
    }
}
