using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application
{ 
	/// <summary>
	/// Dependency injection for application layer
	/// </summary>
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			// Add application services here

			/**
			 * This will scan the assembly where the DependecyInjection type is.
			 * It will be scanned and it will look for all the IRequest and IRequestHandler.
			 */
			services.AddMediatR(options =>
				options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection))
			);

			return services;
		}
	}
}