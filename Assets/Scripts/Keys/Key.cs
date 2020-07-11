using UnityEngine;

namespace Keys
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private KeyType keyType;
        public enum KeyType
        {
            Red,
            Green,
            Blue,
            OmniKey,
        }

        public KeyType GetKeyType()
        {
            return keyType;
        }
    }
}
