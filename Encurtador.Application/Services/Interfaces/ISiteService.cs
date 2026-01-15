using Encurtador.Application.DTO;
using Encurtador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encurtador.Application.Services.Interfaces;
public interface ISiteService
{
    Task<SiteResponseDto> CreateSite(string url);
    Task DeleteSite(string shortCode);
    Task<SiteResponseDto> GetSite(string shortCode);
    Task<IEnumerable<SiteResponseDto>> GetAll();
}