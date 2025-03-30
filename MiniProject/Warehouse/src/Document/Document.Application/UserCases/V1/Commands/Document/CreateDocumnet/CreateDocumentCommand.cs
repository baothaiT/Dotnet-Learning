using Document.Application.Models.Requests;
using Document.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.UserCases.V1.Commands.Document.Create
{
    public class CreateDocumentCommand: DocumentRequest, IRequest<DocumentResponse>
    {
    }
}
