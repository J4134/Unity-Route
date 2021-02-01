using Route;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jaba.Route.Triggers
{
    public class SpawnTrigger : MonoBehaviour
    {
        public static Action OnSpawnTriggerEntered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                transform.GetComponentInParent<ChunkSpawner>().SpawnNewChunk();

                OnSpawnTriggerEntered?.Invoke();
            }
        }
    }
}