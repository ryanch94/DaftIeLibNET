using DaftIeLibNET.Models;

namespace DaftIeLibNET
{
    public class ForSaleSearch
    {
        public async Task<string> GetForSaleListings(ForSaleSearchSettings settings, int pageNum, int pageSize = 20)
        {
            DaftClient client = new DaftClient();
            string results = await client.GetListingsResults("residential-for-sale", pageNum, pageSize);
            return results;
        }
    }
}
