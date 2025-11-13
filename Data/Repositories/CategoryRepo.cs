using System.Data.Common;
using Core.Entities;
using Core.Interface;
using Core.Response;
using Core.ValueObjects.CategoryVO;
using Core.ValueObjects.TransactionsVO;
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

    public async  Task Putasync(int id,Category category)
    {
        try
        {
           await _context.Categories.FirstOrDefaultAsync(x => x.Id == new CategoryId(id));
             _context.Update(category);
            await _context.SaveChangesAsync();
            
        }
        catch (DbException e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<Category?> GetById(int id)
    {
        try
        {
            return await _context.Categories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == new CategoryId(id));
        }
        catch (DbException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<PagedResponse<List<Category?>>> GetAll(Id category)
    {
        try
        {
            var query =
                _context
                    .Categories
                    .AsNoTracking()
                    .Where(x => x.Id.Value == category.Value)
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