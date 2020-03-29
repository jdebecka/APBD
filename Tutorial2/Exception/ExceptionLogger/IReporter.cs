﻿using System;
namespace RecursivePatterns
{
    public enum SecurityLevel
    {
        Warning = 2,
        Error = 3
    }
    public interface IReporter
    {
        void Report(Exception ex, string description, SecurityLevel level);
    }
}
