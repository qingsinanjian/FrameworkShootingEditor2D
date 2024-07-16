using FrameworkDesign;
using UnityEditor.U2D.Path.GUIFramework;

namespace ShootingEditor2D
{
    public class MaxBulletCountQuery : AbstractQuery<int>
    {
        private readonly string mGunName;

        public MaxBulletCountQuery(string gunName)
        {
            mGunName = gunName;
        }

        protected override int OnDo()
        {
            var gunConfigModel = this.GetModel<IGunConfigModel>();
            var gunConfigItem = gunConfigModel.GetGunConfigItemByName(mGunName);
            return gunConfigItem.BulletMaxCount;
        }
    }
}