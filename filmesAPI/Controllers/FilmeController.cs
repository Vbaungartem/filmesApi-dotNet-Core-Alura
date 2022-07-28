using AutoMapper;
using filmesAPI.Data;
using filmesAPI.Data.Dtos;
using filmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListALlFilmes), new
            {
                Id = filme.Id
            }, filme);
        }
        [HttpGet]
        public IEnumerable<Filme> ListALlFilmes()
        {
            return _context.Filmes;
        }
        [HttpGet("{id}")]
        public IActionResult RecuperarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDTO = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDTO);
            }
            return NotFound(filme);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDto filmeDTO)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDTO, filme);

            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {   
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
