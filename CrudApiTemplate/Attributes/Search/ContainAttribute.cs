﻿using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace CrudApiTemplate.Attributes.Search;

public class ContainAttribute : FilterAttribute
{
    public override Expression ToExpressionEvaluate(Expression parameter, object value)
    {
        var parameterType = parameter.Type;
        /*
        var member = parameter.Navigate(Target?.6Split(".").ToList(), PropertyName ?? "");
        */
        var containMethod = parameterType.GetMethod("Contains", new []{value.GetType()});
        if (containMethod is null) throw new Exception("Coding error: using ContainAttribute");
        //parameter.Contains()
        return Expression.Call(parameter, containMethod, Expression.Convert(Expression.Constant(value), parameter.Type));
    }

    public ContainAttribute([CallerMemberName] string propertyName = ""): base(propertyName, propertyName)
    {
    }

    public ContainAttribute(string target, [CallerMemberName] string? propertyName = null) : base(target, propertyName)
    {
    }
}