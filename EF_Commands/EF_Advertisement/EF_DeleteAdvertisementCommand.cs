using Application.Commands.Advertisement;
using Application.Exceptions;
using EF_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Commands.EF_Advertisement
{
    public class EF_DeleteAdvertisementCommand : EF_BaseEntity, IDeleteAdvertisementCommand
    {
        public EF_DeleteAdvertisementCommand(asp_projectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var advertisement = Context.Advertisements.Find(request);

            if (advertisement == null)
                throw new EntityNotFoundException();
            if (advertisement.IsDeleted)
                throw new EntityAlreadyDeletedException();

            advertisement.IsDeleted = true;
            advertisement.DeletedAt = DateTime.Now;

            Context.SaveChanges();
        }
    }
}
