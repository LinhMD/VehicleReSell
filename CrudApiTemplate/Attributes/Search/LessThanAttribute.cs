﻿using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace CrudApiTemplate.Attributes.Search;

public class LessThanAttribute : FilterAttribute
{
    public override Expression ToExpressionEvaluate(Expression parameter, object value)
    {
        return Expression.LessThanOrEqual(parameter, Expression.Convert(Expression.Constant(value), parameter.Type));
    }
    public LessThanAttribute()
    {
    }

    public LessThanAttribute(string target ,[CallerMemberName] string? name = null) : base(target, name)
    {
    }
}