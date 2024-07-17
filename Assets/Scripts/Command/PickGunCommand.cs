using FrameworkDesign;

namespace ShootingEditor2D
{
    public class PickGunCommand : AbstractCommand
    {
        private readonly string mName;
        private readonly int mInGunBullets;
        private readonly int mOutGunBullets;

        public PickGunCommand(string name, int inGunBullets, int outGunBullets)
        {
            this.mName = name;
            this.mInGunBullets = inGunBullets;
            this.mOutGunBullets = outGunBullets;
        }

        protected override void OnExecute()
        {
            this.GetSystem<IGunSystem>().PickGun(mName, mInGunBullets, mOutGunBullets);
        }
    }
}