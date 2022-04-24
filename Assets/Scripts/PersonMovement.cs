using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{

    [RequireComponent(typeof(Rigidbody))]
    public class PersonMovement : MonoBehaviour
    {

        [SerializeField] float MovementSpeed = 5f;
        public float JumpForce = 300f;
        private bool _isGrounded;
        private Rigidbody _rb;

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {

        }


        private void FixedUpdate()
        {
            MovementLogic();
            JumpLogic();
        }

        private void MovementLogic()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            transform.Translate(movement * MovementSpeed * Time.fixedDeltaTime);
        }

        private void JumpLogic()
        {
            if (Input.GetAxis("Jump") > 0)
            {
                if (_isGrounded)
                {
                    _rb.AddForce(Vector3.up * JumpForce);
                }
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            IsGroundedUpate(collision, true);
        }

        void OnCollisionExit(Collision collision)
        {
            IsGroundedUpate(collision, false);
        }

        private void IsGroundedUpate(Collision collision, bool value)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                _isGrounded = value;
            }
        }

    }
}