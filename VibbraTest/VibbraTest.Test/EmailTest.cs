using FluentAssertions;
using System;
using VibbraTest.Domain.Exceptions;
using VibbraTest.Domain.ValueObjects;
using Xunit;

namespace VibbraTest.Test
{
    public class EmailTest
    {
        [Theory]
        [InlineData("david.jones@proseware.com")]
        [InlineData("d.j@server1.proseware.com")]
        [InlineData("jones@ms1.proseware.com")]
        [InlineData("j@proseware.com9" )]
        [InlineData("js#internal@proseware.com")]
        [InlineData("j_9@[129.126.118.1]")]
        [InlineData("js@proseware.com9" )]
        [InlineData("j.s@server1.proseware.com")]
        [InlineData(@"""j\""s""@proseware.com")]
        public void Valid(string email)
        {
            var action = new Action(() => new Email(email));
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData("j.@server1.proseware.com")]
        [InlineData("j..s@proseware.com")]
        [InlineData("js*@proseware.com")]
        [InlineData("js@proseware..com")]
        public void Invalid(string email)
        {
            var action = new Action(() => new Email(email));
            action.Should().Throw<BusinessException>();
        }

        [Theory]
        [InlineData(" Gustavo.Sabel.Gs@gmail.com ", "gustavo.sabel.gs@gmail.com")]
        public void GetValue(string email, string value)
        {
            new Email(email).Value.Should().Be(value);
        }
    }
}
