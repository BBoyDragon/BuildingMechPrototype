using Code.Models;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Configs/PlayerMovementConfig")]
    public class PlayerMovementConfig : ScriptableObject
    {
        [SerializeField]
        private float _speed = 5.0f;

        public PlayerMovementModel Create()
        {
            return new PlayerMovementModel(_speed);
        }
    }
}