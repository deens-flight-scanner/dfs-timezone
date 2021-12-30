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

            string depTime = timeDeparture.Hour + ":" + timeDeparture.Minutes;
            DateTime startTime = Convert.ToDateTime(depTime);
            string ArrTime = timeDeparture.Hour + ":" + timeDeparture.Minutes;
            DateTime endTime = Convert.ToDateTime(ArrTime);

            TimeSpan duration = startTime - endTime;

            return duration.TotalMinutes;
        }
    }
}