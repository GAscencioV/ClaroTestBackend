using System;
using System.Collections.Generic;
using System.Text;

namespace ClaroTestBackend.Core.Application.Interfaces
{
    public interface IBaseService<TResponseDto, in TCreateDto, in TUpdateDto>
        where TResponseDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<TResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TResponseDto?> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default);
        Task<TResponseDto?> UpdateAsync(int id, TUpdateDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
