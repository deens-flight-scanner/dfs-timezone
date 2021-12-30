using System.ServiceModel;

namespace Models
{
    [ServiceContract]
    interface ITimeConverter
    {
        [OperationContract]
        public Time createTimeObject(string airportCode);

        [OperationContract]
        public TimeSpan timeDifference(string departureCode, string arrivalCode);
    }
}