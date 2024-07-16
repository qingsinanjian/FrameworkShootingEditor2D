﻿using FrameworkDesign;

namespace ShootingEditor2D
{
    public class ShootCommand : AbstractCommand
    {
        public static readonly ShootCommand Single = new ShootCommand();//使用单例，减少new的次数，一种优化方式
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>();
            gunSystem.CurrentGun.BulletCountInGun.Value--;
            gunSystem.CurrentGun.GunState.Value = GunState.Shooting;
            var gunConfigItem = this.GetModel<IGunConfigModel>().GetGunConfigItemByName(gunSystem.CurrentGun.Name.Value);
            this.GetSystem<ITimeSystem>().AddDelayTask(1/gunConfigItem.Frequency, () =>
            {
                gunSystem.CurrentGun.GunState.Value = GunState.Idle;
            });
        }
    }
}
