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
            
            TimeSpan tsDeparture = new TimeSpan(timeDeparture.Hour, timeDeparture.Minutes, timeDeparture.Seconds);
            Console.WriteLine(timeDeparture.Hour);
            Console.WriteLine(timeDeparture.Minutes);
            Console.WriteLine(timeDeparture.Seconds);
            
            TimeSpan tsArrival = new TimeSpan(timeArrival.Hour, timeArrival.Minutes, timeArrival.Seconds);
            Console.WriteLine(timeArrival.Hour);
            Console.WriteLine(timeArrival.Minutes);
            Console.WriteLine(timeArrival.Seconds);

            double timeDifference = (tsDeparture - tsArrival).TotalMinutes;

            return timeDifference;
        }
    }
}