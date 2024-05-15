﻿using Microsoft.EntityFrameworkCore;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Mappers;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;
using TorneoTenis.API.Repository;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Models.Response.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TorneoTenis.API.Services
{
    public class TorneoService : ITorneoService
    {
        private readonly TorneoTenisContext _torneoTenisContext;

        public TorneoService(TorneoTenisContext torneoTenisContex)
        {
            _torneoTenisContext = torneoTenisContex;
        }

        public async Task AgregarTorneo(TorneoRequest nuevoTorneo)
        {
            var potencialTorneoDuplicado = await _torneoTenisContext.Set<Torneo>()
                                            .Where(a => a.Nombre == nuevoTorneo.Nombre)
                                            .Where(a => a.Anio == nuevoTorneo.Anio)
                                            .FirstOrDefaultAsync();

            if (potencialTorneoDuplicado != null)
                throw new Exception("Este Torneo ya esta registrado");

            var nuevoTorneoAAgregar = nuevoTorneo.ToTorneo();

            _torneoTenisContext.Add(nuevoTorneoAAgregar);

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<TorneoResponse> BuscarTorneo(int id)
        {

            // ESTO SE DEBE PASAR A UN SERVICIO BUSCAR_TORNEO_POR_ID:

            var TorneoEspecífico = await _torneoTenisContext.Set<Torneo>()
                                    .Where(a =>a.Id == id).FirstOrDefaultAsync();

            if (TorneoEspecífico == null || TorneoEspecífico.Eliminado) 
                throw new Exception("El torneo no se encuentra");
            // fin

            var response = TorneoEspecífico.ToTorneoResponse();

            return response;
            
        }


        public async Task ActualizarTorneo(int id,TorneoRequest TorneoActualizado)
        {

            var torneoExistente = await _torneoTenisContext.Set<Torneo>()
                        .Where(a => a.Id == id).FirstOrDefaultAsync();

            if (torneoExistente == null || torneoExistente.Eliminado)
            {
                throw new Exception("El torneo no se encuentra");
            }

            torneoExistente.ToTorneoUpdate(TorneoActualizado);

            await _torneoTenisContext.SaveChangesAsync();
        }

        public async Task EliminarTorneo(int id)
        {

            var torneoExistente = await _torneoTenisContext.Set<Torneo>()
                        .Where(a => a.Id == id).FirstOrDefaultAsync();

            if (torneoExistente == null || torneoExistente.Eliminado)
            {
                throw new Exception("El torneo no se encuentra");
            }

            torneoExistente.ToTorneoDelete();

            await _torneoTenisContext.SaveChangesAsync();
        }


        public async Task<List<TorneoResponse>> BuscarTorneos()
        {

            var Torneoes = await _torneoTenisContext.Set<Torneo>()
                                            .Where(a =>a.Eliminado == false).ToListAsync();

            var response = Torneoes.Select(j => j.ToTorneoResponse()).ToList();
            
            return response;

        }

        public async Task AgregarTorneoCompleto(TorneoCompletoRequest torneoCompleto)
        {
            var potencialTorneoDuplicado = await _torneoTenisContext.Set<Torneo>()
                                            .Where(a => a.Nombre == torneoCompleto.NuevoTorneo.Nombre)
                                            .Where(a => a.Anio == torneoCompleto.NuevoTorneo.Anio)
                                            .FirstOrDefaultAsync();


            if (potencialTorneoDuplicado != null)
                throw new Exception("Este Torneo ya esta registrado");

            var nuevoTorneoAAgregar = torneoCompleto.ToTorneoCompleto();

            _torneoTenisContext.Add(nuevoTorneoAAgregar);

            await _torneoTenisContext.SaveChangesAsync();

            var Torneo = await _torneoTenisContext.Set<Torneo>()
                                            .Where(a => a.Nombre == torneoCompleto.NuevoTorneo.Nombre)
                                            .Where(a => a.Anio == torneoCompleto.NuevoTorneo.Anio)
                                            .FirstOrDefaultAsync();
            var IdTorneo = Torneo.Id;


            var jugadorService = new JugadorService(_torneoTenisContext);
            var partidoService = new PartidoService(_torneoTenisContext);

            List<Jugador> JugadoresDelTorneo = new List<Jugador>();

            var Count = 0;

            foreach (var i in torneoCompleto.Jugadores)
            {
                Count += 1;
                var JugadorEspecífico = await _torneoTenisContext.Set<Jugador>()
                                    .Where(a => a.Nombre == i.Nombre && a.Apellido == i.Apellido)
                                    .FirstOrDefaultAsync();

                JugadoresDelTorneo.Add(JugadorEspecífico);


            }

            partidoService.AgregarPartido(new PartidoRequest
            {
                Etapa = 3,
                Anio = 2024,
                Mes = 1,
                Dia = 2,
                IdGanador = 2,
                IdPerdedor = 1,
                IdTorneo = IdTorneo,
                DescripcionGanador = "string"
            });

            

            //    "etapa": 1,
            //      "anio": 2024,
            //      "mes": 0,
            //      "dia": 0,
            //      "idGanador": 0,
            //      "idPerdedor": 0,
            //      "idTorneo": 0,
            //      "descripcionGanador": "string"
            //});

            //Etapa = 1;
            //{

            //    }



            Console.WriteLine(torneoCompleto.Jugadores[0].Nombre);
            Console.WriteLine(torneoCompleto.Jugadores[0].Apellido);
            Console.WriteLine(torneoCompleto.Jugadores[1].Nombre);
            Console.WriteLine(torneoCompleto.Jugadores[1].Apellido);

        }


        public async Task AgregarTorneoCompletoTest(List<JugadorDTO> jugadores)
        { 

            Console.WriteLine("hola");


            await _torneoTenisContext.SaveChangesAsync();
        }



        //private readonly TorneoTenisContext _TorneoTenisContext;
        //public List<TorneoWithTorneoResponse> GetAllTorneoWithTorneo(string torneo)
        //{
        //throw new NotImplementedException();
        //}

    }
}
