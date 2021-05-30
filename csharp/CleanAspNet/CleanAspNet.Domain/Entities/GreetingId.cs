using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanAspNet.Domain.Entities
{
    // TODO_JBOY: inherit from ValueObject
    public class GreetingId : ValueObject
    {
        public Guid Value { get; private set; }

        private GreetingId(Guid value)
        {
            this.Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static GreetingId CreateNew()
        {
            return new GreetingId(Guid.NewGuid());
        }

        public static GreetingId CreateFrom(Guid value)
        {
            return new GreetingId(value);
        }
    }
}
