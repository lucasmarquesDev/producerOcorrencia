using FluentValidation.TestHelper;
using Template.Domain.Entities;
using Template.UnitTests.Validations;

namespace Template.UnitTests
{
    public class OcorrenciaTest
    {
        private readonly OcorrenciaValidator validator;

        public OcorrenciaTest()
        {
            validator = new OcorrenciaValidator();
        }

        #region EnderecoCompleto

        [Theory]
        [InlineData("Teste ende 1", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        public void Titulo_Valida_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtExclusaoConvert = Convert.ToDateTime(dtExclusao);

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusaoConvert
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.EnderecoCompleto);
        }

        [Theory]
        [InlineData("", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("123456789012345678900", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        public void Titulo_Valida_ReturnsFalse(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtExclusaoConvert = Convert.ToDateTime(dtExclusao);

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusaoConvert
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.EnderecoCompleto);
        }

        #endregion

        #region QuantidadeVolumes

        [Theory]

        [InlineData("Teste ende 1", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        public void QuantidadeVolume_Valida_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtExclusaoConvert = Convert.ToDateTime(dtExclusao);

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusaoConvert
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.QuantidadeVolumes);
        }

        [Theory]
        [InlineData("Teste ende 1", 0, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("Teste ende 1", null, "27/11/2023", "26/11/2023", "28/11/2023")]
        public void QuantidadeVolume_Valida_ReturnsFalse(string enderecoCompleto, int? quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtExclusaoConvert = Convert.ToDateTime(dtExclusao);

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusaoConvert
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.QuantidadeVolumes);
        }

        #endregion

        #region DataCriacao

        [Theory]

        [InlineData("Teste ende 1", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        public void DataCriacao_Valida_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtExclusaoConvert = Convert.ToDateTime(dtExclusao);

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusaoConvert
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.DtCriacao);
        }

        [Theory]
        [InlineData("Teste ende 1", 1, "27/11/2023", null, "28/11/2023")]
        public void DataCriacao_Valida_ReturnsFalse(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);
            var dtExclusaoConvert = Convert.ToDateTime(dtExclusao);

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = null,
                DtExclusao = dtExclusaoConvert
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.DtCriacao);
        }

        #endregion
    }
}