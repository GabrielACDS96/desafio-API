using desafio_sequence_target.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace desafio_teste
{
    public class DesafioTest
    {
        [Fact]
        public void DeveCriarDesafio()
        {
            var sequencia = new List<int>() { 1, 2, 3, 4};
            var alvo = 10;
            var desafio = new Desafio(sequencia, alvo);
            Assert.Same(sequencia, desafio.Sequencia);
            Assert.Equal(alvo, desafio.Alvo);
        }

        [Fact]
        public void DeveCriarDesafioInformandoDataCriacao()
        {
            var sequencia = new List<int>() { 1, 2, 3, 4 };
            var alvo = 10;
            var dataCriacao = new DateTime(2022, 5, 3, 21, 23, 00);
            var desafio = new Desafio(sequencia, alvo, dataCriacao);
            Assert.Same(sequencia, desafio.Sequencia);
            Assert.Equal(alvo, desafio.Alvo);
            Assert.Equal(dataCriacao, desafio.DataCriacao);
        }

        [Fact]
        public void NaoDeveCriarDesafioComSequenciaNula()
        {
            List<int> sequence = null;
            var alvo = 10;
            Assert.Throws<ArgumentException>(() => new Desafio(sequence, alvo));
        }

        [Fact]
        public void NaoDeveCriarDesafioComSequenciaVazia()
        {
            var sequence = new List<int>();
            var alvo = 10;
            Assert.Throws<ArgumentException>(() => new Desafio(sequence, alvo));
        }

        [Fact]
        public void NaoDeveCriarDesafioComSequenciaComValorMenorIgualZero()
        {
            var sequence = new List<int>() { 0 };
            var alvo = 10;
            Assert.Throws<ArgumentException>(() => new Desafio(sequence, alvo));
        }

        [Fact]
        public void NaoDeveCriarDesafioComAlvoMenorIgualZero()
        {
            var sequence = new List<int>() { 1, 2, 3, 4 };
            var alvo = 0;
            Assert.Throws<ArgumentException>(() => new Desafio(sequence, alvo));
        }

        [Theory]
        [MemberData(nameof(DesafioTest.ObterDesafiosComSolucao), MemberType = typeof(DesafioTest))]
        public void DeveSolucionarDesafio(dynamic entrada)
        {
            var sequencia = entrada.Sequence;
            var alvo = entrada.Target;
            var desafio = new Desafio(sequencia, alvo);
            Assert.Equal(alvo, desafio.Solucionar().Sum());            
        }

        [Theory]
        [MemberData(nameof(DesafioTest.ObterDesafioSemSolucao), MemberType = typeof(DesafioTest))]
        public void NaoDeveEncontrarSolucaoParaDesafio(dynamic entrada)
        {
            var sequencia = entrada.Sequence;
            var alvo = entrada.Target;
            var desafio = new Desafio(sequencia, alvo);
            Assert.Empty(desafio.Solucionar());
        }

        public static IEnumerable<object[]> ObterDesafiosComSolucao()
        {
            yield return new object[] {
                new {
                    Sequence = new List<int>() { 5, 20, 2, 1 },
                    Target = 47
                }
            };
            yield return new object[]
            {
                new {
                    Sequence = new List<int>() { 81, 27, 9, 3, 2 },
                    Target = 10
                }
            };
            yield return new object[]
            {
                new {
                    Sequence = new List<int>() { 1 },
                    Target = 10_000
                }
            };
        }
        
        public static IEnumerable<object[]> ObterDesafioSemSolucao()
        {
            yield return new object[] {
                new {
                    Sequence = new List<int>() { 10, 5 },
                    Target = 111
                }
            };
            yield return new object[]
            {
                new {
                    Sequence = new List<int>() { 2, 4, 6, 8 },
                    Target = 99
                }
            };
        }
    }
}