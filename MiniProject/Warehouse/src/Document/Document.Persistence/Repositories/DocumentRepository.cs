using Document.Domain.Abstractions;
using Document.Domain.Entities;
using Document.Persistence.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Persistence.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly AppDbContext _context;

    public DocumentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DocumentEntity>> GetAll()
    {
        return await _context.DocumentTable.ToListAsync();
    }

}
