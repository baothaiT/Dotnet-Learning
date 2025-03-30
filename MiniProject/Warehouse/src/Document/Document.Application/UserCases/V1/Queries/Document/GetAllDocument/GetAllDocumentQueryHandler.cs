using AutoMapper;
using Document.Application.Models.Responses;
using Document.Application.UserCases.V1.Commands.Document.Create;
using Document.Domain.Abstractions;
using MediatR;
using Shared.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.UserCases.V1.Queries.Document.GetAllDocument;

public class GetAllDocumentQueryHandler : IRequestHandler<GetAllDocumentQuery, ApiSuccessFul<List<DocumentResponse>>>
{
    private readonly IDocumentRepository _repository;
    private readonly IMapper _mapper;
    public GetAllDocumentQueryHandler(
        IDocumentRepository repository, 
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }
    public async Task<ApiSuccessFul<List<DocumentResponse>>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken)
    {
        
        var responseDb = await _repository.GetAll();
        List<DocumentResponse> documentResponses = _mapper.Map<List<DocumentResponse>>(responseDb);
        return new ApiSuccessFul<List<DocumentResponse>>(documentResponses);
    }
}
