using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	[field: SerializeField] public float MaxHealth { get; private set; }
	
	private const float MinHealth = 0f;
	
	private float _currentValue;
	
	public event Action<float> ValueChanged;
	

	private void Awake() =>
		_currentValue = MaxHealth;

	public void TakeDamage(float damage)
	{
		_currentValue -= damage;
		
		_currentValue = Mathf.Clamp(_currentValue, MinHealth, MaxHealth);
		ValueChanged?.Invoke(_currentValue);
	}

	public void Heal(float heal)
	{
		_currentValue += heal;
		
		_currentValue = Mathf.Clamp(_currentValue, MinHealth, MaxHealth);
		ValueChanged?.Invoke(_currentValue);
	}
}