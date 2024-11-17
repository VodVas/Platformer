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

    private void OnEnable()
    {
        _vampiricAbility.ActivatedSkill += ActivateCircle;
        _vampiricAbility.DeactivatedSkill += DeactivateCircle;
    }

    private void OnDisable()
    {
        _vampiricAbility.ActivatedSkill -= ActivateCircle;
        _vampiricAbility.DeactivatedSkill -= DeactivateCircle;
    }

    private void ActivateCircle()
    {
        _circle.SetActive(true);
    }

    private void DeactivateCircle()
    {
        _circle.SetActive(false);
    }
}