using Encurtador.Application.DTO;
using Encurtador.Application.Services.Interfaces;
using Encurtador.Domain.Models;
using Encurtador.Infra.Database;
using Encurtador.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encurtador.Application.Services;

public class SiteService : ISiteService
{
    private readonly ISiteRepository _repository;

    public SiteService(ISiteRepository repository)
    {
        _repository = repository;
    }

    public async Task<SiteResponseDto> CreateSite(string url)
    {
        var entry = new Site(url);
        await _repository.Add(entry);
        await _repository.SaveChanges();
        return new SiteResponseDto()
        {
            ShortCode = entry.ShortCode,
            UrlAccessCount = entry.UrlAccessCount,
            UrlOrigin = entry.UrlOrigin,
            CreatedAt = entry.CreatedAt
        };
    }

    public async Task DeleteSite(string shortCode)
    {
        await _repository.Delete(shortCode);
        await _repository.SaveChanges();
    }

    public async Task<IEnumerable<SiteResponseDto>> GetAll()
    {
        var sites = await _repository.Get();
        var result = sites.Select(entry => new SiteResponseDto
        {
            ShortCode = entry.ShortCode,
            UrlAccessCount = entry.UrlAccessCount,
            UrlOrigin = entry.UrlOrigin,
            CreatedAt = entry.CreatedAt
        }).ToList();
        return result;
    }

    public async Task<SiteResponseDto> GetSite(string shortCode)
    {
        var entry = await _repository.Get(shortCode);

        if (entry == null)
            throw new KeyNotFoundException("Registro não encontrado.");

        return new SiteResponseDto()
        {
            ShortCode = entry.ShortCode,
            UrlAccessCount = entry.UrlAccessCount,
            UrlOrigin = entry.UrlOrigin,
            CreatedAt = entry.CreatedAt
        };
    }
}