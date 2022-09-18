using AssemblyCSharp.Assets.Scripts.Attacking;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Bonuses
{
    public class FastBulletsBonus : BonusBase
    {
        [SerializeField] private GameObject _fastBullet;
        [SerializeField] private float _time;
        [SerializeField] private float _attackTime;
        protected override void HandleBonus(Player takenBy)
        {
            var attack = takenBy.GetComponent<Attack>();
            attack.SetNewBullet(_fastBullet, _attackTime, _time);
        }
    }
}
