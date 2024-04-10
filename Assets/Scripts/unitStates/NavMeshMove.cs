using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "NavMeshMove", menuName = "UnitState/NavMeshMove")]
public class NavMeshMove : UnitState
{
    [SerializeField] private float _moveOffset = 1f;
    private Vector3 _targetPosition;
    private NavMeshAgent _agent;

    public override void Init() {

        _agent = _unit.GetComponent<NavMeshAgent>();
        _targetPosition = Vector3.forward;
        _agent.SetDestination(_targetPosition);


    }

    public override void Run() {
        float distanceToTarget = Vector3.Distance(_unit.transform.position, _targetPosition);
        if (distanceToTarget <= _moveOffset) {
            Debug.Log("Добежал");
        
        }
    }

    public override void Finish() {



    }



}
