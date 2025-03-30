using Document.Domain.Abstractions;
using Document.Persistence.Repositories;

namespace Document.API.Extensions;

public static class ServiceExtension
{
    public static void AddService(this IServiceCollection service)
    {
        service.AddScoped<IDocumentRepository, DocumentRepository>();
    }
}
