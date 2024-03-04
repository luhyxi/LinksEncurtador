namespace EncurtadorLinks.Models;

public class RequisicaoURL
{
    // TODO: Adicionar expirantion de request
    public RequisicaoURL(string originalURL, string shortenedURL, string code)
    {
        Id = Guid.NewGuid();
        OriginalURL = originalURL;
        ShortenedURL = shortenedURL;
        Code = code;
    }
    public Guid Id { get; private set; }
    public string? OriginalURL { get; set; }
    public string? ShortenedURL { get; private set; }
    public string? Code { get; set; }
}