using System.ServiceModel;

namespace Models
{
    [ServiceContract]
    interface ITimeConverter
    {
        [OperationContract]
        public Time createTimeObject(string airportCode);

        [OperationContract]
        public string timeDifference(string departureCode, string arrivalCode);
    }
}