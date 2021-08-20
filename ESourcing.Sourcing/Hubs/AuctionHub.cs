using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ESourcing.Sourcing.Hubs
{
    public class AuctionHub: Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendBidAsync(string groupName, string user, string bid)
        {
            await Clients.Group(groupName).SendAsync("Bids", user, bid);
        }
    }
}