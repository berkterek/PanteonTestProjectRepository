namespace PanteonTestProject.Movements
{
    public class Jump
    {
        float _gravity;
        float _jumpForce;

        public Jump(float gravity, float jumpForce)
        {
            _gravity = gravity;
            _jumpForce = jumpForce;
        }

        public float Gravity => _gravity;
        public float JumpForce => _jumpForce;
        public bool IsJump { get; set; }
    }
}
