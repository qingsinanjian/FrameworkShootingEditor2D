using UnityEngine;

namespace ShootingEditor2D
{
    public class CameraController : MonoBehaviour
    {
        private Transform mPlayerTrans;

        private Vector3 mTargetPos;

        //±ß½çµÄ·¶Î§
        private float xMin = -5;
        private float xMax = 5;
        private float yMin = -5;
        private float yMax = 5;

        private void LateUpdate()
        {
            if (!mPlayerTrans)
            {
                var playerGameObj = GameObject.FindWithTag("Player");
                if(playerGameObj != null)
                {
                    mPlayerTrans = playerGameObj.transform;
                }
                else
                {
                    return;
                }
                
            }

            var cameraPos = transform.position;
            var isRight = Mathf.Sign(mPlayerTrans.localScale.x);
            var playerPos = mPlayerTrans.position;
            mTargetPos.x = playerPos.x + 3 * isRight;
            mTargetPos.y = playerPos.y + 2;
            mTargetPos.z = -10;

            var smoothSpeed = 5;
            var position = transform.position;
            position = Vector3.Lerp(position, mTargetPos, smoothSpeed * Time.deltaTime);

            transform.position = new Vector3(Mathf.Clamp(position.x, xMin, xMax), Mathf.Clamp(position.y, yMin, yMax), position.z);
        }
    }
}

