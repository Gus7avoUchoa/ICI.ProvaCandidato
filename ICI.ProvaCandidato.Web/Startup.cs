using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ICI.ProvaCandidato.Dados.Context;
using ICI.ProvaCandidato.Negocio.Interfaces;
using ICI.ProvaCandidato.Negocio.Services;
using ICI.ProvaCandidato.Dados.Repositories;
using ICI.ProvaCandidato.Negocio.Mappers;

namespace ICI.ProvaCandidato.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<NoticiasContext>(options =>
				options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
			
			// Camada de Negócio
			services.AddScoped<ITagService, TagService>();
			services.AddScoped<INoticiaService, NoticiaService>();
			services.AddScoped<IUsuarioService, UsuarioService>();
			
			// Camada de Dados
			services.AddScoped<TagRepository>();
			services.AddScoped<NoticiaRepository>();
			services.AddScoped<UsuarioRepository>();

			services.AddAutoMapper(typeof(AutoMapperProfile));
			
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
