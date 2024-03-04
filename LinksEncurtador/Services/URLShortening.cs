using LinksEncurtador.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AppDbContext")]


namespace EncurtadorLinks.Services; 
public class URLShortening
{
    internal const int MAX_CHARS_BY_URL = 7;
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
    private readonly int AlphabetLength = Alphabet.Length;
    private readonly Random _random = new Random();

    private readonly AppDbContext _context;

    public URLShortening(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<string> GenerateURL()
    {
        var codeChars = new char[MAX_CHARS_BY_URL];

        while (true)
        {
            for (var i = 0; i < MAX_CHARS_BY_URL; i++)
            {
                var randomIndex = _random.Next(AlphabetLength  - 1);
                codeChars[i] = Alphabet[randomIndex];
            }
            var code = new string(codeChars);

            if (!await _context.URLsEncurtadas.AnyAsync(s => s.Code == code))
            {
                return code;
            }
        }
    }
}
