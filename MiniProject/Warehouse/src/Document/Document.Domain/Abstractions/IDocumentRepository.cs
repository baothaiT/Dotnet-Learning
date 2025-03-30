using Document.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Domain.Abstractions;

public interface IDocumentRepository
{
    Task<IEnumerable<DocumentEntity>> GetAll();
}
