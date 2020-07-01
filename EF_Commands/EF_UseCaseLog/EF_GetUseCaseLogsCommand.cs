using Application.Commands.UseCaseLog;
using Application.Dto;
using Application.Searches;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Commands.EF_UseCaseLog
{
    public class EF_GetUseCaseLogsCommand : EF_BaseEntity, IGetUseCaseLogsCommand
    {
        public EF_GetUseCaseLogsCommand(asp_projectContext context) : base(context)
        {
        }

        public int Id => 42;

        public string UseCaseName => "EFLogSearch";

        public IEnumerable<LogDto> Execute(LogSearch request)
        {
            var query = Context.UseCaseLogs.AsQueryable();

            if (request.Actor != null)
                query = query.Where(u => u.Actor.ToLower().Contains(request.Actor.ToLower()));
            if (request.UseCaseName != null)
                query = query.Where(u => u.UseCaseName.ToLower().Contains(request.UseCaseName.ToLower()));
            if (request.FromDate != 0)
                query = query.Where(u => u.Timestamp >= request.FromDate);
            if (request.UntillDate != 0)
                query = query.Where(u => u.Timestamp <= request.UntillDate);

            return query.Select(x => new LogDto
            {
                Actor = x.Actor,
                Data = x.Data,
                Date = x.CreatedAt,
                UseCaseName = x.UseCaseName
            });
        }
    }
}
