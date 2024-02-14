using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarViewSlider : HealthView
{
	private const float MinValue = 0.01f;
	
	[SerializeField] private Slider _abruptHealthBar;
	[SerializeField] private Slider _smoothHealthBar;
	[SerializeField] private float _smoothSpeed;
	
	private Coroutine _smoothUpdateCoroutine;
	
	private void OnEnable()
	{
		_smoothHealthBar.maxValue = MaxHealth;
		_abruptHealthBar.maxValue = MaxHealth;
	}

	protected override void UpdateHealth(float targetValue)
	{
		_abruptHealthBar.value = targetValue;

		if (_smoothUpdateCoroutine != null)
		{
			StopCoroutine(_smoothUpdateCoroutine);
		}

		_smoothUpdateCoroutine = StartCoroutine(SmoothUpdateCoroutine(targetValue));
	}
	
	private IEnumerator SmoothUpdateCoroutine(float targetValue)
	{
		while (Mathf.Abs(_smoothHealthBar.value - targetValue) > MinValue)
		{
			_smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, targetValue, Time.deltaTime * _smoothSpeed);
			yield return null;
		}

		_smoothHealthBar.value = targetValue;
		_smoothUpdateCoroutine = null;
	}
}