using Godot;

namespace SlimeNinja.StateMachine.States
{
    public class WalkState : State
    {
        public override void Enter()
        {
            _className = nameof(WalkState);
            ValidateState();
            GD.Print("Hello from WalkState");
            SceneTreeTimer test = GetTree().CreateTimer(2.0f);
            test.Connect("timeout", this, nameof(testTimeout));
        }

        private void testTimeout()
        {
            Exit(nameof(IdleState));
        }
    }
}