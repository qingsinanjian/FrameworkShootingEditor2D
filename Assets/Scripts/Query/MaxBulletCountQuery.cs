using FrameworkDesign;
using UnityEditor.U2D.Path.GUIFramework;

namespace ShootingEditor2D
{
    public class MaxBulletCountQuery : ICanGetModel
    {
        private readonly string mGunName;

        public MaxBulletCountQuery(string gunName)
        {
            mGunName = gunName;
        }

        public int Do()
        {
            var gunConfigModel = this.GetModel<IGunConfigModel>();
            var gunConfigItem = gunConfigModel.GetGunConfigItemByName(mGunName);
            return gunConfigItem.BulletMaxCount;
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}