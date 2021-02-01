using Route;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaba.Route.Triggers
{
    public class GameOverTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().StopGame();
            }
        }
    }
}