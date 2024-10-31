using DSCC_CW1_00013940.DbContexts;
using DSCC_CW1_00013940.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TagRepository : ITagRepository
{
    private readonly NoteContext _dbcontext;

    public TagRepository(NoteContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<IEnumerable<Tag>> GetAllTags()
    {
        return await _dbcontext.Tags.ToListAsync();
    }

    public async Task<Tag> GetTagById(int id)
    {
        return await _dbcontext.Tags.FirstOrDefaultAsync(n=> n.Id == id);
    }

    public async Task AddTag(Tag tag)
    {
        await _dbcontext.Tags.AddAsync(tag);
        await _dbcontext.SaveChangesAsync();
   
    }

    public async Task UpdateTag(Tag tag)
    {
         _dbcontext.Entry(tag).State = EntityState.Modified;
        await _dbcontext.SaveChangesAsync();
 
    }

    public async Task DeleteTag(int id)
    {
        var tag = await _dbcontext.Tags.FirstOrDefaultAsync(n => n.Id == id);
        if (tag != null) 
        {
            _dbcontext.Tags.Remove(tag);
            await _dbcontext.SaveChangesAsync();


        } 
    }
}
