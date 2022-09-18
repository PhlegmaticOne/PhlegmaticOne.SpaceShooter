using System;
using AssemblyCSharp.Assets.Scripts.Speed;
using UnityEngine;

namespace AssemblyCSharp.Assets.Moves
{
    public class SinusoidMove : MoveBase
    {
        [SerializeField] private float A;
        [SerializeField] private float L;
        protected override void MoveProtected(Transform obj)
        {
            if (obj.gameObject.TryGetComponent(out Speed speed))
            {
                var position = obj.position;
                position.x -= speed.GetSpeed() * Time.deltaTime;
                position.y = A * (float)Math.Sin(L * Time.time);
                obj.position = position;
            }
        }
    }
}
