using AssemblyCSharp.Assets.Scripts.Damage;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] private float _destroyYCoord;
    private Damage _damage;

    void Start()
    {
        _damage = GetComponent<Damage>();
    }

    void Update()
    {
        if (transform.position.y <= _destroyYCoord)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        _damage.DamageEntity(obj.gameObject);
    }
}
