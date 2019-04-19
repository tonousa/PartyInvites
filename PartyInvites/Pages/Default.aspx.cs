using System;
using System.Web.ModelBinding;
using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters;
using PartyInvites.Presenters.Results;

namespace PartyInvites.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        public IPresenter<GuestResponse> presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new RSVPPresenter { repository = new MemoryRepository() };

            if (IsPostBack)
            {
                GuestResponse rsvp = ((DataResult<GuestResponse>)(presenter
                    .GetResult())).DataItem;

                if (TryUpdateModel(rsvp, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    Response.Redirect(((RedirectResult)presenter.GetResult(rsvp)).Url);
                }
            }
        }
    }
}