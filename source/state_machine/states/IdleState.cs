using Godot;
using SlimeNinja.Ninja.Controller;

namespace SlimeNinja.StateMachine.States
{
    public class IdleState : State
    {
        NinjaController Controller => GetNode("/root/NinjaController") as NinjaController; 

        public override void Enter()
        {
            _className = nameof(IdleState);
            ValidateState();
            FSM.SceneActor.PlayAnimation("Idle");

            Controller.Connect("MovedUp", this, nameof(MoveUp));
            Controller.Connect("MovedDown", this, nameof(MoveDown));
        }

        private void MoveUp()
        {
            if (OS.IsDebugBuild())
                GD.Print("Idle State - Move UP");
        }

        private void MoveDown()
        {
            if (OS.IsDebugBuild())
                GD.Print("Idle State - Move DOWN");
        }
    }
}