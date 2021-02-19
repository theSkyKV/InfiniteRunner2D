using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HealthUnit _healthUnitTemplate;

    private List<HealthUnit> _healthUnits;

    private void OnEnable()
    {
        _healthUnits = new List<HealthUnit>();
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_healthUnits.Count < value)
        {
            var createdHealthUnits = value - _healthUnits.Count;
            for (var i = 0; i < createdHealthUnits; i++)
                CreateHealthUnit();
        }
        else if (_healthUnits.Count > value)
        {
            var deletedHealthUnits = _healthUnits.Count - value;
            for (var i = 0; i < deletedHealthUnits; i++)
                DeleteHealthUnit(_healthUnits[_healthUnits.Count - 1]);
        }
    }

    private void CreateHealthUnit()
    {
        var healthUnit = Instantiate(_healthUnitTemplate, transform);
        _healthUnits.Add(healthUnit.GetComponent<HealthUnit>());
        healthUnit.ToFill();
    }

    private void DeleteHealthUnit(HealthUnit healthUnit)
    {
        _healthUnits.Remove(healthUnit);
        healthUnit.ToEmpty();
    }
}
