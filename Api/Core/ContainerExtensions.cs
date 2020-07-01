using Application.Commands.Advertisement;
using Application.Commands.Brand;
using Application.Commands.CarBody;
using Application.Commands.Category;
using Application.Commands.Equipment;
using Application.Commands.FakeData;
using Application.Commands.Fuel;
using Application.Commands.Model;
using Application.Commands.UseCaseLog;
using Application.Commands.User;
using Application.Interfaces;
using EF_Commands.EF_Advertisement;
using EF_Commands.EF_Brand;
using EF_Commands.EF_CarBody;
using EF_Commands.EF_Category;
using EF_Commands.EF_Equipment;
using EF_Commands.EF_Fuel;
using EF_Commands.EF_Model;
using EF_Commands.EF_UseCaseLog;
using EF_Commands.EF_User;
using EF_Commands.Fake_Data;
using EF_Commands.Log;
using EF_Commands.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            //UseCaseLog
            services.AddTransient<ILogUseCase, EF_LogUseCase>();
            services.AddTransient<IGetUseCaseLogsCommand, EF_GetUseCaseLogsCommand>();

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
            services.AddTransient<AddCarBodyValidation>();
            //Brands
            services.AddTransient<IAddBrandCommand, EF_AddBrandCommand>();
            services.AddTransient<IGetBrandsCommand, EF_GetBrandsCommand>();
            services.AddTransient<IGetBrandCommand, EF_GetBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EF_DeleteBrandCommand>();
            services.AddTransient<IEditBrandCommand, EF_EditBrandCommand>();
            services.AddTransient<AddBrandValidator>();
            //Users
            services.AddTransient<IRegisterUserCommand, EF_RegisterUserCommand>();
            services.AddTransient<ICheckUserCommand, EF_CheckUserCommand>();
            services.AddTransient<IGetUsersCommand, EF_GetUsersCommand>();
            services.AddTransient<IGetUserCommand, EF_GetUserCommand>();
            services.AddTransient<IEditUserCommand, EF_EditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EF_DeleteUserCommand>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<EditUserValidator>();
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
        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                    return new UnauthorizedActor();

                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });
        }
        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                return new JwtManager(appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
