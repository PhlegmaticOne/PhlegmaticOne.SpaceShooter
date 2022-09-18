using System;
using AssemblyCSharp.Assets.Moves;
using AssemblyCSharp.Assets.Scripts.Attacking;
using AssemblyCSharp.Assets.Scripts.Interfaces;
using AssemblyCSharp.Assets.Scripts.Speed;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour, IDestroyable
{
    public static Player Instance;
    [CanBeNull] public static event EventHandler Enabled;
    [CanBeNull] public static event EventHandler Disabled;
    private Attack _attack;
    private MoveBase _move;
    private float _speed;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            Enabled?.Invoke(this, EventArgs.Empty);
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        _attack = GetComponent<Attack>();
        _move = GetComponent<MoveBase>();
        var speedComponent = GetComponent<Speed>();
        speedComponent.SpeedChanged += SpeedComponentOnSpeedChanged;
        _speed = speedComponent.GetSpeed();
    }

    void OnDisable()
    {
        var speedComponent = GetComponent<Speed>();
        speedComponent.SpeedChanged -= SpeedComponentOnSpeedChanged;
        Disabled?.Invoke(this, EventArgs.Empty);
    }
    
    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        _move.Move(transform);
    }

    private void Attack()
    {
        _attack.UpdateTime();

        if (Input.GetKey(KeyCode.Space))
        {
            _attack.TryShoot();
        }
    }

    private void SpeedComponentOnSpeedChanged(object sender, float newSpeed)
    {
        _speed = newSpeed;
    }

    public void Destroy()
    {
        Disabled?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
