﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HL.MyAirport.EF;

namespace MyAirportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagagesController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public BagagesController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Bagages
        /// <summary>
        /// Selectionne l'ensemble des bagages de manière asynchrome
        /// </summary>
        /// <returns> un objet task qui contient un ActionResut qui lui meme contient une liste de bagage</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bagage>>> GetBagages()
        {
            return await _context.Bagages.ToListAsync();
        }


        // GET: api/Bagages/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("{id}")]
        public async Task<ActionResult<Bagage>> GetBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);

            if (bagage == null)
            {
                return NotFound();
            }

            return bagage;
        }

        // PUT: api/Bagages/5
        /// <summary>
        /// Méthode permettant la modif d'un bagage
        /// </summary>
        /// <param name="id"> Identifiant du bagage a modifier</param>
        /// <param name="bagage">Nouvellle valeur à remplacer sans le bagage</param>
        /// <returns></returns>
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagage(int id, Bagage bagage)
        {
            if (id != bagage.BagageId)
            {
                return BadRequest();
            }

            _context.Entry(bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(id))
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

        // POST: api/Bagages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bagage>> PostBagage(Bagage bagage)
        {
            _context.Bagages.Add(bagage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagage", new { id = bagage.BagageId }, bagage);
        }

        // DELETE: api/Bagages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bagage>> DeleteBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);
            if (bagage == null)
            {
                return NotFound();
            }

            _context.Bagages.Remove(bagage);
            await _context.SaveChangesAsync();

            return bagage;
        }

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageId == id);
        }
    }
}
