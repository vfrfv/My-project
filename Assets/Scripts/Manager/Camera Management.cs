using Cinemachine;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cameraPlayer;
    [SerializeField] private CinemachineVirtualCamera _cameraBoss;
    [SerializeField] private CinemachineVirtualCamera _cameraTowerBoss;

    private void Start()
    {
        _cameraPlayer.gameObject.SetActive(true);
        _cameraBoss.gameObject.SetActive(false);
        _cameraTowerBoss.gameObject.SetActive(false);
    }

    public void SwitchToBoss()
    {
        _cameraPlayer.gameObject.SetActive(false);
        _cameraBoss.gameObject.SetActive(true);
    }

    public void SwitchToTowerBoss()
    {
        _cameraBoss.gameObject.SetActive(false);
        _cameraTowerBoss.gameObject.SetActive(true);
    }
}