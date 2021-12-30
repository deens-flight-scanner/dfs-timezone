namespace Models
{
    public class TimeService : ITimeConverter
    {

        public Time createTimeObject(string airportCode)
        {
            return new Time(airportCode);
        }

        public TimeSpan timeDifference(string departureCode, string arrivalCode) {
            Time timeDeparture = new Time(departureCode);
            Time timeArrival = new Time(arrivalCode);

            string startTime = timeDeparture.Hour + ":" + timeDeparture.Minutes;
            string endTime = timeArrival.Hour + ":" + timeArrival.Minutes;

            DateTime startDate = DateTime.Parse(startTime);
            DateTime endDate = DateTime.Parse(endTime);

            TimeSpan TS = startDate - endDate;

            // var dateNow = DateTime.Now;
            // DateTime startTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeDeparture.Hour, timeDeparture.Minutes, timeDeparture.Seconds);
            // DateTime endTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeArrival.Hour, timeArrival.Minutes, timeArrival.Seconds);

            // TimeSpan duration = endTime.Subtract(startTime);

            return TS;
        }
    }
}