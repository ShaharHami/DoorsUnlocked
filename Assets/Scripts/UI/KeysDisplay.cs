using Keys;
using TMPro;
using UnityEngine;

namespace UI
{
    public class KeysDisplay : MonoBehaviour
    {
        public KeyDisplay[] keysDisplays;
        public void UpdateKeysDisplay(Key.KeyType keyType, int keys)
        {
            foreach (var display in keysDisplays)
            {
                if (display.keyType == keyType)
                {
                    display.GetComponent<TextMeshProUGUI>().text = keys.ToString();
                }
            }
        }
    }
}
