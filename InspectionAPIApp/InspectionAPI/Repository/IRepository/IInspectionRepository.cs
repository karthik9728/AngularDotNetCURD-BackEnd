using InspectionAPI.Model;

namespace InspectionAPI.Repository.IRepository
{
    public interface IInspectionRepository
    {
        ICollection<Inspection> GetInspections();
        Inspection GetInspection(int id);
        bool InspectionExists(string status);
        bool InspectionExists(int id);
        bool CreateInspection(Inspection inspection);
        bool UpdateInspection(Inspection inspection);
        bool DeleteInspection(Inspection inspection);
        bool Save();
    }
}
