using Jaba.Route.Triggers;
using System;
using UnityEngine;

namespace Jaba.Route
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables

        public static Action OnGameStopped;
        public static Action OnGameStarted;

        private Vector3 direction = new Vector3(0f, 0f, 1f);

        [SerializeField]
        private float speed = 5f;

        [SerializeField]
        private float accelerationStep = 0.1f;

        public bool canControl = false;
        public bool moving = false;

        #endregion

        #region BuiltIn Methods

        private void OnEnable()
        {
            SpawnTrigger.OnSpawnTriggerEntered += IncreaseSpeed;
        }

        private void OnDisable()
        {
            SpawnTrigger.OnSpawnTriggerEntered -= IncreaseSpeed;
        }

        private void FixedUpdate()
        {
            Move();
        }

        #endregion

        #region Custom Methods

        #region Ball Control

        private void Move()
        {
            if (moving)
                transform.Translate(direction * speed * Time.fixedDeltaTime);
        }

        private void IncreaseSpeed()
        {
            speed += accelerationStep;
        }

        public void ChangeDirection()
        {
            if (canControl)
                direction = direction == new Vector3(1f, 0f, 0f) ? new Vector3(0f, 0f, 1f) : new Vector3(1f, 0f, 0f);
        }

        #endregion

        #region Game Control

        public void StartGame()
        {
            moving = true;
            canControl = true;

            OnGameStarted?.Invoke();
        }

        public void StopGame()
        {
            canControl = false;
            Destroy(gameObject, 5f);

            OnGameStopped?.Invoke();
        }

        #endregion

        #endregion

        #region Collisions

        private void OnCollisionEnter(Collision collision)
        {
            if (!canControl)
                moving = false;
        }

        #endregion
    }
}