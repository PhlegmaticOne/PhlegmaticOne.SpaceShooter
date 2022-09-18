using AssemblyCSharp.Assets.Moves;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Moves
{
    public class FollowPlayerMove : MoveBase
    {
        protected override void MoveProtected(Transform obj)
        {
            var playerTransform = Player.Instance.transform;
            obj.position = playerTransform.position;
        }
    }
}
