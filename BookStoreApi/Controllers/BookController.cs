using BookStoreApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers;
[ApiController]
[Route("api/book")]
public class BookController:ControllerBase
{
    
    private readonly BookStoreDbContext _context;

    public BookController(BookStoreDbContext context)
    {
        _context = context;
    }
    
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        
        // var books = await _context.Books
        //     .Include(x => x.Authors)
        //     .ToListAsync();
        
        var book = await _context
            .Books
            .Select(b => new
            {
                b.Id,
                b.Title,
                authors = b.Authors
                    .Select(s => s.Author.AuthorName)
            }).ToListAsync();
        
        // var book = await _context
        //     .Books
        //     .Select(b => new
        //     {
        //         b.Id,
        //         b.Title,
        //         authors =string.Join(", ", b.Authors.Select(s => s.Author.AuthorName))
        //     }).ToListAsync();

        return Ok(book);

    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var book = await _context
            .Books.Where(x=>x.Id==id)
            .Select(b => new
            { 
                b.Id,
                b.Title,
                authors=b.Authors.Select(s=>s.Author.AuthorName)
            })
            .SingleOrDefaultAsync();
      
        // var book = await _context
        //     .Books.Where(x=>x.Id==id)
        //     .Select(b => new
        //     { 
        //         b.Id,
        //         b.Title,
        //         authors=string.Join(", ", b.Authors.Select(s=>s.Author.AuthorName))
        //     })
        //     .SingleOrDefaultAsync();
        
        return Ok(book);

    }
}