using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class PlayerMovement3D : MonoBehaviour
    {
        [SerializeField] private float speed = 0.3f;
        private Vector3 motion;
        private Rigidbody rb;
        [SerializeField] private float JumpForce = 1f;

        [SerializeField] private LayerMask GroundLayer = 1;
        private CapsuleCollider collider;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            collider = GetComponent<CapsuleCollider>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        // Update is called once per frame
        void Update()
        {
            JumpLogic();

            motion = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            rb.AddForce(motion * speed, ForceMode.Impulse);
        }
        private bool IsGrounded
        {
            get {
                var bottomCenterPoint = new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z);
                return Physics.CheckCapsule(collider.bounds.center, bottomCenterPoint, collider.bounds.size.x / 2 * 0.9f, GroundLayer);
                }            
        }

        private void JumpLogic()
        {
            if (Input.GetAxis("Jump") > 0)
            {
                if (IsGrounded && (Input.GetAxis("Jump") > 0))
                {
                    rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                }
            }
        }

        //void OnCollisionEnter(Collision collision)
        //{
        //    IsGroundedUpate(collision, true);
        //}

        //void OnCollisionExit(Collision collision)
        //{
        //    IsGroundedUpate(collision, false);
        //}

    }
}
