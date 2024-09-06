namespace Code.Models
{
    public class PlayerRotationModel
    {
        private float _mouseSensitivity;

        public PlayerRotationModel(float mouseSensitivity)
        {
            if (mouseSensitivity <= 0)
            {
                throw new System.ArgumentOutOfRangeException(nameof(mouseSensitivity), "Mouse sensitivity must be greater than 0.");
            }
            _mouseSensitivity = mouseSensitivity;
        }

        public float MouseSensitivity
        {
            get => _mouseSensitivity;
            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(value), "Mouse sensitivity must be greater than 0.");
                }
                _mouseSensitivity = value;
            }
        }
    }

}