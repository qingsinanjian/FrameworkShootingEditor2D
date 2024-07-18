using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class AttackPlayer : ShootingEditor2DController
    {
        public int Hurt = 1;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                this.SendCommand(new HurtPlayerCommand(Hurt));
            }
        }
    }
}
