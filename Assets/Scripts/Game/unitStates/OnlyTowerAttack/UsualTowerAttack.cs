using UnityEngine;

[CreateAssetMenu(fileName = "UsualTowerAttack", menuName = "UnitState/UsualTowerAttack")]

public class UsualTowerAttack : UnitStateAttack
{

    protected override bool TryFindTarget(out float stopAttackDistance)
    {
        Vector3 unitPosition = _unit.transform.position;

        //Тут наша цель только башня, юнита не ищем

        Tower targetTower = MapInfo.Instance.GetNearestTower(unitPosition, _targetIsEnemy);
        if (targetTower.GetDistance(unitPosition) <= _unit.parameters.startAttackDistance)
        {
            _target = targetTower.health;
            stopAttackDistance = _unit.parameters.stopAttackDiaaaastance + targetTower._radius;
            return true;
        }

        stopAttackDistance = 0;
        return false;
    }
}
