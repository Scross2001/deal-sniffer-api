using HtmlAgilityPack;

namespace deal_sniffer_api.Services
{
    public class WalmartScraperService
    {
        private const string WalmartUrl = "https://www.walmart.com/search?q=";

        public async Task<List<string>> ScrapeProductTitles(string searchTerm)
        {
            var url = WalmartUrl + Uri.EscapeDataString(searchTerm);
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);

            var titles = new List<string>();

            var productNodes = doc.DocumentNode.SelectNodes("//a[contains(@class, 'product-title-link')]");

            if (productNodes != null)
            {
                foreach (var node in productNodes)
                {
                    var title = node.InnerText.Trim();
                    titles.Add(title);
                }
            }

            return titles;
        }
    }
}
