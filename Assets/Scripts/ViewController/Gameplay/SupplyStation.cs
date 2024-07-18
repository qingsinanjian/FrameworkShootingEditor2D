using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class SupplyStation : MonoBehaviour, IController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                this.SendCommand<FullBulletCommand>();
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}