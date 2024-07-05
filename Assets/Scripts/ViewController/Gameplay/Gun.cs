using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Gun : MonoBehaviour, IController
    {
        private Bullet mBullet;
        private GunInfo mGunInfo;

        private void Awake()
        {
            mBullet = transform.Find("Bullet").GetComponent<Bullet>();
            mGunInfo = this.GetSystem<IGunSystem>().CurrentGun;
        }

        public void Shoot()
        {
            if(mGunInfo.BulletCount.Value > 0)
            {
                var bullet = Instantiate(mBullet, mBullet.transform.position, mBullet.transform.rotation);
                bullet.transform.localScale = mBullet.transform.lossyScale;
                bullet.gameObject.SetActive(true);
                this.SendCommand(new ShootCommand());
            }
            
        }

        private void OnDestroy()
        {
            mGunInfo = null;
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}