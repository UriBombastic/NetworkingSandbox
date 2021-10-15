using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//This class is literally just a rip off of First Person Control where only the aspects I needed were included
public class FirstPersonVehicleCamera : MonoBehaviour
{
    private CharacterController m_CharacterController;
    public Transform Camera;
    private Quaternion m_CameraTargetRot;
    public float XSensitivity =1;
    public float YSensitivity = 1;
    public bool clampRotation = true;
    public float MinimumX = -45;
    public float MaximumX = 45;
    public float MinimumY = -45;
    public float MaximumY = 45;
    // Start is called before the first frame update
    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        if (Camera == null) Camera = gameObject.transform;
        m_CameraTargetRot = Camera.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotateView();
    }

    private void RotateView()
    {
        float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
        float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

        m_CameraTargetRot *= Quaternion.Euler(-xRot, yRot, 0f);

        if (clampRotation)
            m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

            Camera.localRotation = m_CameraTargetRot;

    }


    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z = 0;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.y);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);
        angleY = Mathf.Clamp(angleY, MinimumY, MaximumY);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        q.y = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleY);

        return q;
    }
}
