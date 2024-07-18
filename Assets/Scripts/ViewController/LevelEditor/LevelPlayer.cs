using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace ShootingEditor2D
{
    public class LevelPlayer : MonoBehaviour
    {
        private string mLevelFilesFolder;

        private void Awake()
        {
            mLevelFilesFolder = Application.persistentDataPath + "/LevelFiles";
        }

        private enum State
        {
            Selection,
            Playing
        }
        private State mCurrentState = State.Selection;

        private void ParseAndRun(string xml)
        {
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

        private void OnGUI()
        {
            if(mCurrentState == State.Selection)
            {
                var filePaths = Directory.GetFiles(mLevelFilesFolder);
                int y = 10;
                foreach (var filePath in filePaths.Where( f => f.EndsWith("xml")))
                {
                    var fileName = Path.GetFileName(filePath);
                    if(GUI.Button(new Rect(10, y, 100, 40), fileName))
                    {
                        var xml = File.ReadAllText(filePath);
                        ParseAndRun(xml);
                        mCurrentState = State.Playing;
                    }

                    y += 50;
                }
            }
        }
    }
}