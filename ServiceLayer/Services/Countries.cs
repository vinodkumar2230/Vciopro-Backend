using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class Countries:ICountry
    {
        private UnitOfWork unitOfWork { get; set; }

        public Countries(UnitOfWork _UnitOfWork)
        {
            unitOfWork = _UnitOfWork;
        }
        public List<Country> GetAllCountry()
        {
            var data = unitOfWork.CountryRepository.Get().ToList();

            return data;
        }
    }
}
