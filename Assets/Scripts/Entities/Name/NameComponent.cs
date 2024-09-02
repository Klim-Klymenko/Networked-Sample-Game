using Fusion;

namespace Entities
{
    public sealed class NameComponent : NetworkBehaviour
    {
        public override void Spawned()
        {
            gameObject.name = Object.InputAuthority.ToString();
        }
    }
}