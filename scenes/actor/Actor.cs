using Godot;

namespace SlimeNinja.Actors
{
    public class Actor : KinematicBody2D
    {
        [Export]
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        [Export]
        public float JumpStrength { get => jumpStrength; set => jumpStrength = value; }
        [Export]
        public float Gravity { get => gravity; set => gravity = value; }

        public Vector2 Velocity { get => velocity; set => velocity = value; }

        private AnimationPlayer _AnimationPlayer;
        private Sprite _Sprite;

        private float moveSpeed;
        private float jumpStrength;
        private float gravity;
        private Vector2 velocity = new Vector2();


        public override void _Ready()
        {
            _AnimationPlayer = GetNode("AnimationPlayer") as AnimationPlayer;
            _Sprite = GetNode("Sprite") as Sprite;
        }

        public void ApplyGravity(float delta)
        {
            velocity.y += gravity * delta;
        }

        public void ApplyRotation(float rotationDegrees)
        {
            _Sprite.RotationDegrees = rotationDegrees;
        }

        public void PlayAnimation(string animationName)
        {
            _AnimationPlayer.Play(animationName);
        }
    }
}

