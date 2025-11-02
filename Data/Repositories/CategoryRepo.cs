using System.Data.Common;
using Core.Entities;
using Core.Interface;
using Core.Response;
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

    public async Task<PagedResponse<List<Category?>>> GetAll(Category category)
    {
        try
        {
            var query =
                _context
                    .Categories
                    .AsNoTracking()
                    .Where(x => x.Id.Value == category.Id.Value)
                    .OrderBy(x => x.Name);

            var categories =
                await
                _context
                    .Categories
                    .Take((Core.Configs.Configuration.CurrentPage - 1) * Core.Configs.Configuration.PageSize)
                    .Skip(Core.Configs.Configuration.PageSize)
                    .ToListAsync();

            var count =
                await 
                _context
                    .Categories
                    .CountAsync();

            return new PagedResponse<List<Category?>>(categories, count,
                Core.Configs.Configuration.CurrentPage,
                Core.Configs.Configuration.PageSize);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}