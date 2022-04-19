using InspectionAPI.Data;
using InspectionAPI.Model;
using InspectionAPI.Repository.IRepository;

namespace InspectionAPI.Repository
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly ApplicationDbContext _db;
        public InspectionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateInspection(Inspection inspection)
        {
            _db.Inspections.Add(inspection);
            return Save();

        }

        public bool DeleteInspection(Inspection inspection)
        {
            _db.Inspections.Remove(inspection);
            return Save();
        }

        public Inspection GetInspection(int id)
        {
            return _db.Inspections.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Inspection> GetInspections()
        {
            return _db.Inspections.OrderBy(x=>x.Id).ToList();   
        }

        public bool InspectionExists(string status)
        {
            bool value= _db.Inspections.Any(x => x.Status == status);
            return value;
        }

        public bool InspectionExists(int id)
        {
            bool value = _db.Inspections.Any(x => x.Id == id);
            return value;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateInspection(Inspection inspection)
        {
            _db.Inspections.Update(inspection);
            return Save();
        }
    }
}
