using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SizeService : ISizeService
    {
        public Task<bool> CreateAsync(SizeDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(SizeDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<SizeDTO> GetTradeMarkAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SizeDTO>> GetTradeMarksAsync(int? limit = null)
        {
            throw new NotImplementedException();
        }
    }
}
