using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITypeService
    {
        #region Get

        Task<IEnumerable<TypeDTO>> GetTypesAsync(int? limit = null);
        Task<IEnumerable<TypeDTO>> GetTypesWithSubtypesAsync(int? limit = null);
        Task<TypeDTO> GetTypeAsync(int Id);
        Task<TypeDTO> GetTypeWithSubtypesAsync(int Id);

        #endregion

        #region Create Edit Delete

        Task<bool> CreateAsync(TypeDTO model);
        Task<bool> EditAsync(TypeDTO model);
        Task<bool> DeleteAsync(int Id);

        #endregion
    }
}
