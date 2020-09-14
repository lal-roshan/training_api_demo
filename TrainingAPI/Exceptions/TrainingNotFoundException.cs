using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingAPI.Exceptions
{
    [System.Serializable]
    public class TrainingNotFoundException : Exception
    {
        public TrainingNotFoundException() { }
        public TrainingNotFoundException(string message) : base(message) { }
        public TrainingNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TrainingNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    
}
