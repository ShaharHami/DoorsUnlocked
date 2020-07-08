using System;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private void OnCollisionEnter(Collision coll)
        {
            if (coll.collider.CompareTag("Obstacle"))
            {
                gameManager.LevelFailed();
            }
        }
    }
}
