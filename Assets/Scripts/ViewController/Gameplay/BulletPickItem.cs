using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class BulletPickItem : MonoBehaviour, IController
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                this.SendCommand(new AddBulletCommand());
                Destroy(this.gameObject);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}