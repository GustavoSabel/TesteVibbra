﻿using System.Text.RegularExpressions;
using VibbraTest.Domain.Exceptions;

namespace VibbraTest.Domain.ValueObjects
{
    public class Cnpj : ValueObject<Cnpj>
    {
        public Cnpj(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new BusinessException("CNPJ not found");

            var valorApenasNumeros = GetOnlyNumbers(valor);

            if(!Validate(valorApenasNumeros))
                throw new BusinessException($"CNPJ {valor} is invalid");

            Value = valorApenasNumeros;
        }

        private static string GetOnlyNumbers(string valor)
        {
            return Regex.Replace(valor, @"[^\d]", "");
        }

        public string Value { get; }

        public override string ToString() => long.Parse(Value).ToString(@"00\.000\.000\/0000\-00");



        static readonly int[] _multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] _multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private static bool Validate(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            // Verifica os Patterns mais Comuns para CNPJ's Inválidos
            if (cnpj.Equals("00000000000000") ||
                cnpj.Equals("11111111111111") ||
                cnpj.Equals("22222222222222") ||
                cnpj.Equals("33333333333333") ||
                cnpj.Equals("44444444444444") ||
                cnpj.Equals("55555555555555") ||
                cnpj.Equals("66666666666666") ||
                cnpj.Equals("77777777777777") ||
                cnpj.Equals("88888888888888") ||
                cnpj.Equals("99999999999999"))
            {
                return false;
            }

            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (var i = 0; i < 12; i++)
                soma += (tempCnpj[i] - '0') * _multiplicador1[i];

            var resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (var i = 0; i < 13; i++)
                soma += (tempCnpj[i] - '0') * _multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto;

            return cnpj.EndsWith(digito);
        }

        protected override bool EqualsCore(Cnpj other)
        {
            return other.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
