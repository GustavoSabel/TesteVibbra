using FluentAssertions;
using System;
using VibbraTest.Domain.Exceptions;
using VibbraTest.Domain.ValueObjects;
using Xunit;

namespace VibbraTest.Test
{
    public class CnpjTest
    {
        [Theory]
        [InlineData("36.924.896/0001-42")]
        [InlineData("36924896000142")]
        [InlineData("   36924896000142 ")]
        [InlineData("75.488.733/0001-16")]
        [InlineData("62.053.152/0001-00")]
        [InlineData("95.739.487/0001-35")]
        [InlineData("66.523.569/0001-40")]
        [InlineData("62.377.524/0001-53")]
        [InlineData("08.842.644/0001-39")]
        public void Valid(string cnpj)
        {
            var action = new Action(() => new Cnpj(cnpj));
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData("36.924.696/0001-42")]
        [InlineData("36924896030142")]
        [InlineData("   36924896010142 ")]
        [InlineData("00000000000000")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(" dasds ")]
        public void Invalid(string cnpj)
        {
            var action = new Action(() => new Cnpj(cnpj));
            action.Should().Throw<BusinessException>();
        }

        [Theory]
        [InlineData("36.924.896/0001-42", "36.924.896/0001-42")]
        [InlineData("36924896000142", "36.924.896/0001-42")]
        [InlineData("   36924896000142 ", "36.924.896/0001-42")]
        public void GetFormated(string cnpj, string formated)
        {
            new Cnpj(cnpj).ToString().Should().Be(formated);
        }

        [Theory]
        [InlineData("36.924.896/0001-42", "36924896000142")]
        [InlineData("36924896000142", "36924896000142")]
        [InlineData("   36924896000142 ", "36924896000142")]
        public void GetValue(string cnpj, string value)
        {
            new Cnpj(cnpj).Value.Should().Be(value);
        }
    }
}
