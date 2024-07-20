using UnityEngine;
using UnityEngine.AI;

public class Barrier : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private BoxCollider _openingArea;
    [SerializeField] private NavMeshObstacle _obstacle;
    [SerializeField] private Arrow _arrow;

    private bool _inPlace = false;

    private void Start()
    {
        _openingArea.enabled = false;
        _arrow.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _inPlace = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _inPlace)
        {
            Open();
        }
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
        //_hingeJoint.spring.targetPosition;

        JointSpring jointSpring = _hingeJoint.spring;
        jointSpring.targetPosition = 60f;
        _hingeJoint.spring = jointSpring;

        _obstacle.enabled = false;
        _arrow.gameObject.SetActive(false);
    }
}
