using Document.Application.Models.Responses;
using MediatR;
using Shared.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.UserCases.V1.Queries.Document.GetAllDocument;

public class GetAllDocumentQuery : IRequest<ApiSuccessFul<List<DocumentResponse>>>
{
}
