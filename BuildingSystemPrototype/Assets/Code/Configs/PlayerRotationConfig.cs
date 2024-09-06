using Code.Models;

namespace Code.Configs
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "PlayerRotationConfig", menuName = "Configs/PlayerRotationConfig")]
    public class PlayerRotationConfig : ScriptableObject
    {
        [SerializeField]
        private float _mouseSensitivity = 100f; 
        
        public PlayerRotationModel Create()
        {
            return new PlayerRotationModel(_mouseSensitivity);
        }
    }

}