using System;
using AssemblyCSharp.Assets.Moves;
using AssemblyCSharp.Assets.Scripts.Attacking;
using AssemblyCSharp.Assets.Scripts.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{
    [SerializeField] private int _scoreForKilling;
    private Attack _attack;
    private MoveBase _moveBase;
    [CanBeNull] public static event EventHandler<int> Killed;
    void Start()
    {
        _attack = GetComponent<Attack>();
        _moveBase = GetComponent<MoveBase>();
    }
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        _moveBase.Move(transform);
    }

    void Attack()
    {
        _attack.UpdateTime();
        _attack.TryShoot();
    }

    public void Destroy()
    {
        OnKilled(_scoreForKilling);
        Destroy(gameObject);
    }

    private static void OnKilled(int e)
    {
        Killed?.Invoke(null, e);
    }
}
