using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using BaseClasses;
using System;

namespace script
{

    public class PlayerController : MonoBehaviour {


        public static Transform Cam;
        private Rigidbody _rig;
        private Vector3 _camRot = nVector.zero;
        private CapsuleCollider capsuleCollider;
        private void Awake()
        {
            Cam = Camera.main.transform;
            _rig = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            //Vector3 move = transform.rotation * Movement();
            //_rig.velocity = new Vector3(move.x ,_rig.velocity.y,move.z);
            _rig.velocity = transform.rotation * Movement();
            transform.Rotate(Look());
            StickToGround();
           

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftShift))
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
#endif
        }
        private void StickToGround()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position,  Vector3.down * (PlayerManager.Instance.Footstep + 1f),Color.red);
            if (!Physics.Raycast(transform.position, Vector3.down, out hit, PlayerManager.Instance.Footstep + 1f))
            {
                _rig.velocity += Vector3.down * _rig.velocity.magnitude;
            }
        }

        private Vector3 Look()
        {
            if (PlayerManager.Instance.LockMovement)
                return nVector.zero;
            var hor = Input.GetAxis("MouseX") * PlayerManager.Instance.MouseSensitivity + Input.GetAxis("JoyX") * PlayerManager.Instance.JoystickSensitivity;
            var ver = Input.GetAxis("MouseY") * PlayerManager.Instance.MouseSensitivity + Input.GetAxis("JoyY") * PlayerManager.Instance.JoystickSensitivity;
            
            if (PlayerManager.Instance.InvertMouse)
                ver *= -1;
            _camRot.x = Mathf.Clamp(_camRot.x + ver * Time.deltaTime, -PlayerManager.Instance.TopDownRotationLock, PlayerManager.Instance.TopDownRotationLock);
            Cam.localEulerAngles = _camRot;
            return new Vector3(0, hor, 0)  * Time.deltaTime;
        }

        private Vector3 Movement()
        {
            if (PlayerManager.Instance.LockMovement)
                return nVector.zero;
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");
            return new Vector3(hor, 0, ver).normalized * PlayerManager.Instance.MovementSpeed * Time.deltaTime;
        }

    }
}
