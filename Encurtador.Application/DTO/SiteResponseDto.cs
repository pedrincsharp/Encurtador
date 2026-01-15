using System;
using System.Collections.Generic;
using System.Text;

namespace Encurtador.Application.DTO;

public record SiteResponseDto
{
    public string ShortCode { get; set; } = string.Empty;
    public string UrlOrigin { get; set; } = string.Empty;
    public long UrlAccessCount { get; set; }
    public DateTime CreatedAt { get; set; }
}
