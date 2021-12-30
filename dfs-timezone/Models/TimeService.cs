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

            TimeSpan t1 = TimeSpan.Parse(startTime);
            TimeSpan t2 = TimeSpan.Parse(endTime);
            double _24h = (new TimeSpan(24, 0, 0)).TotalMilliseconds;
            double diff = t2.TotalMilliseconds - t1.TotalMilliseconds;
            if (diff < 0) diff += _24h;
            Console.WriteLine(TimeSpan.FromMilliseconds(diff)); // output: 04:10:00

            // var dateNow = DateTime.Now;
            // DateTime startTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeDeparture.Hour, timeDeparture.Minutes, timeDeparture.Seconds);
            // DateTime endTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, timeArrival.Hour, timeArrival.Minutes, timeArrival.Seconds);

            // TimeSpan duration = endTime.Subtract(startTime);

            return diff.ToString(@"hh\:mm");
        }
    }
}