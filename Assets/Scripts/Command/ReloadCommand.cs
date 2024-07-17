using FrameworkDesign;

namespace ShootingEditor2D
{
    public class ReloadCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var currentGun = this.GetSystem<IGunSystem>().CurrentGun;
            var gunConfigItem = this.GetModel<IGunConfigModel>().GetGunConfigItemByName(currentGun.Name.Value);
            //��Ҫ�ӵ�������
            var needBulletCount = gunConfigItem.BulletMaxCount - currentGun.BulletCountInGun.Value;
            if (needBulletCount > 0)
            {                
                currentGun.GunState.Value = GunState.Reload;
                this.GetSystem<ITimeSystem>().AddDelayTask(gunConfigItem.ReloadSeconds, () =>
                {
                    if (currentGun.BulletCountOutGun.Value > 0)
                    {
                        if (currentGun.BulletCountOutGun.Value >= needBulletCount)
                        {
                            //���ǹ���ӵ�����
                            currentGun.BulletCountInGun.Value += needBulletCount;
                            currentGun.BulletCountOutGun.Value -= needBulletCount;
                        }
                        else
                        {
                            currentGun.BulletCountInGun.Value += currentGun.BulletCountOutGun.Value;
                            currentGun.BulletCountOutGun.Value = 0;
                        }
                    }

                    currentGun.GunState.Value = GunState.Idle;
                });
            }
        }
    }
}