using System;
using Unity.VisualScripting;

namespace Code.Models
{
    public class PlayerMovementModel
    {
        private float _speed;

        public PlayerMovementModel(float speed)
        {
            if (speed <= 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(speed), "Player speed must be greater than 0.");
            }
            _speed = speed;
        }

        public float Speed
        {
            get => _speed;
            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(value), "Player speed must be greater than 0.");
                }
                _speed = value;
            }
        }
    }
}