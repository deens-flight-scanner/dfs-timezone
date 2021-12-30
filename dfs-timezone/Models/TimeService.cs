namespace Models
{
    public class TimeService : ITimeConverter
    {

        public Time createTimeObject(string airportCode)
        {
            return new Time(airportCode);
        }

        public string timeDifference(string departureCode, string arrivalCode) {
            Time timeDeparture = new Time(departureCode);
            Time timeArrival = new Time(arrivalCode);

            string startTime = timeDeparture.Hour + ":" + timeDeparture.Minutes;
            string endTime = timeArrival.Hour + ":" + timeArrival.Minutes;

            TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

            // var dateNow = DateTime.Now;
            // DateTime startTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeDeparture.Hour, timeDeparture.Minutes, timeDeparture.Seconds);
            // DateTime endTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeArrival.Hour, timeArrival.Minutes, timeArrival.Seconds);

            // TimeSpan duration = endTime.Subtract(startTime);

            return duration.ToString(@"hh\:mm");
        }
    }
}