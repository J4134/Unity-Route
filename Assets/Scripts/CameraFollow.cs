using Jaba.Route;
using UnityEngine;

namespace Route
{
    public class CameraFollow : MonoBehaviour
    {
        #region Varibles

        [SerializeField] private GameObject player;

        [SerializeField] private Vector3 offset;

        private bool follow;

        #endregion

        #region BuiltIn Methods

        private void OnEnable()
        {
            PlayerController.OnGameStopped += StopFollowing;
        }

        private void OnDisable()
        {
            PlayerController.OnGameStopped -= StopFollowing;
        }

        private void Awake()
        {
            follow = true;
        }

        private void Update()
        {
            if (!follow)
                return;

            transform.position = offset + player.transform.position;
        }

        #endregion

        #region Custom Methods

        private void StopFollowing() => follow = false;

        #endregion
    }
}