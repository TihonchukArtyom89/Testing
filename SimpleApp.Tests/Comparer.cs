﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Tests;

public class Comparer
{
    public static Comparer<U?> Get<U>(Func<U?, U?, bool> func)
    {
        return new Comparer<U?>(func);
    }
}
public class Comparer<T> : Comparer, IEqualityComparer<T>
{
    private Func<T?, T?, bool> comparsionFunction;
    public Comparer(Func<T?, T?, bool> func)
    {
        comparsionFunction = func;
    }
    public bool Equals(T? x, T? y)
    {
        return comparsionFunction(x, y);
    }
    public int GetHashCode(T? obj)
    {
        return obj?.GetHashCode() ?? 0;
    }
}