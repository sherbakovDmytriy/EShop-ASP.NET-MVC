using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISizeService
    {
        #region Get

        Task<IEnumerable<SizeDTO>> GetSizesAsync(int? limit = null);
        Task<SizeDTO> GetSizeAsync(int Id);

        #endregion

        #region Create Edit Delete

        Task<bool> CreateAsync(SizeDTO model);
        Task<bool> EditAsync(SizeDTO model);
        Task<bool> DeleteAsync(int Id);

        #endregion
    }
}
