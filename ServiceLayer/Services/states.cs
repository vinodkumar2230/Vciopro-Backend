using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class states:IState
    {
        vCIOPRoEntities ctx = new vCIOPRoEntities();
        private UnitOfWork unitOfWork { get; set; }

        public states(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }
        public state GetAllState(int id)
        {
            var data= unitOfWork.StateRepository.GetStateByID(id);
            return data;
        }
    }
}
