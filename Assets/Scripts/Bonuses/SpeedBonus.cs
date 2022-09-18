using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Bonuses
{
    public class SpeedBonus : BonusBase
    {
        [SerializeField] private float _dSpeed;
        [SerializeField] private float _timeAct;
        protected override void HandleBonus(Player takenBy)
        {
            var speed = takenBy.GetComponent<Speed.Speed>();
            speed.ChangeSpeed(_dSpeed, _timeAct);
        }
    }
}
