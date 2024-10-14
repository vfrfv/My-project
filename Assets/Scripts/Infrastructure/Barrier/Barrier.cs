using UnityEngine;
using UnityEngine.AI;

public class Barrier : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private BoxCollider _openingArea;
    [SerializeField] private NavMeshObstacle _obstacle;
    [SerializeField] private Arrow _arrow;

    private void Start()
    {
        _openingArea.enabled = false;
        _arrow.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            Open();
    }

    public void OpenZone()
    {
        _openingArea.enabled = true;
        _arrow.gameObject.SetActive(true);
    }

    public void CloseZone()
    {
        _openingArea.enabled = false;
    }

    public void Open()
    {
        JointSpring jointSpring = _hingeJoint.spring;
        jointSpring.targetPosition = 60f;
        _hingeJoint.spring = jointSpring;

        _obstacle.enabled = false;
        _arrow.gameObject.SetActive(false);
    }
}