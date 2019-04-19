using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartyInvites.Presenters;
using PartyInvites.Presenters.Results;

namespace PartyInvites.Presenters
{
    public interface IPresenter<T>
    {
        IResult GetResult();
        IResult GetResult(T requestData);
    }
}
