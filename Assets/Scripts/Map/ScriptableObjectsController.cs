using UnityEngine;

public class ScriptableObjectsController : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] _scriptableObjects;
    [SerializeField] private MapDisplay _mapDisplay;

    private int _curentIndex;

    private void Awake()
    {
        ChangScriptableObject(0);
    }

    public void ChangScriptableObject(int chang)
    {
        _curentIndex += chang;

        if (_curentIndex < 0)
            _curentIndex = _scriptableObjects.Length - 1;
        else if (_curentIndex > _scriptableObjects.Length - 1)
            _curentIndex = 0;

        if (_mapDisplay != null)
            _mapDisplay.DisplayMap((Map)_scriptableObjects[_curentIndex]);
    }
}
