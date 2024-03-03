using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PocBTG.Models;
using PocBTG;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using PocBTG.Base;
using System.Threading.Tasks;

namespace KnightsTour.Controllers
{
    [ApiController]
    [Route("api/Knights")]
    public class KnightsController : ControllerBase
    {
        private readonly KnightContext _context;

        public KnightsController(KnightContext context)
        {
            _context = context;
        }

        // GET: api/Knights
        [HttpGet("GetAllKnights")]
        public async Task<ActionResult<List<KnightsDto>>> GetAllKnights()
        {
            gerarbase();

            var knightsDto = (await _context.KnightItens
                .Include(knight => knight.Weapons)
                .Include(knight => knight.Attributes).ToListAsync())
                .Select(KnightsDto.FromKnight).ToList();
            
            return Ok(knightsDto);
            
        }
        // metodo para gerar base de dados
        private void gerarbase()
        {
            List<Knight> knights = new List<Knight>();
            knights.Add(new Knight
            {
                Id = 1,
                Name = "Arthur",
                Nickname = "The King",
                Birthday = new System.DateTime(2020, 1, 1),
                Weapons = new List<Weapon>
                {
                    new Weapon { Name = "Excalibur",
                        Attr = "Strength",
                        Mod = 5,
                        Equipped = true}
                },
                Attributes = new Attributes
                {
                    Strength = 10,
                    Dexterity = 15,
                    Constitution = 10,
                    Intelligence = 5,
                    Wisdom = 20,
                    Charisma = 3
                }
                ,
                KeyAttribute = "Strength"
            });
            knights.Add(new Knight
            {
                Id = 2,
                Name = "Lancelot",
                Nickname = "The Brave",
                Birthday = new System.DateTime(2010, 1, 1),
                Weapons = new List<Weapon>
                {
                    new Weapon { Name = "Sword",
                        Attr = "strength",
                        Mod = 3,
                        Equipped = true}
                },
                Attributes = new Attributes
                {
                    Strength = 10,
                    Dexterity = 15,
                    Constitution = 10,
                    Intelligence = 5,
                    Wisdom = 20,
                    Charisma = 3
                },
                KeyAttribute = "Strength"
            });
            _context.KnightItens.Add(knights[0]);
            _context.KnightItens.Add(knights[1]);
            _context.SaveChangesAsync();
        }
        // PUT: api/Knights/5
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> PutKnight(long id, Knight knight)
        {
            var knightold = await _context.KnightItens.FindAsync(id);
            if (knight == null)
            {
                return NotFound();
            }
            knightold.Nickname = knight.Nickname;

            if (id != knightold.Id)
            {
                return BadRequest();
            }

            _context.Entry(knightold).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // DELETE: api/Knights/5
        private bool KnightExists(long id)
        {
            return _context.KnightItens.Any(e => e.Id == id);
        }
        // GET: api/Knights
        [HttpGet("ListHeroes")]
        public async Task<ActionResult<List<KnightsDto>>> GetHeroKnights()
        {
            var knightsDto = (await _context.KnightItens
               .Include(knight => knight.Weapons)
               .Include(knight => knight.Attributes)
               .Where(knight => knight.Birthday.Year < DateTime.Today.AddYears(-15).Year)
               .ToListAsync())
               .Select(KnightsDto.FromKnight).ToList();

            return Ok(knightsDto);
        }
        // POST: api/Knights
        [HttpPost("Create")]
        public async Task<ActionResult<Knight>> PostKnight(Knight knight)
        {
            _context.KnightItens.Add(knight);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKnightById), new { id = knight.Id }, knight);
        }
        // GET: api/Knights/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetKnightById(int id)
        {
            var knight = await _context.KnightItens
                .Include(knight => knight.Weapons)
                .Include(knight => knight.Attributes)
                .FirstOrDefaultAsync();
            if (knight == null)
            {
                return NotFound();
            }
            return Ok(knight);
        }
        // GET: api/Knights/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteKnight(long id)
        {
            var knight = await _context.KnightItens.FindAsync(id);
            if (knight == null)
            {
                return NotFound();
            }

            _context.KnightItens.Remove(knight);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
