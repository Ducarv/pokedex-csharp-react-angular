using Pokedex.Services;
using Pokedex.Repositories;
using Pokedex.Data;
using Microsoft.EntityFrameworkCore;

namespace Pokedex
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("SQLiteConnection")));

            // Create Pokemon
            services.AddScoped<ICreatePokemonService, CreatePokemonService>();
            services.AddScoped<ICreatePokemonRepository, CreatePokemonRepository>();

            // List all pokemon
            services.AddScoped<IListAllPokemonService, ListAllPokemonService>();
            services.AddScoped<IListAllPokemonRepository, ListAllPokemonRepository>();

            // List pokemon by id
            services.AddScoped<IListPokemonByIdService, ListPokemonByIdService>();
            services.AddScoped<IListPokemonByIdRepository, ListPokemonByIdRepository>();

            // List pokemon by name
            services.AddScoped<IListPokemonByNameService, ListPokemonByNameService>();
            services.AddScoped<IListPokemonByNameRepository, ListPokemonByNameRepository>();

            // List pokemon by type
            services.AddScoped<IListPokemonByTypesService, ListPokemonByTypesService>();
            services.AddScoped<IListPokemonByTypesRepository, ListPokemonByTypesRepository>();

            // edit pokemon
            services.AddScoped<IEditPokemonByIdService, EditPokemonByIdService>();
            services.AddScoped<IEditPokemonByIdRepository, EditPokemonByIdRepository>();

            // delete pokemon
            services.AddScoped<IDeletePokemonByIdService, DeletePokemonByIdService>();
            services.AddScoped<IDeletePokemonByIdRepository, DeletePokemonByIdRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints => 
        {
            endpoints.MapControllers();
        });
    }
    }
}
