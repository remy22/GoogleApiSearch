using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;

namespace GoogleApiSearch
{
    public class GoogleCustomSearch
    {
        private static readonly string CustomSearchEngineID = "014535839661891102018:n1fvfmsxp1w";
        private static readonly string CustomSearchEngineName = "MedicinalCSE";
        private static readonly string GoogleAPIKey = "AIzaSyBYW7phB8dtlC7jRWBuchOHU9cm5gsOWJA";

        public IList<Google.Apis.Customsearch.v1.Data.Result> Search(string iMatchExact, string iQuery)//, string iExcludeTerms)
        {
            //string query = "4-way active inactive ingredients";

            var service = new Google.Apis.Customsearch.v1.CustomsearchService(
            new BaseClientService.Initializer { ApiKey = GoogleAPIKey });
            var listRequest = service.Cse.List(iQuery);

            listRequest.Cx = CustomSearchEngineID;
            listRequest.ExactTerms = iMatchExact;
            //listRequest.ExcludeTerms = iExcludeTerms;
            listRequest.Num = 10;

            IList<Google.Apis.Customsearch.v1.Data.Result> results = null;
            try
            {
                var search = listRequest.Execute();
                results = search.Items;
                
            }
            catch (Exception ex)
            {
                //TODO: Log the error
            }

            return results;
        }

    }
}
