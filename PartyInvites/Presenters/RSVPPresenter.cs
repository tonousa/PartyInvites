using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters.Results;

namespace PartyInvites.Presenters
{
    public class RSVPPresenter : IPresenter<GuestResponse>
    {
        public IRepository repository { get; set; }

        IResult IPresenter<GuestResponse>.GetResult()
        {
            return new DataResult<GuestResponse>(new GuestResponse());
        }

        IResult IPresenter<GuestResponse>.GetResult(GuestResponse requestData)
        {
            repository.AddResponse(requestData);
            if (requestData.WillAttend.Value)
            {
                return new RedirectResult("/Content/seeyouthere.html");
            }
            else
            {
                return new RedirectResult("/Content/sorryyoucantcome.html");
            }
        }
    }
}