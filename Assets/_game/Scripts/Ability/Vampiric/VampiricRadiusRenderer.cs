using UnityEngine;

[RequireComponent(typeof(VampireAbility))]
public class VampiricRadiusRenderer : MonoBehaviour
{
    [SerializeField] private VampireAbility _vampiricAbility;
    [SerializeField] private GameObject _circle;

    private int _radiusMultiplier = 2;

    private void Awake()
    {
        _circle.transform.localScale = new Vector2(_vampiricAbility.Radius * _radiusMultiplier, _vampiricAbility.Radius * _radiusMultiplier);
    }

    private void Update()
    {
        if (_vampiricAbility.IsActive)
        {
            _circle.SetActive(true);
        }
        else
        {
            _circle.SetActive(false);
        }
    }
}