using Godot;
using SlimeNinja.Actors;
using SlimeNinja.Exceptions;
using SlimeNinja.StateMachine.States;

namespace SlimeNinja.StateMachine
{
    public class FiniteStateMachine : Node
    {
        public Actor SceneActor { get => GetParent() as Actor; }

        //Members
        private State _State;

        //Methods
        public void ChangeTo(string new_State)
        {
            _State = GetNode(new_State) as State;
            EnterState();
        }

        private void EnterState()
        {
            if (OS.IsDebugBuild())
                GD.Print("Entering state: ", _State.Name);
            
            _State.FSM = this;
            _State.Enter();
        }

        //GODOT
        public override void _Ready()
        {
            SceneLoaded();
            //GetTree().Connect("idle_frame", this, nameof(SceneLoaded));
        }

        //States
        public override void _Process(float delta)
        {
            if (_State != null)
                _State.Process(delta);
        }

        public override void _PhysicsProcess(float delta)
        {
            if (_State != null)
                _State.PhysicsProcess(delta);
        }

        public override void _Input(InputEvent inputEvent)
        {
            if (_State != null)
                _State.Input(inputEvent);
        }

        public override void _UnhandledInput(InputEvent inputEvent)
        {
            if (_State != null)
                _State.UnhandledInput(inputEvent);
        }

        public override void _Notification(int what)
        {
            if (_State != null)
                _State.Notification(what);
        }


        private async void SceneLoaded()
        {
            await(ToSignal(GetTree(), "idle_frame"));
            if (GetParent() is Actor == false)
            {
                throw new StateMachineException("FiniteStateMachine parent is not an Actor");
            }

            if (GetChildCount() > 0)
            {
                if (GetChild(0) is State)
                {
                    _State = GetChild(0) as State;
                    EnterState();
                }
                else
                    throw new StateMachineException("FiniteStateMachine first child is not a State.");
            }
            else
                throw new StateMachineException("FiniteStateMachine has no childs.");             
        }
    }
}