using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D
{
    public class GunPickItem : MonoBehaviour, IController
    {
        public string Name;
        public int BulletCountInGun;
        public int BulletCountOutGun;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                this.SendCommand(new PickGunCommand(Name, BulletCountInGun, BulletCountOutGun));
                Destroy(this.gameObject);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}