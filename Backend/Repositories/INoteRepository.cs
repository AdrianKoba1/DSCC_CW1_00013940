using DSCC_CW1_00013940.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAllNotes();
    Task<Note> GetNoteById(int id);
    Task AddNote(Note note);
    Task UpdateNote(Note note);
    Task DeleteNote(int id);
}
