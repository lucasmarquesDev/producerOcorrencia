using Microsoft.AspNetCore.Http.HttpResults;
using Template.Domain.Entities;
using Template.IntegrationTests.Helpers;
using Template.IntegrationTests.MapperEndpoint;

namespace Template.IntegrationTests
{
    public class OcorrenciaTest
    {
        [Theory]
        [InlineData("Teste endereco completo 1", 1, "28/11/2023", "27/11/2023", "29/11/2023")]
        public async void AddOcorrencia_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtExclusaoConvert = Convert.ToDateTime(dtExclusao);

            // Arrange
            var ocorrencia = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusaoConvert
            };

            await using var context = new MockOcorrenciaDb().CreateDbContext();

            // Act
            var result = OcorrenciaEndpoints.AddOcorrencia(ocorrencia, context);

            // Assert
            Assert.IsType<Created<Ocorrencia>>(result);
            Assert.NotNull(ocorrencia);
            Assert.NotNull(ocorrencia.EnderecoCompleto);
            Assert.NotNull(ocorrencia.QuantidadeVolumes);
            Assert.NotNull(ocorrencia.DtAtualizacao);
            Assert.NotNull(ocorrencia.DtCriacao);
            Assert.NotNull(ocorrencia.DtExclusao);

            Assert.Collection(context.Ocorrencia, ocorrencia =>
            {
                Assert.Equal(enderecoCompleto, ocorrencia.EnderecoCompleto);
                Assert.Equal(quantidadeVolumes, ocorrencia.QuantidadeVolumes);
                Assert.Equal(dtAtualizacaoConvert, ocorrencia.DtAtualizacao);
                Assert.Equal(dtCriacaoConvert, ocorrencia.DtCriacao);
                Assert.Equal(dtExclusaoConvert, ocorrencia.DtExclusao);
            });
        }

        [Theory]
        [InlineData(1)]
        public async Task GetOcorrenciaById_ReturnsNotFoundIfNotExists(int idNoticia)
        {
            // Arrange
            await using var context = new MockOcorrenciaDb().CreateDbContext();

            // Act
            var result = await OcorrenciaEndpoints.GetById(idNoticia, context);

            // Assert
            Assert.IsType<Results<Ok<Ocorrencia>, NotFound>>(result);

            var notFoundResult = (NotFound)result.Result;

            Assert.NotNull(notFoundResult);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetOcorrenciaById_ReturnsOcorrenciaFromDatabase(int idOcorrencia)
        {
            // Arrange
            await using var context = new MockOcorrenciaDb().CreateDbContext();

            context.Ocorrencia.Add(
                new Ocorrencia
                {
                    Id = 1,
                    EnderecoCompleto = "Teste endereco completo 1",
                    QuantidadeVolumes = 1,
                    DtAtualizacao = Convert.ToDateTime("2023-11-28").Date,
                    DtCriacao = Convert.ToDateTime("2023-11-27").Date,
                    DtExclusao = Convert.ToDateTime("2023-11-29").Date,
                });

            await context.SaveChangesAsync();

            // Act
            var result = await OcorrenciaEndpoints.GetById(idOcorrencia, context);

            //Assert
            Assert.IsType<Results<Ok<Ocorrencia>, NotFound>>(result);

            var okResult = (Ok<Ocorrencia>)result.Result;

            Assert.NotNull(okResult.Value);
            Assert.Equal(idOcorrencia, okResult.Value.Id);
        }

        [Fact]
        public async Task GetAll_ReturnsOcorrenciaFromDataBase()
        {
            // Arrange
            await using var context = new MockOcorrenciaDb().CreateDbContext();

            context.Ocorrencia.Add(
                new Ocorrencia
                {
                    Id = 1,
                    EnderecoCompleto = "Teste endereco completo 1",
                    QuantidadeVolumes = 1,
                    DtAtualizacao = Convert.ToDateTime("2023-11-28").Date,
                    DtCriacao = Convert.ToDateTime("2023-11-27").Date,
                    DtExclusao = Convert.ToDateTime("2023-11-29").Date,
                });

            context.Ocorrencia.Add(
               new Ocorrencia
               {
                   Id = 2,
                   EnderecoCompleto = "Teste endereco completo 2",
                   QuantidadeVolumes = 2,
                   DtAtualizacao = Convert.ToDateTime("2023-11-28").Date,
                   DtCriacao = Convert.ToDateTime("2023-11-27").Date,
                   DtExclusao = Convert.ToDateTime("2023-11-29").Date,
               });

            await context.SaveChangesAsync();

            // Act
            var result = await OcorrenciaEndpoints.GetAll(context);

            // Assert
            Assert.IsType<Ok<Ocorrencia[]>>(result);

            Assert.NotNull(result.Value);
            Assert.NotEmpty(result.Value);
            Assert.Collection(result.Value, ocorrencia1 =>
            {
                Assert.Equal(1, ocorrencia1.Id);
                Assert.Equal("Teste endereco completo 1", ocorrencia1.EnderecoCompleto);
                Assert.Equal(1, ocorrencia1.QuantidadeVolumes);
                Assert.Equal(Convert.ToDateTime("2023-11-28").Date, ocorrencia1.DtAtualizacao);
                Assert.Equal(Convert.ToDateTime("2023-11-27").Date, ocorrencia1.DtCriacao);
                Assert.Equal(Convert.ToDateTime("2023-11-29").Date, ocorrencia1.DtExclusao);
            }, ocorrencia2 =>
            {
                Assert.Equal(2, ocorrencia2.Id);
                Assert.Equal("Teste endereco completo 2", ocorrencia2.EnderecoCompleto);
                Assert.Equal(2, ocorrencia2.QuantidadeVolumes);
                Assert.Equal(Convert.ToDateTime("2023-11-28").Date, ocorrencia2.DtAtualizacao);
                Assert.Equal(Convert.ToDateTime("2023-11-27").Date, ocorrencia2.DtCriacao);
                Assert.Equal(Convert.ToDateTime("2023-11-29").Date, ocorrencia2.DtExclusao);
            });
        }
    }
}