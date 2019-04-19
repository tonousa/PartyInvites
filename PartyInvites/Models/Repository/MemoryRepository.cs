using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models.Repository
{
    public class MemoryRepository : IRepository
    {
        void IRepository.AddResponse(GuestResponse response)
        {
            throw new NotImplementedException();
        }

        IEnumerable<GuestResponse> IRepository.GetAllResponses()
        {
            throw new NotImplementedException();
        }
    }
}