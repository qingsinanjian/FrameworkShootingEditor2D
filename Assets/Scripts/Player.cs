using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEditor2D
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D mRigidbody2D;
        private Trigger2DCheck mTrigger2DCheck;

        private bool mJumpPressed;

        private void Start()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mTrigger2DCheck = transform.Find("GroundCheck").GetComponent<Trigger2DCheck>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                mJumpPressed = true;
            }
        }

        private void FixedUpdate()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            mRigidbody2D.velocity = new Vector2(horizontalMovement * 5, mRigidbody2D.velocity.y);

            var grounded = mTrigger2DCheck.Triggered;

            if (mJumpPressed && grounded)
            {
                mRigidbody2D.velocity = new Vector2(mRigidbody2D.velocity.x, 5);
            }

            mJumpPressed = false;
        }
    }
}