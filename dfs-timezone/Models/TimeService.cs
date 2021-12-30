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
            Time timeArrival = new Time(arrivalCode);;

            return timeArrival.UtcOffset - timeDeparture.UtcOffset;
        }
    }
}