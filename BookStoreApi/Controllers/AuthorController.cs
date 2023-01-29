using BookStoreApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/author")]
public class AuthorController:ControllerBase
{
    private readonly BookStoreDbContext _context;

    public AuthorController(BookStoreDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        // var authors = await _context.Authors
        //     .Include(x => x.Books)
        //     .ToListAsync();
       
        var authors = await _context
            .Authors
            .Select(a=> new
            {
               a.Id,
               a.AuthorName,
               books =a.Books
                   .Select(b=> new
                   {
                       b.BookId,
                       b.Book.Title,
                       b.Book.Isbn
                       
                   })
            })
            .ToListAsync();
            
        // var authors = await _context
        //     .Authors
        //     .Select(a=> new
        //     {
        //         a.Id,
        //         a.AuthorName,
        //         books =string.Join(", ", a.Books.Select(b=> b.BookId))
        //     })
        //     .ToListAsync();
    
        return Ok(authors);

    }
    
    [HttpPost("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var author = await _context
            .Authors.Where(x=>x.Id==id)
            .Select(b => new
            { 
                b.Id,
                b.AuthorName,
                books =b.Books.Select(x=>x.Book.Title)
            })
            .SingleOrDefaultAsync();

        
        //
        // var author = await _context
        //     .Authors.Where(x=>x.Id==id)
        //     .Select(b => new
        //     { 
        //         b.Id,
        //         b.AuthorName,
        //         books =b.Books
        //             .Select(x=> new
        //             {
        //                 x.BookId,
        //                 x.Book.Title,
        //                 x.Book.Isbn
        //                
        //             })
        //     })
        //     .SingleOrDefaultAsync();
        
        
        
        
        
        // var author = await _context
        //     .Authors.Where(x=>x.Id==id)
        //     .Select(b => new
        //     { 
        //         b.Id,
        //         b.AuthorName,
        //         books=string.Join(", ", b.Books.Select(s=>s.Book.Title))
        //     })
        //     .SingleOrDefaultAsync();
        
        return Ok(author);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remove(int id)
    {
        var author = await _context.Authors
            .Include(x => x.Books)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        
        if (author != null)
        {
             _context.Remove(author);
            await _context.SaveChangesAsync();
        }
        return Ok();
    }
    
}