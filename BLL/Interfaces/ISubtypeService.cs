using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubtypeService
    {
        #region Get

        Task<IEnumerable<SubtypeDTO>> GetSubtypesAsync(int? limit = null);
        Task<SubtypeDTO> GetSubtypeAsync(int Id);
        Task<IEnumerable<SubtypeDTO>> GetByTypeAsync(int typeId);

        #endregion

        #region Create Edit Delete

        Task<bool> CreateAsync(SubtypeDTO model);
        Task<bool> EditAsync(SubtypeDTO model);
        Task<bool> DeleteAsync(int Id);

        #endregion
    }
}
