using DaftIeLibNET.Models;

namespace DaftIeLibNET
{
    public class RentalSearch
    {
        public async Task<string> GetRentalListings(RentalSearchSettings settings, int pageNum, int pageSize = 20)
        {
            DaftClient client = new DaftClient();
            string results = await client.GetListingsResults("residential-to-rent", pageNum, pageSize);
            return results;
        }
    }
}