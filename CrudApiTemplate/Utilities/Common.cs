﻿using System.Linq.Expressions;
using System.Reflection;

namespace CrudApiTemplate.Utilities;

public static class Common
{

    public const string SortByRegexString = @"(\w+-(asc|dec)(,|))*";

    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => "",
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };

    public static Expression Navigate(this Expression param, IList<string>? list, string propertyName)
    {
        //if have more member navigation like t.Role.Name
        Expression tProperty = Expression.Property(param, list?[0] ?? propertyName);

        return list == null ? tProperty : list.Skip(1).Aggregate(tProperty, Expression.Property);
    }
    public static void Dump(this object? o)
    {
        Console.WriteLine(o);
    }

    public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
    {
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                action(iterator.Current);
            }
        }

        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }
    }
}