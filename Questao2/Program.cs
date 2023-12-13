using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;


public class Program
{
    public  static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals =  getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        string nomeTime = team;
        int ano = year;
        int totalGoals = 0;
        int paginaAtual = 1;
        int totalPages = 1;

        do
        {
            string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={ano}&team1={nomeTime}&page={paginaAtual}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(responseBody);

                foreach (JToken match in json["data"])
                {
                    int goals = int.Parse(match["team1goals"].ToString());
                    totalGoals += goals;
                }

                int.TryParse(json["total_pages"].ToString(), out totalPages);
                paginaAtual++;
            }
        } while (paginaAtual <= totalPages);

        Console.WriteLine($"Team {nomeTime} scored {totalGoals} goals in {ano}");

        return totalGoals;

    }

    public class Match
    {
        [JsonPropertyName("year")]
        public int year { get; set; }

        [JsonPropertyName("team1")]
        public string teamName1 { get; set; }

        [JsonPropertyName("team2")]
        public string teamName2 { get; set; }

        [JsonPropertyName("page")]
        public int page { get; set; }



    }
}