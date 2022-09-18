using AssemblyCSharp.Assets.Health;
using UnityEngine;

public abstract class BonusBase : MonoBehaviour
{
    [SerializeField] private float _existingTime;

    void Start()
    {
        Invoke(nameof(Destroy), _existingTime);
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.TryGetComponent(out Player player))
        {
            HandleBonus(player);
            Destroy(gameObject);
        }
    }
    protected abstract void HandleBonus(Player takenBy);

    protected void Destroy()
    {
        Destroy(gameObject);
    }
}
