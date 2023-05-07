using Infrastructure.Entities;
using Infrastructure.Entitites;
using Infrastructure.Repository;
using System.Linq;

namespace Infrastructure.Service
{
    public interface IHocSinhService
    {
        IQueryable<HocSinh> GetHocSinhs();
        HocSinh GetHocSinh(int id);
        void InsertHocSinh(HocSinh hocsinh);
        void UpdateHocSinh(HocSinh hocsinh);
        void DeleteHocSinh(HocSinh hocsinh);
    }

    public class HocSinhService : IHocSinhService
    {
        private IHocSinhRepository hocsinhRepository;

        public HocSinhService(IHocSinhRepository hocsinhRepository)
        {
            this.hocsinhRepository = hocsinhRepository;
        }

        public IQueryable<HocSinh> GetHocSinhs()
        {
            return hocsinhRepository.GetAll();
        }

        public HocSinh GetHocSinh(int id)
        {
            return hocsinhRepository.GetById(id);
        }

        public void InsertHocSinh(HocSinh hocsinh)
        {
            hocsinhRepository.Insert(hocsinh);
        }

        public void UpdateHocSinh(HocSinh hocsinh)
        {
            hocsinhRepository.Update(hocsinh);
        }

        public void DeleteHocSinh(HocSinh hocsinh)
        {
            hocsinhRepository.Delete(hocsinh);
        }
    }
}
