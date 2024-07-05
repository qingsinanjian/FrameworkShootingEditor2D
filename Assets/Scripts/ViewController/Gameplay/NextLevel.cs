using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingEditor2D
{
    public class NextLevel : MonoBehaviour
    {
        public string levelName;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene(levelName);
            }
        }
    }
}
