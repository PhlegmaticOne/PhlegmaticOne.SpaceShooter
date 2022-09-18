using AssemblyCSharp.Assets.Scripts.Attacking;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Bonuses
{
    public class BetterBulletBonus : BonusBase
    {
        [SerializeField] private GameObject _betterBullet;
        [SerializeField] private float _time;
        [SerializeField] private float _attackTime;
        protected override void HandleBonus(Player takenBy)
        {
            var attack = takenBy.GetComponent<Attack>();
            attack.SetNewBullet(_betterBullet, _attackTime, _time);
        }
    }
}
