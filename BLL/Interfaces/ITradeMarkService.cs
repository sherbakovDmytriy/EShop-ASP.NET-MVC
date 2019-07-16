using BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITradeMarkService
    {
        #region Get

        Task<IEnumerable<TradeMarkDTO>> GetTradeMarksAsync(int? limit = null);
        Task<TradeMarkDTO> GetTradeMarkAsync(int Id);
        
        #endregion

        #region Create Edit Delete

        Task<bool> CreateAsync(TradeMarkDTO model);
        Task<bool> EditAsync(TradeMarkDTO model);
        Task<bool> DeleteAsync(int Id);
        
        #endregion
    }
}
