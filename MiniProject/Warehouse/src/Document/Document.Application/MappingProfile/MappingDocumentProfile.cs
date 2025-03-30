using AutoMapper;
using Document.Application.Models.Requests;
using Document.Application.Models.Responses;
using Document.Domain.Entities;

namespace Document.Application.MappingProfile;

public class MappingDocumentProfile : Profile
{
    public MappingDocumentProfile()
    {
       
        CreateMap<DocumentEntity, DocumentResponse>(); // Mapping from Product -> ProductDto
        //CreateMap<List<DocumentEntity>, List<DocumentResponse>>();
        CreateMap<DocumentRequest, DocumentEntity>(); // Optional: DTO -> Entity
    }
}
