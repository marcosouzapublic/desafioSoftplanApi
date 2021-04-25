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

            //Service para configura��o da biblioteca Swagger, respons�vel pela documenta��o e exibi��o dos endpoints da API.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio Softplan", Version = "v1" });
            });

            //Service para inje��o de depend�ncia da interface ITaxaJuros.
            services.AddScoped<ITaxaJuros, TaxaJuros>();

            //Service para inje��o de depend�ncia da interface ICalculaJuros.
            //Alterar a URL passada para o n�mero da porta que utilize em seu servidor de aplica��o.
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

            //Service para inje��o de depend�ncia da interface IShowMeTheCode.
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Softplan v1"));
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
