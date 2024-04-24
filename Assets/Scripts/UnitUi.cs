
using UnityEngine;
using UnityEngine.UI;

public class UnitUi : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _fillHealthImage;
    private float _maxHealth;

    private void Start()
    {
        _healthBar.SetActive(false);
        _maxHealth = _unit.health.max;
        _unit.health.UpdateHealth += UpdateHealth;
    }

    private void OnDestroy()
    {
        _unit.health.UpdateHealth -= UpdateHealth;
    }

    private void UpdateHealth(float currentValue)
    {
        _healthBar.SetActive(true);
        _fillHealthImage.fillAmount = currentValue / _maxHealth;
    }

}
