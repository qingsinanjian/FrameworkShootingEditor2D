using FrameworkDesign;
using System.Collections.Generic;

namespace ShootingEditor2D
{
    public interface IGunConfigModel : IBelongToArchitecture, IModel
    {
        GunConfigItem GetGunConfigItemByName(string gunName);
    }

    public class GunConfigItem
    {
        public string Name { get; set; }
        public int BulletMaxCount { get; set; }
        public float Attack { get; set; }
        public float Frequency { get; set; }
        public float ShootDistance { get; set; }
        public bool NeedBullet { get; set; }
        public float ReloadSeconds { get; set; }
        public string Description { get; set; }

        public GunConfigItem(string name, int bulletMaxCount, float attack, float frequency, float shootDistance, bool needBullet, float reloadSeconds, string description)
        {
            Name = name;
            BulletMaxCount = bulletMaxCount;
            Attack = attack;
            Frequency = frequency;
            ShootDistance = shootDistance;
            NeedBullet = needBullet;
            ReloadSeconds = reloadSeconds;
            Description = description;
        }
    }

    public class GunConfigModel : AbstractModel, IGunConfigModel
    {
        private Dictionary<string, GunConfigItem> mItems = new Dictionary<string, GunConfigItem>()
        {
            { "ÊÖÇ¹", new GunConfigItem("ÊÖÇ¹", 7, 1, 1, 0.5f, false, 3, "Ä¬ÈÏÇ¹") },
            { "³å·æÇ¹", new GunConfigItem("³å·æÇ¹", 30, 1, 6, 0.34f, true, 3, "ÎÞ") },
            { "²½Ç¹", new GunConfigItem("²½Ç¹", 50, 3, 3, 1f, true, 1, "ÓÐÒ»¶¨ºó×øÁ¦") },
            { "¾Ñ»÷Ç¹", new GunConfigItem("¾Ñ»÷Ç¹", 12, 6, 1, 1f, true, 5, "ºìÍâÃé×¼+ºó×øÁ¦´ó") },
            { "»ð¼ýÍ²", new GunConfigItem("»ð¼ýÍ²", 1, 5, 1, 1f, true, 4, "¸ú×Ù+±¬Õ¨") },
            { "ö±µ¯Ç¹", new GunConfigItem("ö±µ¯Ç¹", 1, 1, 1, 0.5f, true, 1, "Ò»´Î·¢Éä6~12¸ö×Óµ¯") },
        };

        public override void OnInit()
        {
            
        }

        public GunConfigItem GetGunConfigItemByName(string gunName)
        {
            return mItems[gunName];
        }        
    }
}