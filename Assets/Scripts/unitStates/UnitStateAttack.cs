using UnityEngine;

public abstract class UnitStateAttack : UnitState
{
    [SerializeField] protected float _damage = 1.5f;
    private float _delay = 1f;
    private float _time = 0;
    private float _stopAttackDisctance = 0;
    protected bool _targetIsEnemy;
    protected Health _target;

    public override void Constructor(Unit unit)
    {
        base.Constructor(unit);
        _targetIsEnemy = _unit.isEnemy == false;
        _delay = _unit.parameters.damageDelay;
    }

    public override void Init()
    {
        if (TryFindTarget(out _stopAttackDisctance) == false)
        {
            _unit.SetState(UnitStateType.Default);
            return;
        }

        _time = 0;
        _unit.transform.LookAt(_target.transform.position);

    }

    public override void Run()
    {
        _time += Time.deltaTime;
        //Если время меньше задержки возврат
        if (_time < _delay) return;
        _time -= _delay;

        if (_target == false)
        {
            _unit.SetState(UnitStateType.Default);
            return;
        }

        float distanceToTarget = Vector3.Distance(_target.transform.position, _unit.transform.position);
        if (distanceToTarget > _stopAttackDisctance) _unit.SetState(UnitStateType.Chase);

        Attack();
    }

    protected virtual void Attack()
    {
        _target.ApplyDamage(_damage);
    }

    public override void Finish()
    {

    }

    protected abstract bool TryFindTarget(out float stopAttackDistance);
    
}
