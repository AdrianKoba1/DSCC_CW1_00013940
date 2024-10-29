using DSCC_CW1_00013940.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteRepository _noteRepository;

    public NotesController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    // GET: api/Notes
    [HttpGet]
    public async Task<IEnumerable<Note>> GetNotes()
    {
        return await _noteRepository.GetAllNotes(); // Fetch notes using repository
       
    }

    // GET: api/Notes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNoteById(int id)
    {
        var note = await _noteRepository.GetNoteById(id);
        if (note == null) return NotFound();
        return Ok(note);
    }

    // POST: api/Notes
    [HttpPost]
    public async Task<ActionResult<Note>> CreateNote(Note note)
    {
        await _noteRepository.AddNote(note);
        return CreatedAtAction("GetNotes", new { id = note.Id }, note);
    }

    // PUT: api/Notes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNoteById(int id, Note note)
    {
        if (id != note.Id) return BadRequest();

        await _noteRepository.UpdateNote(note);

        return NoContent();
    }

    // DELETE: api/Notes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteById(int id)
    {
        await _noteRepository.DeleteNote(id);

        return NoContent();
    }
}
