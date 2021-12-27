using System.ServiceModel;

namespace Models
{
    [ServiceContract]
    interface ITimeConverter
    {
        [OperationContract]
        public Time createTimeObject(string airportCode);

        [OperationContract]
        public Double timeDifference(string departureCode, string arrivalCode);
    }
}