using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Advertisement;
using Application.Commands.Brand;
using Application.Commands.CarBody;
using Application.Commands.Category;
using Application.Commands.Equipment;
using Application.Commands.FakeData;
using Application.Commands.Fuel;
using Application.Commands.Model;
using Application.Commands.User;
using EF_Commands.EF_Advertisement;
using EF_Commands.EF_Brand;
using EF_Commands.EF_CarBody;
using EF_Commands.EF_Category;
using EF_Commands.EF_Equipment;
using EF_Commands.EF_Fuel;
using EF_Commands.EF_Model;
using EF_Commands.EF_User;
using EF_Commands.Fake_Data;
using EF_DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<asp_projectContext>();
            //Categories
            services.AddTransient<IAddCategoryCommand, EF_AddCategoryCommand>();
            services.AddTransient<IGetCategoriesCommand, EF_GetCategoriesCommand>();
            services.AddTransient<IGetCategoryCommand, EF_GetCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EF_DeleteCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EF_EditCategoryCommand>();
            //Fuels
            services.AddTransient<IAddFuelCommand, EF_AddFuelCommand>();
            services.AddTransient<IGetFuelsCommand, EF_GetFuelsCommand>();
            services.AddTransient<IGetFuelCommand, EF_GetFuelCommand>();
            services.AddTransient<IDeleteFuelCommand, EF_DeleteFuelCommand>();
            services.AddTransient<IEditFuelCommand, EF_EditFuelCommand>();
            //CarBodies
            services.AddTransient<IAddCarBodyCommand, EF_AddCarBodyCommand>();
            services.AddTransient<IGetCarBodiesCommand, EF_GetCarBodiesCommand>();
            services.AddTransient<IGetCarBodyCommand, EF_GetCarBodyCommand>();
            services.AddTransient<IDeleteCarBodyCommand, EF_DeleteCarBodyCommand>();
            services.AddTransient<IEditCarBodyCommand, EF_EditCarBodyCommand>();
            //Brands
            services.AddTransient<IAddBrandCommand, EF_AddBrandCommand>();
            services.AddTransient<IGetBrandsCommand, EF_GetBrandsCommand>();
            services.AddTransient<IGetBrandCommand, EF_GetBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EF_DeleteBrandCommand>();
            services.AddTransient<IEditBrandCommand, EF_EditBrandCommand>();
            //Users
            services.AddTransient<IAddUserCommand, EF_AddUserCommand>();
            services.AddTransient<IGetUsersCommand, EF_GetUsersCommand>();
            services.AddTransient<IGetUserCommand, EF_GetUserCommand>();
            services.AddTransient<IEditUserCommand, EF_EditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EF_DeleteUserCommand>();
            //Models
            services.AddTransient<IAddModelCommand, EF_AddModelCommand>();
            services.AddTransient<IGetModelsCommand, EF_GetModelsCommand>();
            services.AddTransient<IGetModelCommand, Ef_GetModelCommand>();
            services.AddTransient<IEditModelCommand, EF_EditModelCommand>();
            services.AddTransient<IDeleteModelCommand, EF_DeleteModelCommand>();
            //Equipemnts
            services.AddTransient<IAddEquipmentCommand, EF_AddEquipmentCommand>();
            services.AddTransient<IGetEquipmentsCommand, EF_GetEquipmentsCommand>();
            services.AddTransient<IGetEquipmentCommand, EF_GetEquipmentCommand>();
            services.AddTransient<IEditEquipmentCommand, EF_EditEquipmentCommand>();
            services.AddTransient<IDeleteEquipmentCommand, EF_DeleteEquipmentCommand>();
            //Advertisements
            services.AddTransient<IAddAdvertisementCommand, EF_AddAdvertisementCommand>();
            services.AddTransient<IGetAdvertisementsCommand, EF_GetAdvertisementsCommand>();
            services.AddTransient<IGetAdvertisementCommand, EF_GetAdvertisementCommand>();
            services.AddTransient<IEditAdvertisementCommand, EF_EditAdvertisementCommand>();
            services.AddTransient<IDeleteAdvertisementCommand, EF_DeleteAdvertisementCommand>();
            //FakerData, run only once: POST /api/fakedatafeed
            services.AddTransient<IAddFakeDataCommand, EF_AddFakeDataCommand>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc();
        }
    }
}
