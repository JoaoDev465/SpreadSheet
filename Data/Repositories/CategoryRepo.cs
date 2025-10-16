using System.Data.Common;
using Core.Entities;
using Core.Interface;
using Core.ValueObjects.CategoryVO;
using Data.DB;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CategoryRepo : ICategoryRepo
{
    private readonly Context _context;
    public CategoryRepo(Context context)
    {
        _context = context;
    }
    public async  Task AddAsync(Category category)
    {
        try
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async  Task Putasync(Category category)
    {
        try
        {
            await _context.Categories.FirstAsync(x => x.Id.Value == category.Id.Value);
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        catch (DbException e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<Category?> GetById(Id id)
    {
        try
        {
            return await _context.Categories.AsNoTracking()
                .FirstAsync(x => x.Id.Value == id.Value);
        }
        catch (DbException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Category?>> GetAll()
    {
        try
        {
            return await _context.Categories.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}