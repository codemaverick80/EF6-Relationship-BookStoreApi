using BookStoreApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Controllers;
[ApiController]
[Route("api/sqlquery")]
public class SqlQueryController: ControllerBase
{
    private readonly BookStoreDbContext _context;

    public SqlQueryController(BookStoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async  Task<ActionResult> Get()
    {
        int limit = 10;
       
        // var authors=await _context
        //     .Authors
        //     .FromSqlRaw("SELECT * FROM AUTHORS limit "+limit)
        //     .Include(x=>x.Books)
        //     .OrderBy(x=>x.AuthorName)
        //     .ToListAsync();
        
       var authors=await _context
           .Authors
           .FromSqlRaw("SELECT * FROM AUTHORS limit {0}",limit)
           .Include(x=>x.Books)
           .OrderBy(x=>x.AuthorName)
           .ToListAsync();
       
       
       return Ok(authors);
    }
    
    [HttpGet("{id}")]
    public async  Task<ActionResult> Get(int id)
    {
        var author=await _context
            .Authors
            .FromSqlInterpolated($"SELECT * FROM AUTHORS WHERE id={id}")
            .SingleOrDefaultAsync();
        return Ok(author);
    }
    
    
    
    #region "Safe and Unsafe SQL Queries"
    
    void ConcatenateRawSql_Unsafe()
    {
        var nameStart = "A";
        var authors = _context
            .Authors
            .FromSqlRaw("SELECT * FROM AUTHORS WHERE AuthorName LIKE '" + nameStart)
            .TagWith("Concatenated_Unsafe")
            .ToList();
    }
    void FormattedRawSql_Unsafe()
    {
        var nameStart = "A";
        // DO NOT build sql string in advance  and pass that as parameter in the FromSqlRaw method
        var sql = string.Format("SELECT * FROM AUTHORS WHERE AuthorName LIKE '{0}%'" + nameStart);
        
        var authors = _context
            .Authors
            .FromSqlRaw(sql)// DO NOT DO THIS
            .TagWith("FormattedRawSql_Unsafe")
            .ToList();
    }
    
    void FormattedRawSql_Safe()
    {
        var nameStart = "A";
       // Always put formatted sql string directly into the FromSqlRaw method
        var authors = _context
            .Authors
            .FromSqlRaw("SELECT * FROM AUTHORS WHERE AuthorName LIKE '{0}%'" + nameStart)
            .TagWith("FormattedRawSql_Safe")
            .ToList();
    }
    
    
    void StringFromInterpolated_Unsafe()
    {
        var nameStart = "A";
        // DO NOT build interpolated sql string in advance  and pass that as parameter in the FromSqlRaw method
        var sql = ($"SELECT * FROM AUTHORS WHERE AuthorName LIKE '{0}%'" + nameStart);
        
        var authors = _context
            .Authors
            .FromSqlRaw(sql)// DO NOT DO THIS
            .TagWith("StringFromInterpolated_Unsafe")
            .ToList();
    }
    
    void StringFromInterpolated_StillUnsafe()
    {
        var nameStart = "A";
       
        var authors = _context
            .Authors
            .FromSqlRaw($"SELECT * FROM AUTHORS WHERE AuthorName LIKE '{nameStart}%'")// DO NOT DO THIS
            .TagWith("StringFromInterpolated_StillUnsafe")
            .ToList();
    }
    
    void StringFromInterpolated_Safe()
    {
        var nameStart = "A";
       
        var authors = _context
            .Authors
            .FromSqlInterpolated($"SELECT * FROM AUTHORS WHERE AuthorName LIKE '{nameStart}%'")
            .TagWith("StringFromInterpolated_Unsafe")
            .ToList();
    }
    #endregion
    
}