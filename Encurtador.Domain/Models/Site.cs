using Encurtador.Shared.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Encurtador.Domain.Models;
public class Site
{
    [Key]
    public string ShortCode { get; private set; } = string.Empty;
    public string UrlOrigin { get; private set; } = string.Empty;
    public long UrlAccessCount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Site() { }
    public Site(string urlOrigin)
    {
        if (string.IsNullOrEmpty(urlOrigin))
            throw new ArgumentException("A URL do site não pode ser vazia.", nameof(urlOrigin));

        UrlOrigin = urlOrigin;
        UrlAccessCount = 0;
        CreatedAt = DateTime.UtcNow;
        ShortCode = ShortCodeGenerator.GenerateFromGuid();
    }

    public void IncrementUrlAccessCount() 
        => UrlAccessCount++;
}