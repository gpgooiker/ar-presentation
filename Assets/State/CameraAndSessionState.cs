using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

/// <summary>
/// Expose the ARSession and ARConfiguration. Attach this class to a GameObject in Unity, so Unity will
/// instantiate it.
/// </summary>

public class CameraAndSessionState : UnityARCameraManager
{
  private ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration();
  private UnityARSessionNativeInterface ARSessionInterface;

  void Start()
  {
    ARSessionInterface = UnityARSessionNativeInterface.GetARSessionNativeInterface();

    Application.targetFrameRate = 60;
    config.planeDetection = planeDetection;
    config.alignment = startAlignment;
    config.getPointCloudData = getPointCloud;
    config.enableLightEstimation = enableLightEstimation;

    if (config.IsSupported)
    {
      ARSessionInterface.RunWithConfig(config);
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
      Matrix4x4 matrix = ARSessionInterface.GetCameraPose();
      m_camera.transform.localPosition = UnityARMatrixOps.GetPosition(matrix);
      m_camera.transform.localRotation = UnityARMatrixOps.GetRotation(matrix);

      m_camera.projectionMatrix = ARSessionInterface.GetCameraProjection();
    }
  }

  public ARKitWorldTrackingSessionConfiguration GetWorldTrackingConfiguration() {
    return config;
  }
}
