using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingAPI.Exceptions
{
    [System.Serializable]
    public class DuplicateTrainingTitleExistsException : Exception
    {
        public DuplicateTrainingTitleExistsException() { }
        public DuplicateTrainingTitleExistsException(string message) : base(message) { }
        public DuplicateTrainingTitleExistsException(string message, Exception inner) : base(message, inner) { }
        protected DuplicateTrainingTitleExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
