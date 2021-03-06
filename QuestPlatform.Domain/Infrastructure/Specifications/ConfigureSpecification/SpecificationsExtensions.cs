﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;

namespace QuestPlatform.Domain.Infrastructure.Specifications.ConfigureSpecification
{
    public static class SpecificationsExtensions
    {
        public static bool IsSatisfiedBy<T>(this ISpecification<T> specification, T entity)
        {
            return specification.IsSatisifiedBy().Compile()(entity);
        }

        public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return Specification.And(left, right);
        }

        public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right)
        {
            return Specification.Or(left, right);
        }
    }
}
