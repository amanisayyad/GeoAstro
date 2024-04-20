using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{

    public class AstronautThirdPersonCamera : MonoBehaviour
    {
        private const float Y_ANGLE_MIN = 0.0f;
        private const float Y_ANGLE_MAX = 50.0f;

        public Transform playerTransform;
        public Transform camTransform;
        public float distance = 5.0f;
        public float bottomThreshold = -10.0f; // Adjust this threshold based on your sphere size

        private float currentX = 0.0f;
        private float currentY = 45.0f;
        private float sensitivityX = 20.0f;
        private float sensitivityY = 20.0f;

        private void Start()
        {
            camTransform = transform;
        }

        private void Update()
        {
            currentX += Input.GetAxis("Mouse X");
            currentY += Input.GetAxis("Mouse Y");

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        private void LateUpdate()
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 playerPosition = playerTransform.position + rotation * dir;

            // Check if the player is below the bottom threshold
            if (playerPosition.y < bottomThreshold)
            {
                // Move the camera above the player
                playerPosition.y = bottomThreshold;
            }

            camTransform.position = playerPosition;
            camTransform.rotation = rotation;

            camTransform.LookAt(playerTransform.position);
        }
    }
}
//private const float Y_ANGLE_MIN = 0.0f;
//private const float Y_ANGLE_MAX = 50.0f;

//public Transform lookAt;
//public Transform camTransform;
//public float distance = 5.0f;

//private float currentX = 0.0f;
//private float currentY = 45.0f;
//private float sensitivityX = 20.0f;
//private float sensitivityY = 20.0f;

//private void Start()
//{
//    camTransform = transform;
//}

//private void Update()
//{
//    currentX += Input.GetAxis("Mouse X");
//    currentY += Input.GetAxis("Mouse Y");

//    currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
//}

//private void LateUpdate()
//{
//    Vector3 dir = new Vector3(0, 0, -distance);
//    Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
//    camTransform.position = lookAt.position + rotation * dir;
//    camTransform.LookAt(lookAt.position);
//}
//          }
//        }
//        public Transform playerTransform;
//        public float rotationSpeed = 5.0f;
//        public float zoomSpeed = 5.0f;
//        public float minZoomDistance = 2.0f;
//        public float maxZoomDistance = 50.0f;

//        void Start()
//        {
//            // Ensure the camera starts at a reasonable distance from the player
//            Camera.main.transform.position = new Vector3(0.74f, 1.5f, 14.5f);
//        }

//        void Update()
//        {
//            float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

//            // Adjust the camera's field of view based on the scroll wheel input
//            Camera.main.fieldOfView += -scrollWheelInput * zoomSpeed;

//            // Clamp the field of view to avoid extreme values
//            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minZoomDistance, maxZoomDistance);
//        }

//        void LateUpdate()
//        {
//            if (playerTransform)
//            {
//                // Rotate the camera around the player based on user input
//                float horizontalInput = Input.GetAxis("Horizontal");
//                transform.RotateAround(playerTransform.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

//                // Position the camera behind the player
//                Vector3 desiredPosition = playerTransform.position - playerTransform.forward * 5.0f + Vector3.up * 2.0f;
//                transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5.0f);

//                // Make the camera look at the player
//                transform.LookAt(playerTransform);
//            }
//        }
//    }
//}