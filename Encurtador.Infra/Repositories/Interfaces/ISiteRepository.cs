using Encurtador.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encurtador.Infra.Repositories.Interfaces;
public interface ISiteRepository
{
    Task<Site?> Get(string shortCode);
    Task Add(Site site);
    Task Delete(string shortCode);
    Task<IEnumerable<Site>> Get();
    Task SaveChanges();
}