using UnityEngine;

namespace Sample.Entities
{
    public sealed class MovementComponent : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5.0f;

        public void Move(Vector3 direction, float delaTime)
        {
            transform.position += direction * (_speed * delaTime);
        }
    }
}