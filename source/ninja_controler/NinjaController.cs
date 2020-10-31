using Godot;

namespace SlimeNinja.Ninja.Controller
{
    public class NinjaController : Node
    {
        [Signal]
        public delegate void MovedUp();
        [Signal]
        public delegate void MovedDown();


        private float deadZone = 20.0f;
        private Vector2 startPosition = new Vector2();
        private Vector2 direction = new Vector2();
        private bool isDragging = false;


        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventScreenTouch)
            {
                var inputEvent = @event as InputEventScreenTouch;

                if (inputEvent.IsPressed())
                {
                    if (OS.IsDebugBuild())
                        GD.Print("Pressed");
                    
                    startPosition = inputEvent.Position;
                    isDragging = true;
                }
                else
                {
                    if (OS.IsDebugBuild())
                        GD.Print("Released");

                    startPosition = new Vector2();
                    direction = new Vector2();
                    isDragging = false;
                }
            }
            else if (@event is InputEventScreenDrag && isDragging)
            {
                var inputEvent = @event as InputEventScreenDrag;

                Vector2 position = inputEvent.Position;
                Vector2 distance = position - startPosition;

                if (Mathf.Abs(distance.y) >= deadZone)
                {
                    isDragging = false;

                    if (distance.y > 0)
                        EmitSignal(nameof(MovedDown));
                    else
                        EmitSignal(nameof(MovedUp));


                    if (OS.IsDebugBuild())
                        GD.Print(distance.y > 0 ? "Moving Down" : "Moving Up");
                }
                
                if (Mathf.Abs(distance.x) >= deadZone)
                {
                    isDragging = false;
                    direction = new Vector2(Mathf.Sign(distance.x), 0.0f);

                    if (OS.IsDebugBuild())
                        GD.Print(direction.x > 0 ? "Moving Right" : "Moving Left");
                }
            }
        }
    }
}