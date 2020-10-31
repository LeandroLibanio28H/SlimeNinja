using System;
using Godot;
using SlimeNinja.Exceptions;

namespace SlimeNinja.StateMachine.States
{
    public abstract class State : Node
    {
        public FiniteStateMachine FSM {get; set;}
        protected string _className;

        protected virtual void ValidateState()
        {
            if (!Name.Equals(_className))
            {
                throw new StateNodeException("State nodes must have their class names");
            }
            if (FSM is null)
            {
                throw new StateNodeException("A StateMachine must be provided for the node");
            }
        }

        protected virtual void Exit(string nextState)
        {
            if (!String.IsNullOrEmpty(nextState))
                FSM.ChangeTo(nextState);
            else
                throw new StateNodeException("No Next State has been provided for this transition");
        }

        public virtual void Process(float delta) {}
        public virtual void PhysicsProcess(float delta) {}
        public virtual void Input(InputEvent inputEvent) {}
        public virtual void UnhandledInput(InputEvent inputEvent){}
        public virtual void Notification(int what){}
        public abstract void Enter();
    }
}