using ClaroTestBackend.Core.Domain.Interfaces.Repositories;
using System.Net;
using System.Net.Http.Json;

namespace ClaroTestBackend.Infrastructure.Persistence.Repositories.HttpClientRepository
{
    public abstract class BaseHttpRepository<TEntity, TResponseDto, TRequestDto> : IBaseRepository<TEntity>
    where TEntity : class
    where TResponseDto : class
    where TRequestDto : class
    {
        protected readonly HttpClient HttpClient;

        protected BaseHttpRepository(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected abstract TEntity MapToDomain(TResponseDto dto);
        protected abstract TRequestDto MapToRequest(TEntity entity);
        protected abstract string ResourceEndpoint { get; }

        public virtual async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync($"api/v1/{ResourceEndpoint}/{id}", cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            var dto = await response.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken: cancellationToken);
            return dto is not null ? MapToDomain(dto) : null;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.GetAsync($"api/v1/{ResourceEndpoint}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var dtoList = await response.Content.ReadFromJsonAsync<IEnumerable<TResponseDto>>(cancellationToken: cancellationToken);
            return dtoList?.Select(MapToDomain) ?? Enumerable.Empty<TEntity>();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var requestDto = MapToRequest(entity);
            var response = await HttpClient.PostAsJsonAsync($"api/v1/{ResourceEndpoint}", requestDto, cancellationToken);
            response.EnsureSuccessStatusCode();

            var createdDto = await response.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken: cancellationToken);
            return createdDto is not null ? MapToDomain(createdDto) : entity;
        }

        public virtual async Task UpdateAsync(int id, TEntity entity, CancellationToken cancellationToken = default)
        {
            var requestDto = MapToRequest(entity);
            var response = await HttpClient.PutAsJsonAsync($"api/v1/{ResourceEndpoint}/{id}", requestDto, cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.DeleteAsync($"api/v1/{ResourceEndpoint}/{id}", cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return;

            response.EnsureSuccessStatusCode();
        }
    }
}
