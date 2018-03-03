using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

/// <summary>
/// Expose the ARSession and ARConfiguration.
/// </summary>

public class CameraManagerWithSession : UnityARCameraManager
{
  public ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration();
  public UnityARSessionNativeInterface session;

  void Start()
  {
    session = UnityARSessionNativeInterface.GetARSessionNativeInterface();

    Application.targetFrameRate = 60;
    config.planeDetection = planeDetection;
    config.alignment = startAlignment;
    config.getPointCloudData = getPointCloud;
    config.enableLightEstimation = enableLightEstimation;

    if (config.IsSupported)
    {
      session.RunWithConfig(config);
    }

    if (m_camera == null)
    {
      m_camera = Camera.main;
    }
  }

  void Update()
  {
    if (m_camera != null)
    {
      Matrix4x4 matrix = session.GetCameraPose();
      m_camera.transform.localPosition = UnityARMatrixOps.GetPosition(matrix);
      m_camera.transform.localRotation = UnityARMatrixOps.GetRotation(matrix);

      m_camera.projectionMatrix = session.GetCameraProjection();
    }
  }
}
