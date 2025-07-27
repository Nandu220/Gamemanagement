using GameManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ Route ("api/[Controller]")]
[ApiController] 
public class GamesController : ControllerBase
{
    private readonly AppDbContext _context;

    public GamesController(AppDbContext context)
    {
        _context = context;
    }

    // GET /games
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    {
        return await _context.Games.ToListAsync();
    }

    // GET /games/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
            return NotFound();
        return game;
    }

    // POST /games
    [HttpPost]
    public async Task<ActionResult<Game>> CreateGame(Game game)
    {
        game.CreatedAt = DateTime.Now;
        game.UpdatedAt = DateTime.Now;
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
    }

    // PUT /games/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGame(int id, Game game)
    {
        if (id != game.Id)
            return BadRequest();

        var existingGame = await _context.Games.FindAsync(id);
        if (existingGame == null)
            return NotFound();

        existingGame.Name = game.Name;
        existingGame.Description = game.Description;
        existingGame.Image = game.Image;
        existingGame.Genre = game.Genre;
        existingGame.Status = game.Status;
        existingGame.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /games/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null)
            return NotFound();

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

