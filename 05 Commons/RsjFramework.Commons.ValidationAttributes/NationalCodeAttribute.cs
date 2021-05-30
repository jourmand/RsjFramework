using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace RsjFramework.Commons.ValidationAttributes
{
    public class NationalCodeAttribute : ValidationAttribute
    {

        public bool IsCompanyNationalCode { get; set; } = false;

        public NationalCodeAttribute()
        {
            IsCompanyNationalCode = false;
        }


        public NationalCodeAttribute(bool IsCompanyNationalCode)
        {
            this.IsCompanyNationalCode = IsCompanyNationalCode;
        }

        public override bool IsValid(object value)
        {

            if (!(value is string nationalCode)) return false;

            if (string.IsNullOrEmpty(nationalCode)) return false;

            if (IsCompanyNationalCode)
                return CheckLegalCodeIsValid(nationalCode);

            else
                return CheckPersonalCodeIsValid(nationalCode);

        }

        private bool CheckPersonalCodeIsValid(string nationalCode)
        {

            if (!Regex.IsMatch(nationalCode, @"^(?!(\d)\1{9})\d{10}$"))
                return false;

            var check = Convert.ToInt32(nationalCode.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(nationalCode.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
        }

        private bool CheckLegalCodeIsValid(string nationalCode)
        {
            if (nationalCode.Length < 11 || !Int64.TryParse(nationalCode, out long nationalCodeInt))
                return false;

            if (nationalCodeInt == 0)
                return false;


            var check = Convert.ToInt32(nationalCode.Substring(10, 1));
            var dahgan = Convert.ToInt32(nationalCode.Substring(9, 1)) + 2;
            int[] zarayeb = new int[] { 29, 27, 23, 19, 17 };
            int sum = 0;

            for (byte i = 0; i < 10; i++)
                sum += (dahgan + Convert.ToInt32(nationalCode.Substring(i, 1))) * zarayeb[i % 5];

            sum = sum % 11;

            if (sum == 10)
                sum = 0;

            return (check == sum);

        }

    }


}
