﻿using System;
namespace RecursivePatterns
{
    public enum SecurityLevel
    {
        Trace = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Critical = 4
    }
    public interface IReporter
    {
        void Report(Exception ex, string description, SecurityLevel level);
    }
}
