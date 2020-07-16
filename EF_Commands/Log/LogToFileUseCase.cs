using Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EF_Commands.Log
{
    public class LogToFileUseCase : ILogUseCase
    {
        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"..\EF_Commands\Log\UseCaseLog.txt", true))
            {
                file.WriteLine($"User: {actor.Identity}, executed command " +
                    $"{useCase.UseCaseName} at {DateTime.Now}" +
                    $"{JsonConvert.SerializeObject(useCaseData)}");
            }
        }
    }
}
