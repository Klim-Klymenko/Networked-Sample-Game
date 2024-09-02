using UnityEngine;

namespace Sample.Entities
{
    public interface IState
    {
        void Enter(GameObject entity);
        void Update(GameObject entity, float deltaTime);
        void Exit(GameObject entity);
    }
}