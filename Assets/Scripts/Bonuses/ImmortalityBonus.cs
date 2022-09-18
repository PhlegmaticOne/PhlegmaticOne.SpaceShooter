using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Bonuses
{
    public class ImmortalityBonus : BonusBase
    {
        [SerializeField] private float _immortalityTime;
        protected override void HandleBonus(Player takenBy)
        {
            var health = takenBy.GetComponent<Health.Health>();
            health.SetImmortality(_immortalityTime);
        }
    }
}
