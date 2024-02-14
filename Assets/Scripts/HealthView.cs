using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
	[SerializeField] private Health _health;

	protected float MaxHealth => _health.MaxHealth;
	
	private void Awake()
	{
		_health.ValueChanged += UpdateHealth;
	}

	protected abstract void UpdateHealth(float targetValue);
}