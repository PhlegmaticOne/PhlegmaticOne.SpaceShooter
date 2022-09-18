using AssemblyCSharp.Assets.Moves;
using AssemblyCSharp.Assets.Scripts.Damage;
using AssemblyCSharp.Assets.Scripts.Speed;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _deactivateTime;
    private Damage _damage;
    private MoveBase _move;

    void Start()
    {
        _move = GetComponent<MoveBase>();
        _damage = GetComponent<Damage>();
        Invoke(nameof(Destroy), _deactivateTime);
    }

    void Update()
    {
        _move.Move(transform);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        _damage.DamageEntity(obj.gameObject);
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (_damage.IsDestroying() == false)
        {
            _damage.DamageEntity(obj.gameObject);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
