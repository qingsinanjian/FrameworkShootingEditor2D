using FrameworkDesign;

namespace ShootingEditor2D
{
    public class AddBulletCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>();
            var gunConfigModel = this.GetModel<IGunConfigModel>();

            AddBullet(gunSystem.CurrentGun, gunConfigModel);

            foreach (var gunSystemGunInfo in gunSystem.GunInfos)
            {
                AddBullet(gunSystemGunInfo, gunConfigModel);
            }
        }

        private void AddBullet(GunInfo gunInfo, IGunConfigModel gunConfigModel)
        {
            var gunConfigItem = gunConfigModel.GetGunConfigItemByName(gunInfo.Name.Value);

            if(!gunConfigItem.NeedBullet)//不需要子弹就是手枪
            {
                gunInfo.BulletCountInGun.Value = gunConfigItem.BulletMaxCount;
            }
            else
            {
                gunInfo.BulletCountOutGun.Value += gunConfigItem.BulletMaxCount;
            }
        }
    }
}