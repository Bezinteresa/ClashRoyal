
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NavMeshMove", menuName = "UnitState/NavMeshMove")]
public class NavMeshMove : UnitState
{
    [SerializeField] private bool _isEnemy = false;
    [SerializeField] private float _moveOffset = 1f;
    private Vector3 _targetPosition;
    private NavMeshAgent _agent;

    public override void Init() {

        Vector3 unitPosition = _unit.transform.position;
        _targetPosition = MapInfo.Instance.GetNearestTowerPositin(in unitPosition, _isEnemy == false);

        _agent = _unit.GetComponent<NavMeshAgent>();
        _agent.SetDestination(_targetPosition);



    }

    public override void Run() {
        float distanceToTarget = Vector3.Distance(_unit.transform.position, _targetPosition);
        if (distanceToTarget <= _moveOffset) {
            Debug.Log("Добежал");
            _unit.SetState(UnitStateType.Attack);
        
        }
    }

    public override void Finish() {
        _agent.isStopped = true;

    }




}
