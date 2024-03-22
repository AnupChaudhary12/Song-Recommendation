using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SongRecommendation.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongRecommendation.Persistence
{
	public static class PersistanceServiceRegistration
	{
		public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<SongRecommendationDbContext>(options => options
			.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
           
            services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}
