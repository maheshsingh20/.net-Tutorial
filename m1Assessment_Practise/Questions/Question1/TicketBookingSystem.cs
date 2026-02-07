namespace m1Assessment_Practise.Questions.Question1;

class TicketBookingSystem
{
    private readonly Dictionary<int, Seat> _seats = new();
    private readonly object _lock = new();

    public TicketBookingSystem(int totalSeats)
    {
        for (int i = 1; i <= totalSeats; i++)
        {
            _seats[i] = new Seat { SeatNo = i, IsBooked = false };
        }
    }

    public bool BookSeat(int seatNo, string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("UserId cannot be empty");

        lock (_lock)
        {
            if (!_seats.ContainsKey(seatNo))
                return false;

            var seat = _seats[seatNo];
            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            seat.BookedBy = userId;
            return true;
        }
    }

    public void DisplaySeats()
    {
        lock (_lock)
        {
            foreach (var seat in _seats.Values)
            {
                Console.WriteLine($"Seat {seat.SeatNo}: {(seat.IsBooked ? $"Booked by {seat.BookedBy}" : "Available")}");
            }
        }
    }
}
