using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SpeedDisplay : MonoBehaviour
    {
        public TextMeshProUGUI speedDisplay;

        public void UpdateDisplay(float speed)
        {
            speedDisplay.text = speed.ToString();
        }
    }
}
