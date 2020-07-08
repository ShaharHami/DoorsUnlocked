using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class JumpForceDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI jumpForceDisplay;
        [SerializeField] private Image jumpForceBar;
        
        public void UpdateForceDisplay(float jumpLoadedForce, float maxJumpForce)
        {
            jumpForceBar.fillAmount = jumpLoadedForce / maxJumpForce;
        }

        public void UpdateJumpsRemainingDisplay(int jumps)
        {
            jumpForceDisplay.text = jumps.ToString();
        }
    }
}
