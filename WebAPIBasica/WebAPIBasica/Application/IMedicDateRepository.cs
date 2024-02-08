using WebAPIBasica.Models;

namespace WebAPIBasica.Application
{
    public interface IMedicDateRepository
    {
        Task<IEnumerable<MedicDate>> GetAllMedicDates();
        Task<MedicDate?> GetMedicDate(int id);
        Task<bool> InsertMedicaDate(MedicDate md);
        Task<bool> UpdateMedicaDate(MedicDate md);
        Task<bool> DeleteMedicaDate(MedicDate md);
    }
}
