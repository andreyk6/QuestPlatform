using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using QuestPlatform.Domain.Infrastructure.Specifications.Composing;

namespace QuestPlatform.Domain.Infrastructure.Specifications.ConfigureSpecification
{
    public static class Specification
    {
        public static ISpecification<T> And<T>(ISpecification<T> left, ISpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static ISpecification<T> Or<T>(ISpecification<T> left, ISpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        public static ISpecification<T> Not<T>(ISpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
    }
}
