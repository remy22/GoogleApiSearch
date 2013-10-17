using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleApiSearch;

namespace GoogleSearchTester
{
    class Program
    {
        static void Main(string[] args)
        {
            GoogleCustomSearch gcs = new GoogleCustomSearch();
            IList<Google.Apis.Customsearch.v1.Data.Result> results = null;

            //gcs.Search(@"""4-way"" + medicine", "active inactive ingredients");
            results = gcs.Search(@"""5-HTP""", @"""5-HTP"" + medicine + active + inactive + ingredients -pdf");

            foreach (var item in results)
            {
                Console.WriteLine(item.HtmlTitle);
                Console.WriteLine(item.Snippet);
                Console.WriteLine(item.Link);
            }
        }
    }
}
