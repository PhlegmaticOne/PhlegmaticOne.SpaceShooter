using UnityEngine;

namespace AssemblyCSharp.Assets.Moves
{
    public class DirectMove : MoveBase
    {
        protected override void MoveProtected(Transform obj)
        {
            if (obj.gameObject.TryGetComponent(out Scripts.Speed.Speed speed))
            {
                var position = obj.position;
                position.x -= speed.GetSpeed() * Time.deltaTime;
                obj.position = position;
            }
        }
    }
}
