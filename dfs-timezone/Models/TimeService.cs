namespace Models
{
    public class TimeService : ITimeConverter
    {

        public Time createTimeObject(string airportCode)
        {
            return new Time(airportCode);
        }

        public Double timeDifference(string departureCode, string arrivalCode) {
            Time timeDeparture = new Time(departureCode);
            Time timeArrival = new Time(arrivalCode);

            var dateNow = DateTime.Now;
            DateTime startTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeDeparture.Hour, timeDeparture.Minutes, timeDeparture.Seconds);
            DateTime endTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeArrival.Hour, timeArrival.Minutes, timeArrival.Seconds);

            TimeSpan duration = startTime - endTime;

            return duration.TotalMinutes;
        }
    }
}