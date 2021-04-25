using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using desafioSoftplan.Contracts;
using desafioSoftplan.Models;
using System.Net.Http;
using System.Reflection;
using System.IO;
using System;

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

            //Service para configuração da biblioteca Swagger, responsável pela documentação e exibição dos endpoints da API.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio Softplan", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Service para injeção de dependência da interface ITaxaJuros.
            services.AddScoped<ITaxaJuros, TaxaJuros>();

            //Service para injeção de dependência da interface ICalculaJuros.
            //Alterar a URL passada para o número da porta que utilize em seu servidor de aplicação.
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

            //Service para injeção de dependência da interface IShowMeTheCode.
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

            // Habilita o Swagger UI
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APITaxaJuros")
            );
        }
    }
}
