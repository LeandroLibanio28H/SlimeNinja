namespace SlimeNinja.Exceptions
{
    [System.Serializable]
    public class ActorException : System.Exception
    {
        public ActorException() { }
        public ActorException(string message) : base(message) { }
        public ActorException(string message, System.Exception inner) : base(message, inner) { }
        protected ActorException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}