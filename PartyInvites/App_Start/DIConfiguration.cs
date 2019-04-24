using Ninject;
using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.App_Start
{
    public static class DIConfiguration
    {
        public static void SetupDI(IKernel kernel)
        {
            kernel.Bind<IPresenter<GuestResponse>>().To<RSVPPresenter>();
            kernel.Bind<IRepository>().To<MemoryRepository>().InSingletonScope();
            kernel.Bind<IPresenter<IEnumerable<GuestResponse>>>().To<RSVPPresenter>();
        }
    }
}