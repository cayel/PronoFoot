using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PronoFootExtract
{
    class Link
    {
        public string href { get; set; }
    }
    class Links
    {
        public Link self { get; set; }
        public Link competition { get; set; }
    }
    class LinksFixture
    {
        public Link self { get; set; }
        public Link competition { get; set; }
        public Link homeTeam { get; set; }
        public Link awayTeam { get; set; }

    }
    class HalfTimeResultFixture
    {
        public int goalsHomeTeam { get; set; }
        public int goalsAwayTeam { get; set; }
    }
    class ResultFixture
    {
        public int? goalsHomeTeam { get; set; }
        public int? goalsAwayTeam { get; set; }
        public HalfTimeResultFixture halfTime { get; set; }

    }
    class Fixture
    {
        public LinksFixture _links { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public int matchday { get; set; }
        public string homeTeamName { get; set; }
        public string awayTeamName { get; set; }
        public ResultFixture result { get; set; }
    }
    class Fixtures
    {
        public Links _links { get; set; }
        public int count { get; set; }
        public Fixture[] fixtures { get; set; }
    }
}
