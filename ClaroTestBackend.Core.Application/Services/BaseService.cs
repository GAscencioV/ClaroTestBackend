using ClaroTestBackend.Core.Application.Interfaces;
using ClaroTestBackend.Core.Domain.Interfaces.Repositories;

namespace ClaroTestBackend.Core.Application.Services
{
    public abstract class BaseService<TEntity, TResponseDto, TCreateDto, TUpdateDto>
    : IBaseService<TResponseDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TResponseDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        protected readonly IBaseRepository<TEntity> Repository;

        protected BaseService(IBaseRepository<TEntity> repository)
        {
            Repository = repository;
        }
        protected abstract TResponseDto MapToResponseDto(TEntity entity);
        protected abstract TEntity MapToEntityFromCreate(TCreateDto dto);
        protected abstract void UpdateEntityFromDto(TEntity entity, TUpdateDto dto);

        public virtual async Task<TResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await Repository.GetByIdAsync(id, cancellationToken);
            return entity is not null ? MapToResponseDto(entity) : null;
        }

        public virtual async Task<IEnumerable<TResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await Repository.GetAllAsync(cancellationToken);
            return entities.Select(MapToResponseDto);
        }

        public virtual async Task<TResponseDto?> CreateAsync(TCreateDto dto, CancellationToken cancellationToken = default)
        {
            var entity = MapToEntityFromCreate(dto);
            var created = await Repository.CreateAsync(entity, cancellationToken);
            return created is not null ? MapToResponseDto(created) : null;
        }

        public virtual async Task<TResponseDto?> UpdateAsync(int id, TUpdateDto dto, CancellationToken cancellationToken = default)
        {
            var existing = await Repository.GetByIdAsync(id, cancellationToken);
            if (existing is null)
                return null;

            UpdateEntityFromDto(existing, dto);
            await Repository.UpdateAsync(id, existing, cancellationToken);

            return MapToResponseDto(existing);
        }

        public virtual async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var existing = await Repository.GetByIdAsync(id, cancellationToken);
            if (existing is null)
                return false;

            await Repository.DeleteAsync(id, cancellationToken);
            return true;
        }
    }
}
