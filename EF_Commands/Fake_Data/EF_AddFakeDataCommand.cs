using Application.Commands.FakeData;
using Bogus;
using Domain;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.Fake_Data
{
    public class EF_AddFakeDataCommand : EF_BaseEntity, IAddFakeDataCommand
    {
        public EF_AddFakeDataCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute()
        {
            var categories = new List<Category>();
            categories.Add(new Category
            {
                Name = "Putnicko vozilo"
            });
            categories.Add(new Category
            {
                Name = "Teretno vozilo"
            });
            categories.Add(new Category
            {
                Name = "Motorcikl"
            });
            categories.Add(new Category
            {
                Name = "Ostalo"
            });

            Context.Categories.AddRange(categories);

            var equipments = new List<CarEquipment>();
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Tempomat"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Servo volan"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Siber"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Elektricni retrovozori"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Elektricni prozori"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Putni racunar"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Xenon svetla"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Grejaci retrovizora"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Senzori za kisu"
            });
            equipments.Add(new CarEquipment
            {
                EquipmentName = "Navigacija"
            });

            Context.CarEquipments.AddRange(equipments);

            var fulesFaker = new Faker<Fuel>();

            fulesFaker.RuleFor(x => x.Name, f => f.Vehicle.Fuel());

            var fuels = fulesFaker.Generate(10);
            fuels = fuels.GroupBy(f => f.Name).Select(f => f.First()).ToList();

            Context.Fuels.AddRange(fuels);

            var carbodysFaker = new Faker<CarBody>();

            carbodysFaker.RuleFor(x => x.Name, f => f.Vehicle.Type());

            var carbodys = carbodysFaker.Generate(20);
            carbodys = carbodys.GroupBy(c => c.Name).Select(c => c.First()).ToList();

            Context.CarBodies.AddRange(carbodys);

            var usersFaker = new Faker<User>();

            usersFaker.RuleFor(x => x.FirstName, f => f.Name.FirstName());
            usersFaker.RuleFor(x => x.LastName, f => f.Name.LastName());
            usersFaker.RuleFor(x => x.Email, f => f.Internet.Email());
            usersFaker.RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber());

            var users = usersFaker.Generate(50);
            users = users.GroupBy(u => u.Email).Select(u => u.First()).ToList();

            Context.Users.AddRange(users);

            var brandsFaker = new Faker<Brand>();

            brandsFaker.RuleFor(x => x.Name, f => f.Vehicle.Manufacturer());
            brandsFaker.RuleFor(x => x.City, f => f.Address.City());
            brandsFaker.RuleFor(x => x.State, f => f.Address.State());
            brandsFaker.RuleFor(x => x.Logo, f => f.Image.PicsumUrl());

            var brands = brandsFaker.Generate(50);
            brands = brands.GroupBy(b => b.Name).Select(b => b.First()).ToList();
            Context.Brands.AddRange(brands);

            var modelsFaker = new Faker<Model>();
            modelsFaker.RuleFor(x => x.Name, f => f.Vehicle.Model());
            modelsFaker.RuleFor(x => x.Brand, f => f.PickRandom(brands));

            var models = modelsFaker.Generate(150);
            models = models.GroupBy(m => m.Name).Select(b => b.First()).ToList();

            Context.Models.AddRange(models);

            var carEquipmentAdsFaker = new Faker<CarEquipmentAd>();
            carEquipmentAdsFaker.RuleFor(x => x.CarEquipment, f => f.PickRandom(equipments));

            var advertisementsFaker = new Faker<Advertisement>();

            advertisementsFaker.RuleFor(x => x.AdName, f => f.Commerce.ProductName());
            advertisementsFaker.RuleFor(x => x.AdDescription, f => f.Lorem.Text());
            advertisementsFaker.RuleFor(x => x.Price, f => f.Random.Int(10, 100000));
            advertisementsFaker.RuleFor(x => x.KmValue, f => f.Random.Int(0, 800000));
            advertisementsFaker.RuleFor(x => x.EnginePower, f => f.Random.Int(5, 300));
            advertisementsFaker.RuleFor(x => x.EngineVolume, f => f.Random.Int(900, 4000));
            advertisementsFaker.RuleFor(x => x.ProductionYear, f => f.Random.Int(1950, 2020));
            advertisementsFaker.RuleFor(x => x.City, f => f.Address.City());
            advertisementsFaker.RuleFor(x => x.Model, f => f.PickRandom(models));
            advertisementsFaker.RuleFor(x => x.Fuel, f => f.PickRandom(fuels));
            advertisementsFaker.RuleFor(x => x.CarBody, f => f.PickRandom(carbodys));
            advertisementsFaker.RuleFor(x => x.User, f => f.PickRandom(users));
            advertisementsFaker.RuleFor(x => x.Category, f => f.PickRandom(categories));
            advertisementsFaker.RuleFor(x => x.AdCarEquipments, f => carEquipmentAdsFaker.Generate(1));

            var advertisements = advertisementsFaker.Generate(200);
            advertisements = advertisements.GroupBy(a => a.AdName).Select(a => a.First()).ToList();

            Context.Advertisements.AddRange(advertisements);

            var imagesFaker = new Faker<Image>();

            imagesFaker.RuleFor(x => x.Src, f => f.Image.PicsumUrl());
            imagesFaker.RuleFor(x => x.Alt, f => f.Lorem.Sentence());
            imagesFaker.RuleFor(x => x.Advertisement, f => f.PickRandom(advertisements));

            var images = imagesFaker.Generate(300);
            images = images.GroupBy(i => i.Src).Select(i => i.First()).ToList();

            Context.Images.AddRange(images);

            Context.SaveChanges();
        }
    }
}
