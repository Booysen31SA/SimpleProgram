﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleProgram.Password_Strength
{
    public enum PasswordStrength
    {
        /// =========================================================================================================================
        /// Blank Password (empty and/or space chars only)
        /// =========================================================================================================================
        Blank = 0,
        /// =========================================================================================================================
        /// Either too short (less than 5 chars), one-case letters only or digits only
        /// =========================================================================================================================
        VeryWeak = 1,
        /// =========================================================================================================================
        /// At least 5 characters, one strong condition met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
        /// =========================================================================================================================
        Weak = 2,
        /// =========================================================================================================================
        /// At least 5 characters, two strong conditions met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
        /// =========================================================================================================================
        Medium = 3,
        /// =========================================================================================================================
        /// At least 8 characters, three strong conditions met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
        /// =========================================================================================================================
        Strong = 4,
        /// =========================================================================================================================
        /// At least 8 characters, all strong conditions met (>= 8 chars with 1 or more UC letters, LC letters, digits & special chars)
        /// =========================================================================================================================
        VeryStrong = 5
    }

    class PasswordStrengthCheck
    {
        /// =========================================================================================================================
        /// Methods to use to check password Strength
        /// =========================================================================================================================
        public static PasswordStrength GetPasswordStrength(string password)
        {
            int score = 0;
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(password.Trim())) return PasswordStrength.Blank;
            if (!HasMinimumLength(password, 5)) return PasswordStrength.VeryWeak;
            if (HasMinimumLength(password, 8)) score++;
            if (HasUpperCaseLetter(password) && HasLowerCaseLetter(password)) score++;
            if (HasDigit(password)) score++;
            if (HasSpecialChar(password)) score++;
            return (PasswordStrength)score;
        }

        /// =========================================================================================================================
        /// Sample password policy implementation:
        /// - minimum 8 characters
        /// - at lease one UC letter
        /// - at least one LC letter
        /// - at least one non-letter char (digit OR special char)
        /// =========================================================================================================================
        /// <returns></returns>
        public static bool IsStrongPassword(string password)
        {
            return HasMinimumLength(password, 8)
                && HasUpperCaseLetter(password)
                && HasLowerCaseLetter(password)
                && (HasDigit(password) || HasSpecialChar(password));
        }

        /// =========================================================================================================================
        /// Sample password policy implementation following the Microsoft.AspNetCore.Identity.PasswordOptions standard.
        /// =========================================================================================================================
        public static bool IsValidPassword(string password, PasswordOptions opts)
        {
            return IsValidPassword(
                password,
                opts.RequiredLength,
                opts.RequiredUniqueChars,
                opts.RequireNonAlphanumeric,
                opts.RequireLowercase,
                opts.RequireUppercase,
                opts.RequireDigit);
        }

        /// =========================================================================================================================
        /// End of Methods to use to check password Strength
        /// =========================================================================================================================
        /// 
        /// =========================================================================================================================
        /// Sample password policy implementation following the Microsoft.AspNetCore.Identity.PasswordOptions standard.
        /// =========================================================================================================================
        private static bool IsValidPassword(
            string password,
            int requiredLength,
            int requiredUniqueChars,
            bool requireNonAlphanumeric,
            bool requireLowercase,
            bool requireUppercase,
            bool requireDigit)
        {
            if (!HasMinimumLength(password, requiredLength)) return false;
            if (!HasMinimumUniqueChars(password, requiredUniqueChars)) return false;
            if (requireNonAlphanumeric && !HasSpecialChar(password)) return false;
            if (requireLowercase && !HasLowerCaseLetter(password)) return false;
            if (requireUppercase && !HasUpperCaseLetter(password)) return false;
            if (requireDigit && !HasDigit(password)) return false;
            return true;
        }

        #region Helper Methods

        private static bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }

        private static bool HasMinimumUniqueChars(string password, int minUniqueChars)
        {
            return password.Distinct().Count() >= minUniqueChars;
        }

        /// =========================================================================================================================
        /// Returns TRUE if the password has at least one digit
        /// =========================================================================================================================
        private static bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }

        /// =========================================================================================================================
        /// Returns TRUE if the password has at least one special character
        /// =========================================================================================================================
        private static bool HasSpecialChar(string password)
        { 
            // return password.Any(c => char.IsPunctuation(c)) || password.Any(c => char.IsSeparator(c)) || password.Any(c => char.IsSymbol(c));
            return password.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }

        /// =========================================================================================================================
        /// Returns TRUE if the password has at least one uppercase letter
        /// =========================================================================================================================
        private static bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }

        /// =========================================================================================================================
        /// Returns TRUE if the password has at least one lowercase letter
        /// =========================================================================================================================
        private static bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }
        #endregion
    }
}

