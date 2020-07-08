using System.Collections.Generic;
using Doors;
using Managers;
using UI;
using UnityEngine;

namespace Keys
{
    public class KeyHolder : MonoBehaviour
    {
        [SerializeField] private KeysDisplay keysDisplay;
        [SerializeField] private EconomyManager economyManager;
        private List<Key.KeyType> keyList;
        
        private void Awake()
        {
            keyList = new List<Key.KeyType>();
        }

        public void AddKey(Key.KeyType keyType)
        {
            keyList.Add(keyType);
            UpdateUI(keyType);
        }

        public void RemoveKey(Key.KeyType keyType)
        {
            keyList.Remove(keyType);
            UpdateUI(keyType);
        }

        private void UpdateUI(Key.KeyType keyType)
        {
            var ks = 0;
            foreach (var k in keyList)
            {
                if (k == keyType)
                {
                    ks++;
                }
            }

            keysDisplay.UpdateKeysDisplay(keyType, ks);
        }

        private bool ContainsKey(Key.KeyType keyType)
        {
            return keyList.Contains(keyType);
        }

        private void OnTriggerEnter(Collider coll)
        {
            Key key = coll.GetComponent<Key>();
            if (key != null)
            {
                AddKey(key.GetKeyType());
                key.gameObject.SetActive(false);
            }

            Door door = coll.GetComponent<Door>();
            if (door == null) return;
            if (ContainsKey(door.GetKeyType()))
            {
                door.OpenDoor();
                RemoveKey(door.GetKeyType());
            }
            else
            {
                if (ContainsKey(Key.KeyType.Master))
                {
                    door.OpenDoor();
                    RemoveKey(Key.KeyType.Master);
                }
                else
                {
                    economyManager.OfferPurchaseKey(door);
                }
            }
        }
    }
}
