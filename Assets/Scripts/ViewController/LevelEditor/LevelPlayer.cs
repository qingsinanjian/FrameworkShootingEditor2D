using System.Xml;
using UnityEngine;

namespace ShootingEditor2D
{
    public class LevelPlayer : MonoBehaviour
    {
        public TextAsset levelFile;

        private void Start()
        {
            var xml = levelFile.text;

            var document = new XmlDocument();
            document.LoadXml(xml);
            var levelNode = document.SelectSingleNode("Level");
            foreach (XmlElement levelItemNode in levelNode.ChildNodes)
            {
                var levelItemName = levelItemNode.Attributes["name"].Value;
                var levelItemX = int.Parse(levelItemNode.Attributes["x"].Value);
                var levelItemY = int.Parse(levelItemNode.GetAttribute("y"));

                var levelItemPrefab = Resources.Load<GameObject>(levelItemName);
                var leveItemGameObj = Instantiate(levelItemPrefab, transform);
                leveItemGameObj.transform.position = new Vector3(levelItemX, levelItemY, 0);

                //Debug.Log($"levelItemName : {levelItemName}, levelItemX : {levelItemX}, levelItemY : {levelItemY}");
            }
        }
    }
}