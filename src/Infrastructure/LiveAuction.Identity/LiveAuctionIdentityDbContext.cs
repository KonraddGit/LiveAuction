using LiveAuction.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiveAuction.Identity;

public class LiveAuctionIdentityDbContext : IdentityDbContext<ApplicationUser>
{
	public LiveAuctionIdentityDbContext()
	{
	}

	public LiveAuctionIdentityDbContext(
		DbContextOptions<LiveAuctionIdentityDbContext> options) : base(options)
	{
	}
}