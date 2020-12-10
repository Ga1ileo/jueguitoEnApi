using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using jueguitoEnApi.DAL;
using jueguitoEnApi.Models;
using Microsoft.EntityFrameworkCore;

namespace jueguitoEnApi.BLL
{
    public class JugadorBLL
    {
        private readonly Contexto _contexto;

        public JugadorBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Guardar(Jugador jugador)
        {
            if (!await Existe(jugador.JugadorId))
                return await Insertar(jugador);
            else
                return await Modificar(jugador);
        }

        public async Task<bool> Insertar(Jugador jugador)
        {
            bool paso = false;

            try
            {
                _contexto.Jugadores.Add(jugador);
                paso = await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public async Task<bool> Modificar(Jugador jugador)
        {
            bool paso = false;


            try
            {
                _contexto.Entry(jugador).State = EntityState.Modified;

                paso = await _contexto.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public async Task<bool> Existe(int id)
        {
            bool encontrado = false;

            try
            {
                encontrado = await _contexto.Jugadores.AnyAsync(v => v.JugadorId == id);
            }
            catch (Exception)
            {
                throw;
            }

            return encontrado;
        }

        public List<Jugador> GetJugadores(Expression<Func<Jugador, bool>> jugadores)
        {
            List<Jugador> Lista = new List<Jugador>();

            try
            {
                Lista = _contexto.Jugadores.Where(jugadores).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}
