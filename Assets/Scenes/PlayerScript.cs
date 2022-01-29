using Mirror;
using UnityEngine;

namespace QuickStart
{
    public class PlayerScript : NetworkBehaviour
    {
        public GameObject CameraPosition;

        public GameObject CameraBoom;

        public float MovementScaler;

        private Vector3 MovementForce;
        private Vector3 OtherForces;

        private Vector3 rotation;
        public float lookSpeed;

        public float ZoomSpeed;

        void Start()
        {
            OtherForces = new Vector3(0, 0, 0);
        }

        public override void OnStartLocalPlayer()
        {
            Camera.main.transform.SetParent(CameraBoom.transform);
            Camera.main.transform.localPosition = CameraPosition.transform.localPosition;
        }

        void Update()
        {
            if (!isLocalPlayer) { return; }
            
            //float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
            //float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;
            //
            //transform.Rotate(0, moveX, 0);
            //transform.Translate(0, 0, moveZ);

            ///

            Vector3 horizontal = Input.GetAxisRaw("Horizontal") * transform.right;
            Vector3 vertical = Input.GetAxisRaw("Vertical") * transform.forward;

            Vector3 direction = horizontal + vertical;

            MovementForce = direction * MovementScaler;
            gameObject.GetComponent<Rigidbody>().velocity = MovementForce + OtherForces;

            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            transform.eulerAngles = new Vector3(0, rotation.y, 0);

            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            CameraBoom.transform.eulerAngles = transform.eulerAngles + new Vector3(rotation.x, 0, 0);

            if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
            {
                Camera.main.transform.localPosition += new Vector3(0, 0, Input.GetAxisRaw("Mouse ScrollWheel") * ZoomSpeed);
            }
        }
    }
}