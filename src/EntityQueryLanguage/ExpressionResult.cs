using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace EntityQueryLanguage
{
    /// <summary>
    /// Holds information about the compiled expression
    /// </summary>
    public class ExpressionResult
    {
        private Dictionary<ParameterExpression, object> parameters = new Dictionary<ParameterExpression, object>();

        public ExpressionResult(Expression value)
        {
            this.Expression = value;
        }

        public Expression Expression { get; internal set; }
        public Type Type { get { return Expression.Type; } }

        public IReadOnlyDictionary<ParameterExpression, object> Parameters { get => parameters; }

        public static implicit operator Expression(ExpressionResult field)
        {
            return field.Expression;
        }

        /// <summary>
        /// Explicitly cast an Expression to ExpressionResult creating a new ExpressionResult. Make sure that is your intention, not carrying over any parameters
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator ExpressionResult(Expression value)
        {
            return new ExpressionResult(value);
        }

        internal void AddParameter(ParameterExpression type, object value)
        {
            parameters.Add(type, value);
        }
    }
}