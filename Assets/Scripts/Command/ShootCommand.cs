using FrameworkDesign;

namespace ShootingEditor2D
{
    public class ShootCommand : AbstractCommand
    {
        public static readonly ShootCommand Single = new ShootCommand();//使用单例，减少new的次数，一种优化方式
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>().CurrentGun;
            gunSystem.BulletCountInGun.Value--;
            gunSystem.GunState.Value = GunState.Shooting;
            this.GetSystem<ITimeSystem>().AddDelayTask(0.33f, () =>
            {
                gunSystem.GunState.Value = GunState.Idle;
            });
        }
    }
}
