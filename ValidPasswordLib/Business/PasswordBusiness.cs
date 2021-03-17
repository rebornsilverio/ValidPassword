using System;
using System.Linq;
using System.Text.RegularExpressions;
using ValidPasswordInterfaces.Business;

namespace ValidPasswordLib.Business
{
    public class PasswordBusiness : IPasswordBusiness
    {
        public PasswordBusiness()
        {
        }

        private bool RuleWhiteSpace(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Count(Char.IsWhiteSpace) == 0;
        }

        private bool RuleNineOrMoreChars(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 9;
        }

        private bool RuleAtLeastOneDigit(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Count(Char.IsDigit) > 0;
        }

        private bool RuleAtLeastOneLowercaseChar(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Count(Char.IsLower) > 0;
        }

        private bool RuleAtLeastOneUppercaseChar(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Count(Char.IsUpper) > 0;
        }

        private bool RuleAtLeastOneSpecialChar(string password)
        {
            return !string.IsNullOrEmpty(password) && Regex.Matches(password, @"[!@#\$%^&\*\(\)\-\+]").Count > 0 ;
        }

        private bool RuleNonRepeatedChar(string password)
        {
            return !string.IsNullOrEmpty(password) && (from c in password
                    group c by c
                    into grp
                    where grp.Count() > 1
                    select grp.Key).Count() == 0 ;
        }

        public bool IsValid(string password)
        {
            bool result = RuleWhiteSpace(password);
            result = result && RuleNineOrMoreChars(password);
            result = result && RuleAtLeastOneDigit(password);
            result = result && RuleAtLeastOneLowercaseChar(password);
            result = result && RuleAtLeastOneUppercaseChar(password);
            result = result && RuleAtLeastOneSpecialChar(password);
            result = result && RuleNonRepeatedChar(password);
            return result;
        }
    }
}
