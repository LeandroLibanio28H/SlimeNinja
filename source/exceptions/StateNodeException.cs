namespace SlimeNinja.Exceptions
{
    [System.Serializable]
    public class StateNodeException : System.Exception
    {
        public StateNodeException() { }
        public StateNodeException(string message) : base(message) { }
        public StateNodeException(string message, System.Exception inner) : base(message, inner) { }
        protected StateNodeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}