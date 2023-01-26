using Microsoft.EntityFrameworkCore;

namespace to_do_App.Models;

public class ApplicationContext:DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
	{

	}
	public DbSet<to_do_Model> TOdoTable { get; set; }
}
