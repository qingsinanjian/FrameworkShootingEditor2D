using FrameworkDesign;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Bullet : MonoBehaviour, IController
    {
        private Rigidbody2D mRigidbody2D;

        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            Destroy(gameObject, 5);
        }

        private void Start()
        {
            mRigidbody2D.velocity = Vector2.right * 10;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                this.SendCommand<KillEnemyCommand>();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditor2D.Interface;
        }
    }
}
