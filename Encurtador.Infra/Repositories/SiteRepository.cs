using Encurtador.Domain.Models;
using Encurtador.Infra.Database;
using Encurtador.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encurtador.Infra.Repositories;

public class SiteRepository : ISiteRepository
{
    private readonly DatabaseContext _context;
    public SiteRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task Add(Site site)
    {
        await _context.Sites.AddAsync(site);
    }

    public async Task Delete(string shortCode)
    {
        var entry = await _context.Sites.FindAsync(shortCode);

        if (entry == null)
            throw new KeyNotFoundException($"Registro não encontrado");

        _context.Sites.Remove(entry);
    }

    public async Task<Site?> Get(string shortCode)
    {
        return await _context.Sites.FindAsync(shortCode);
    }

    public async Task<IEnumerable<Site>> Get()
    {
        return await _context.Sites.ToListAsync();
    }

    public async Task SaveChanges() 
        => await _context.SaveChangesAsync();
}