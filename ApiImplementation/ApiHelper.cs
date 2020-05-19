namespace ApiImplementation
{
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class ApiHelper
    {

        public static HttpClient ApiClient { get; set; }
        /// <summary>
        /// Initializer for HTTP Client, so we can access our API
        /// </summary>
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}