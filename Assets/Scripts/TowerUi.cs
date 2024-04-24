
using UnityEngine;
using UnityEngine.UI;

public class TowerUi : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _fillHealthImage;
    private float _maxHealth;

    private void Start()
    {
        _healthBar.SetActive(false);
        _maxHealth = _tower.health.max;
        _tower.health.UpdateHealth += UpdateHealth;
    }

    private void OnDestroy()
    {
        _tower.health.UpdateHealth -= UpdateHealth;
    }

    private void UpdateHealth(float currentValue)
    {
        _healthBar.SetActive(true);
        _fillHealthImage.fillAmount = currentValue / _maxHealth;
    }
}
