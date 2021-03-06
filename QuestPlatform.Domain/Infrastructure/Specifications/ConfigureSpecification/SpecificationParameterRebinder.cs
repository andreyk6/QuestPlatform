﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuestPlatform.Domain.Infrastructure.Specifications.ConfigureSpecification
{
    internal class SpecificationParameterRebinder : ExpressionVisitor
    {
        private readonly ParameterExpression specificationParameter;

        private SpecificationParameterRebinder(ParameterExpression specificationParameter)
        {
            this.specificationParameter = specificationParameter;
        }

        public static Expression ReplaceParameter(Expression expression, ParameterExpression parameter)
        {
            return new SpecificationParameterRebinder(parameter).Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            return base.VisitParameter(specificationParameter);
        }
    }
}
