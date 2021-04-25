using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;
using System.Net.Http;

namespace desafioSoftplan
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "softplan", Version = "v1" });
            });

            services.AddScoped<ITaxaJuros, TaxaJuros>();

            services.AddScoped<ICalculaJuros, CalculaJuros>(j =>
                new CalculaJuros(
                    new ApiJurosConsumer(
                        new HttpClient()
                        {
                            BaseAddress = new System.Uri("http://localhost:5001/taxajuros")
                        }
                    )
                )
            );

            services.AddScoped<IShowMeTheCode, ShowMeTheCode>(s =>
                new ShowMeTheCode("https://github.com/marcosouzapublic/desafioSoftplanApi")
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "softplan v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Habilita o middleware Swagger para ser gerado um endpoint JSON    
            app.UseSwagger();

            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APITaxaJuros")
            );
        }
    }
}
