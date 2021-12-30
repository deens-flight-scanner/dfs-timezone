using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using MySql.Data.MySqlClient;

namespace Models
{

    public class TimeZone
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("abbr")]
        public string Abbr { get; set; }
        [JsonProperty("offset")]
        public double Offset { get; set; }
        [JsonProperty("isdst")]
        public bool Isdst { get; set; }
        [JsonProperty("utc")]
        public string[] Utc { get; set; }
    }

    [DataContract]
    public class Time
    {
        [DataMember]
        public int Hour { get; set; }
        [DataMember]
        public int Minutes { get; set; }
        [DataMember]
        public int Seconds { get; set; }
        [DataMember]
        public double UtcOffset { get; set; }
        

        public Time(string airportCode)
        {
            // string tzIana = TimeZoneLookup.GetTimeZone(lat, lon).Result;
            string connStr = @"datasource=us-cdbr-east-05.cleardb.net;database=heroku_7958580bc9bdd70;username=b68cef34044509;password=ac42c229";
            MySqlConnection conn = new MySqlConnection(connStr);
            string iana = "";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT code, tz FROM airports WHERE code='" + airportCode + "'";
                Console.WriteLine(sql);
                // string sql = "SELECT code, tz FROM airports";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    iana = rdr[1]+"";
                    Console.WriteLine(iana);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

            var jsonText = File.ReadAllText("./timezones.json");
            var timeZones = JsonConvert.DeserializeObject<IList<TimeZone>>(jsonText);

            double utcOffset = 0;
            foreach (TimeZone timeZone in timeZones)
            {
                string[] UTCs = timeZone.Utc;
                foreach (string utc in UTCs) {
                    if (utc == iana) {
                        utcOffset = timeZone.Offset;
                    }
                }
            }

            int hourOffset = (int) utcOffset;
            double minOffset = utcOffset - hourOffset;
            
            TimeSpan timeZoneDifference = new TimeSpan(hourOffset, (int)minOffset*60, 00);

            DateTime timeUTC = DateTime.UtcNow;
            DateTime localTime = timeUTC.Add(timeZoneDifference);

            int hourUTC = localTime.Hour;
            this.Hour = hourUTC;
            int minUTC = localTime.Minute;
            this.Minutes = minUTC;
            int secUTC = localTime.Second;
            this.Seconds = secUTC;
            this.UtcOffset = utcOffset;
        }
    }
}