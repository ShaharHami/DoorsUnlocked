using Keys;
using UnityEngine;

namespace Doors
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Key.KeyType keyType;
        [SerializeField] private GameObject doorGameObject;

        public Key.KeyType GetKeyType()
        {
            return keyType;
        }

        public void OpenDoor()
        {
            doorGameObject.SetActive(false);
        }
    }
}
