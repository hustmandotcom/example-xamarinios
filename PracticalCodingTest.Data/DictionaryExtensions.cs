using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticalCodingTest.Data
{
    static class DictionaryExtensions
    {
        public static Dictionary<string, string> AddValidationResults(this Dictionary<string, string> dictionary, IEnumerable<ValidationResult> validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                if (validationResult == null) continue;
                foreach (var memberName in validationResult.MemberNames)
                {
                    dictionary.Add(memberName, validationResult.ErrorMessage);
                }
            }

            return dictionary;
        }
    }
}
