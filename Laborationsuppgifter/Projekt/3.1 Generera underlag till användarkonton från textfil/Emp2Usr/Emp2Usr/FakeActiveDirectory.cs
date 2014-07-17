using System;
using System.Collections.Generic;
using System.Linq;

namespace Emp2Usr
{
    public static class FakeActiveDirectory
    {
        private static readonly string[] _samAccountNames;

        static FakeActiveDirectory()
        {
            _samAccountNames = new string[]{
                "albr", "anba", "anhi", "anhi2", "boho", "chkl", "doha", 
                "doha2", "doha4", "gayu", "hopo", "jili", "kakh", "keke", 
                "lope3", "mira", "mira2", "misu9", "misu10", "paco2", "ruki", "stmu", 
                "wijo", "zhmu",
                };
        }

        public static bool ADUserExists(string samAccountName)
        {
            return _samAccountNames.Any(s => s == samAccountName);
        }

        public static List<string> GetADUsers(string filter = null)
        {
            return String.IsNullOrWhiteSpace(filter) ? 
                _samAccountNames.ToList() : 
                _samAccountNames.Where(s => s.Contains(filter)).ToList();
        }
    }
}
