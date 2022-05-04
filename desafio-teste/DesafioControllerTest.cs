using desafio_sequence_target.Classes;
using desafio_sequence_target.Controllers;
using desafio_sequence_target.Data;
using desafio_sequence_target.InputModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace desafio_teste
{
    public class DesafioControllerTest
    {

        [Fact]
        public void DeveAdicionarUmDesafio() {
            var options = new DbContextOptionsBuilder<DesafioContext>()
                                .UseInMemoryDatabase("DeveAdicionarUmDesafio")
                                .Options;
            var desafioContext = new DesafioContext(options);
            var desafioRepository = new DesafioRepository(desafioContext);
            var desafioController = new DesafioController(desafioRepository);
            var desafioInputModel = new DesafioInputModel()
            {
                Sequence = new List<int>() { 1, 2, 3, 4, 5},
                Target = 10
            };
            desafioController.Post(desafioInputModel);
            var desafios = desafioRepository.Obter(null,  null);
            Assert.Single(desafios);
        }

        [Fact]
        public void DeveListarDesafios()
        {
            var options = new DbContextOptionsBuilder<DesafioContext>()
                                .UseInMemoryDatabase("DeveListarDesafios")
                                .Options;
            var desafioContext = new DesafioContext(options);
            var desafioRepository = new DesafioRepository(desafioContext);
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 1)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 2)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 3)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 4)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 5)));
            var desafioController = new DesafioController(desafioRepository);
            var desafios = desafioController.Get(null, null);
            Assert.Equal(5, desafios.Count);
        }

        [Fact]
        public void DeveListarDesafiosCriadosDepoisDataInicial()
        {
            var options = new DbContextOptionsBuilder<DesafioContext>()
                                .UseInMemoryDatabase("DeveListarDesafiosCriadosDepoisDataInicial")
                                .Options;
            var desafioContext = new DesafioContext(options);
            var desafioRepository = new DesafioRepository(desafioContext);
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 1)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 2)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 3)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 4)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 5)));
            var desafioController = new DesafioController(desafioRepository);
            var desafios = desafioController.Get(new DateTime(2022, 5, 3), null);
            Assert.Equal(3, desafios.Count);
        }

        [Fact]
        public void DeveListarDesafiosCriadosAntesDataFinal()
        {
            var options = new DbContextOptionsBuilder<DesafioContext>()
                                .UseInMemoryDatabase("DeveListarDesafiosCriadosAntesDataFinal")
                                .Options;
            var desafioContext = new DesafioContext(options);
            var desafioRepository = new DesafioRepository(desafioContext);
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 1)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 2)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 3)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 4)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 5)));
            var desafioController = new DesafioController(desafioRepository);
            var desafios = desafioController.Get(null, new DateTime(2022, 5, 2));
            Assert.Equal(2, desafios.Count);
        }

        [Fact]
        public void DeveListarDesafiosCriadosEntreDataInicialDataFinal()
        {
            var options = new DbContextOptionsBuilder<DesafioContext>()
                                .UseInMemoryDatabase("DeveListarDesafiosCriadosEntreDataInicialDataFinal")
                                .Options;
            var desafioContext = new DesafioContext(options);
            var desafioRepository = new DesafioRepository(desafioContext);
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 1)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 2)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 3)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 4)));
            desafioRepository.Adicionar(new Desafio(new List<int>() { 1, 2, 3 }, 10, new DateTime(2022, 5, 5)));
            var desafioController = new DesafioController(desafioRepository);
            var desafios = desafioController.Get(new DateTime(2022, 5, 2), new DateTime(2022, 5, 4));
            Assert.Equal(3, desafios.Count);
        }
    }
}
