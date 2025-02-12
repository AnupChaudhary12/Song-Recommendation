﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SongRecommendation.Application
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}
