using AssemblyCSharp.Assets.Scripts.Attacking;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Bonuses
{
    public class LaserBulletBonus : BonusBase
    {
        [SerializeField] private GameObject _laserBullet;
        [SerializeField] private float _time;
        protected override void HandleBonus(Player takenBy)
        {
            var attack = takenBy.GetComponent<Attack>();
            attack.SetNewBullet(_laserBullet, _time, _time);
        }
    }
}
