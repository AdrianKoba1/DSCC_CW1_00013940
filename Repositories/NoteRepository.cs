using DSCC_CW1_00013940.DbContexts;
using DSCC_CW1_00013940.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NoteRepository : INoteRepository
{
    private readonly NoteContext _dbcontext;

    public NoteRepository(NoteContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<IEnumerable<Note>> GetAllNotes()
    {
        return await _dbcontext.Notes.Include(n => n.Tag).ToListAsync();
    }

    public async Task<Note> GetNoteById(int id)
    {
        return await _dbcontext.Notes.Include(n => n.Tag).FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task AddNote(Note note)
    {
        await _dbcontext.Notes.AddAsync(note);
        await _dbcontext.SaveChangesAsync();
        
    }

    public async Task UpdateNote(Note note)
    {
        _dbcontext.Entry(note).State = EntityState.Modified;
        await _dbcontext.SaveChangesAsync();
        
    }

    public async Task DeleteNote(int id)
    {
        var note = await _dbcontext.Notes.FirstOrDefaultAsync(n=> n.Id == id);
        if (note != null)
        {
            _dbcontext.Notes.Remove(note);
            await _dbcontext.SaveChangesAsync();

        }
    }
}
