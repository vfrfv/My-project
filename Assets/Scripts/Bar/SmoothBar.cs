using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    [RequireComponent(typeof(Slider))]
    public class SmoothBar : MonoBehaviour
    {
        [SerializeField] private Health _helthSourse;

        private IValue _value;
        private Coroutine _coroutine;
        private Slider _slider;

        public IValue Value => _value;

        private void Awake()
        {
            if (_helthSourse == null)
            {
                return;
            }

            Init(_helthSourse.GetComponent<IValue>());

            _slider = GetComponent<Slider>();
        }

        private void OnDestroy()
        {
            _value.Changed -= Fill;
        }

        public void Init(IValue health)
        {
            _slider.SetValueWithoutNotify(health.Value);
            _value = health;
            _value.Changed += Fill;
        }

        private void Fill(int currentValue)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(SmoothlyChange(currentValue));
        }

        private IEnumerator SmoothlyChange(float currentValue)
        {
            float degreeVolumeChange = 1f;
            bool IsChanges = true;
            currentValue /= _value.MaxValue;

            while (IsChanges)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, currentValue, degreeVolumeChange * Time.deltaTime);

                yield return null;
            }
        }
    }
}