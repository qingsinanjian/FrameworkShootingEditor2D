using FrameworkDesign;

namespace ShootingEditor2D
{

    public class FullBulletCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>();
            var gunConfigModel = this.GetModel<IGunConfigModel>();

            gunSystem.CurrentGun.BulletCountInGun.Value = 
                gunConfigModel.GetGunConfigItemByName(gunSystem.CurrentGun.Name.Value).BulletMaxCount;

            foreach (var gunSystemGunInfo in gunSystem.GunInfos)
            {
                gunSystemGunInfo.BulletCountInGun.Value =
                    gunConfigModel.GetGunConfigItemByName(gunSystemGunInfo.Name.Value).BulletMaxCount;
            }
        }
    }
}