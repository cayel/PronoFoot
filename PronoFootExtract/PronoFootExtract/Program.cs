using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PronoFootExtract
{
    class Program
    {
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new System.Net.WebClient())
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("Loading fixtures : " + elapsedMs + " ms");
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
        private static bool teamMatch(Fixture match, string teamUrl)
        {
            return ((match._links.homeTeam.href == teamUrl) || (match._links.awayTeam.href == teamUrl));
        }
        static void Main(string[] args)
        {
            var url = "http://api.football-data.org/v1/competitions/450/fixtures";
            var fixturesL1 = _download_serialized_json_data<Fixtures>(url);
            foreach (Fixture match in fixturesL1.fixtures)
            {
                if ((match.result.goalsAwayTeam.HasValue) && teamMatch(match, "http://api.football-data.org/v1/teams/523"))
                {
                    System.Console.WriteLine(match.homeTeamName + " - " + match.awayTeamName+ " : " + match.result.goalsHomeTeam+"-"+ match.result.goalsAwayTeam);
                }                
            }
            Console.Write(fixturesL1.fixtures.Count());
            Console.ReadKey();
        }
    }
}
