using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAspNet.Domain.Entities
{
    // TODO_JBOY: inherit from ValueObject
    public class UserId : ValueObject
    {
        public Guid Value { get; private set; }

        private UserId(Guid value)
        {
            this.Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static UserId CreateNew()
        {
            return new UserId(Guid.NewGuid());
        }

        public static UserId CreateFrom(string value)
        {
            return new UserId(Guid.Parse(value));
        }

        public static UserId CreateFrom(Guid value)
        {
            return new UserId(value);
        }
    }
}
