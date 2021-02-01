using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject _player;

    private bool follow;

    public Vector3 offset;

    private void OnEnable()
    {
        PlayerController.OnGameStopped += StopFollowing;
    }

    private void Awake()
    {
        follow = true;
    }

    private void Update()
    {
        if (!follow)
            return;

        transform.position = offset + _player.transform.position;
    }

    private void OnDisable()
    {
        PlayerController.OnGameStopped -= StopFollowing;
    }

    private void StopFollowing() => follow = false;
}
