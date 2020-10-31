namespace SlimeNinja.Exceptions
{
    [System.Serializable]
    public class StateMachineException : System.Exception
    {
        public StateMachineException() { }
        public StateMachineException(string message) : base(message) { }
        public StateMachineException(string message, System.Exception inner) : base(message, inner) { }
        protected StateMachineException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}