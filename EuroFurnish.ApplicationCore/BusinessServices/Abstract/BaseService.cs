using AutoMapper;
using EuroFurnish.ApplicationCore.Helpers;
using EuroFurnish.ApplicationCore.Interfaces;

namespace EuroFurnish.ApplicationCore.BusinessServices.Abstract
{
    public abstract class BaseService
    {
        protected IUnitOfWork _unitOfWork => HttpHelper.GetService<IUnitOfWork>();
        protected IMapper _mapper => HttpHelper.GetService<IMapper>();
    }
}
