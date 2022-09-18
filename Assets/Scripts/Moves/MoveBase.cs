using UnityEngine;

namespace AssemblyCSharp.Assets.Moves
{
    public abstract class MoveBase : MonoBehaviour
    {
        [SerializeField] protected float DestroyXCoord;

        public void Move(Transform obj)
        {
            MoveProtected(obj);
            if (obj.position.x <= DestroyXCoord)
            {
                Destroy(obj.gameObject);
            }
        }

        protected abstract void MoveProtected(Transform obj);
    }
}
