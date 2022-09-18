using System;
using AssemblyCSharp.Assets.Moves;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Moves
{
    public class AllSidesMove : MoveBase
    {
        [SerializeField] private float _minY;
        [SerializeField] private float _maxY;
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        protected override void MoveProtected(Transform obj)
        {
            if (obj.gameObject.TryGetComponent(out Speed.Speed speed))
            {
                var position = obj.transform.position;

                var inputY = Input.GetAxisRaw("Vertical");
                var inputX = Input.GetAxisRaw("Horizontal");

                position.x = HandleNewPosition(position.x, inputX, speed.GetSpeed(), _maxX, _minX);
                position.y = HandleNewPosition(position.y, inputY, speed.GetSpeed(), _maxY, _minY);

                obj.transform.position = position;
            }

        }

        private float HandleNewPosition(float currentPosition, float input, float speed, 
            float maxPosition, float minPosition)
        {
            var sign = Math.Sign(input);
            currentPosition += sign * speed * Time.deltaTime;

            if (currentPosition > maxPosition)
            {
                currentPosition = maxPosition;
            }

            if (currentPosition < minPosition)
            {
                currentPosition = minPosition;
            }

            return currentPosition;
        }
    }
}
