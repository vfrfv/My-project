using Assets.Scripts.Maps.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Maps
{
    public class MapsController : MonoBehaviour
    {
        [SerializeField] private Map[] _maps;
        [SerializeField] private MapDisplay _mapDisplay;

        private int _currentIndex;

        private void Awake()
        {
            ChangScriptableObject(0);
        }

        public void ChangScriptableObject(int chang)
        {
            _currentIndex += chang;

            if (_currentIndex < 0)
                _currentIndex = _maps.Length - 1;
            else if (_currentIndex > _maps.Length - 1)
                _currentIndex = 0;

            if (_mapDisplay != null)
                _mapDisplay.DisplayMap(_maps[_currentIndex]);
        }
    }
}