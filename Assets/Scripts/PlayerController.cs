using System;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action OnGameStopped;
    public static Action OnGameStarted;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _accelerationStep = 0.1f;

    private Vector3 _direction = new Vector3(0f, 0f, 1f);

    public bool canControl = false;
    public bool moving = false;

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

    private void Move()
    {
        if (moving)
            transform.Translate(_direction * _speed * Time.fixedDeltaTime);
    }

    private void IncreaseSpeed()
    {
        _speed += _accelerationStep;
    }

    public void ChangeDirection()
    {
        if (canControl)
            _direction = _direction == new Vector3(1f, 0f, 0f) ? new Vector3(0f, 0f, 1f) : new Vector3(1f, 0f, 0f);
    }

    public void StartGame()
    {
        moving = true;
        canControl = true;

        OnGameStarted?.Invoke();
    }

    public void StopGame()
    {
        canControl = false;

        OnGameStopped?.Invoke();

        Destroy(gameObject, 5f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!canControl)
        {
            moving = false;
        }
    }
}
