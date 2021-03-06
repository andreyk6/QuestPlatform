﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Specifications.ConfigureSpecification;

namespace QuestPlatform.Domain.Infrastructure.Specifications.Composing
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public Expression<Func<T, bool>> IsSatisifiedBy()
        {
            var leftExpression = left.IsSatisifiedBy();
            var rightExpression = right.IsSatisifiedBy();

            var parameter = leftExpression.Parameters.Single();
            var body = Expression.AndAlso(leftExpression.Body, SpecificationParameterRebinder.ReplaceParameter(rightExpression.Body, parameter));

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
