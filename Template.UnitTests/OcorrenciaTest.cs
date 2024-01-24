using FluentValidation.TestHelper;
using Template.Domain.Entities;
using Template.Validate.Validations;

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
        [InlineData("Rua", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("Rua 1", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("upelkgzbkykhptrbsfcjvwxkjctvdq", 1, "27/11/2023", "26/11/2023", "28/11/2023")]
        public void Endereco_Valida_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
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
        [InlineData("", 0, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("Av", 0, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("upelkgzbkykhptrbsfcjvwxkjctvdqvutmzevujfpyojadvufrulnpa", 0, "27/11/2023", "26/11/2023", "28/11/2023")]
        public void Endereco_Valida_ReturnsFalse(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
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
        [InlineData("Teste ende 1", 5, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("Teste ende 1", 10, "27/11/2023", "26/11/2023", "28/11/2023")]
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
        [InlineData("Teste ende 1", null, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("Teste ende 1", 0, "27/11/2023", "26/11/2023", "28/11/2023")]
        [InlineData("Teste ende 1", 11, "27/11/2023", "26/11/2023", "28/11/2023")]
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
        [InlineData("Teste ende 1", 1, "", "27/11/2023", "")]
        public void DataCriacao_Valida_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);

            if (DateTime.Compare(DateTime.Today.Date, dtCriacaoConvert.Date) > 0)
                dtCriacaoConvert = DateTime.Today.Date;

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacao != string.Empty ? Convert.ToDateTime(dtAtualizacao) : null,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusao != string.Empty ? Convert.ToDateTime(dtExclusao) : null
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.DtCriacao);
        }

        [Theory]
        [InlineData("Teste ende 1", 1, "", "", "")]
        [InlineData("Teste ende 1", 1, "", "05/01/2024", "")]
        public void DataCriacao_Valida_ReturnsFalse(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacao != string.Empty ? Convert.ToDateTime(dtAtualizacao) : null,
                DtCriacao = dtCriacao != string.Empty ? Convert.ToDateTime(dtCriacao) : null,
                DtExclusao = dtExclusao != string.Empty ? Convert.ToDateTime(dtExclusao) : null
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.DtCriacao);
        }

        #endregion

        #region DataAtualizacao

        [Theory]
        [InlineData("Teste ende 1", 1, "1", "27/11/2023", "")]
        [InlineData("Teste ende 1", 1, "2", "27/11/2023", "")]
        public void DataAtualizacao_Valida_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);

            if (DateTime.Compare(DateTime.Today.Date, dtCriacaoConvert.Date) > 0)
                dtCriacaoConvert = DateTime.Today.Date;

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacao == "1" ? DateTime.Today.Date : dtAtualizacao == "2" ? DateTime.Today.Date.AddDays(1) : null,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusao != string.Empty ? Convert.ToDateTime(dtExclusao) : null
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.DtAtualizacao);
        }

        [Theory]
        [InlineData("Teste ende 1", 1, "1", "27/11/2023", "")]
        [InlineData("Teste ende 1", 1, "2", "27/11/2023", "")]
        public void DataAtualizacao_Valida_ReturnsFalse(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);

            if (DateTime.Compare(DateTime.Today.Date, dtCriacaoConvert.Date) > 0)
                dtCriacaoConvert = DateTime.Today.Date;

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtCriacao = dtCriacaoConvert,
                DtAtualizacao = dtAtualizacao == "1" ? DateTime.Today.Date.AddDays(-1) : dtAtualizacao == "2" ? dtCriacaoConvert.AddDays(-3) : null,
                DtExclusao = dtExclusao != string.Empty ? Convert.ToDateTime(dtExclusao) : null
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.DtAtualizacao);
        }

        #endregion

        #region DataExclusao

        [Theory]
        [InlineData("Teste ende 1", 1, "27/11/2023", "27/11/2023", "1")]
        [InlineData("Teste ende 1", 1, "27/11/2023", "27/11/2023", "2")]
        public void DataExclusao_Valida_ReturnsTrue(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);

            if (DateTime.Compare(DateTime.Today.Date, dtCriacaoConvert.Date) > 0)
                dtCriacaoConvert = DateTime.Today.Date;

            if (DateTime.Compare(DateTime.Today.Date, dtAtualizacaoConvert.Date) > 0)
                dtAtualizacaoConvert = DateTime.Today.Date;

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtAtualizacao = dtAtualizacaoConvert,
                DtCriacao = dtCriacaoConvert,
                DtExclusao = dtExclusao == "1" ? DateTime.Today.Date : dtExclusao == "2" ? DateTime.Today.Date.AddDays(1) : null,
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(p => p.DtExclusao);
        }

        [Theory]
        [InlineData("Teste ende 1", 1, "27/11/2023", "27/11/2023", "1")]
        [InlineData("Teste ende 1", 1, "27/11/2023", "27/11/2023", "2")]
        public void DataExclusao_Valida_ReturnsFalse(string enderecoCompleto, int quantidadeVolumes, string dtAtualizacao, string dtCriacao, string dtExclusao)
        {
            var dtCriacaoConvert = Convert.ToDateTime(dtCriacao);
            var dtAtualizacaoConvert = Convert.ToDateTime(dtAtualizacao);

            if (DateTime.Compare(DateTime.Today.Date, dtCriacaoConvert.Date) > 0)
                dtCriacaoConvert = DateTime.Today.Date;

            if (DateTime.Compare(DateTime.Today.Date, dtAtualizacaoConvert.Date) > 0)
                dtAtualizacaoConvert = DateTime.Today.Date;

            // Arrange
            var model = new Ocorrencia
            {
                EnderecoCompleto = enderecoCompleto,
                QuantidadeVolumes = quantidadeVolumes,
                DtCriacao = dtCriacaoConvert,
                DtAtualizacao = dtAtualizacaoConvert,
                DtExclusao = dtExclusao == "1" ? DateTime.Today.Date.AddDays(-1) : dtExclusao == "2" ? dtCriacaoConvert.AddDays(-3) : null
            };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.DtExclusao);
        }

        #endregion
    }
}