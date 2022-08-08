using System.Runtime.Serialization;

namespace ExceptionsVsDomainNotification.ExceptionApi.Exceptions
{
    public abstract class DomainError
    {
        protected DomainError(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; }
        public string Message { get; }
    }

    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message) { }
        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public abstract string Key { get; }

        protected ICollection<DomainError> errors = new List<DomainError>();

        public IEnumerable<DomainError> Errors { get { return errors; } }
    }

    public abstract class DomainException<T> : DomainException where T : DomainError
    {
        protected DomainException() : base("Domain Exception thrown.") { }

        protected DomainException(string message) : base(message) { }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DomainException AddError(params T[] errors)
        {
            foreach (var error in errors)
            {
                this.errors.Add(error);
            }
            return this;
        }
    }
}
