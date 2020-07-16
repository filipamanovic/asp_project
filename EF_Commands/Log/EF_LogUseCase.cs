using Application.Interfaces;
using Bogus.DataSets;
using EF_DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.Log
{
    public class EF_LogUseCase : EF_BaseEntity, ILogUseCase
    {
        public EF_LogUseCase(asp_projectContext context) : base(context)
        {
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            Context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                CreatedAt = DateTime.UtcNow,
                UseCaseName = useCase.UseCaseName,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });

            Context.SaveChanges();
        }
    }
}
