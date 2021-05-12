using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum EnemyStates { 
        idle = 1, 
        patrolling = 2, 
        alerted = 3 
    };
    public EnemyStates state;
    
    [SerializeField]
    Transform PlayerBody;

    IEnumerator StateChange()
    {
        yield return new WaitForSeconds(3);
        List<Transform> visibleTargets = GetComponentInChildren<FOV>().visibleTargets;
        Animator anim = GetComponentInChildren<Patrol>().anim;
        switch (state)
        {
            case EnemyStates.alerted:
                if (visibleTargets.Count != 0)
                {
                    transform.LookAt(new Vector3(PlayerBody.position.x, transform.position.y, PlayerBody.position.z));
                }
                else
                {
                    state = EnemyStates.patrolling;
                    transform.LookAt(GetComponent<Patrol>().destination);
                    anim.SetBool("isWalking", true);
                }
                break;
            default:
                yield return new WaitForSeconds(3);
                visibleTargets = GetComponentInChildren<FOV>().visibleTargets;
                if (visibleTargets.Count != 0)
                {
                    anim.SetBool("isWalking", false);
                    transform.LookAt(new Vector3(PlayerBody.position.x,transform.position.y,PlayerBody.position.z));
                    state = EnemyStates.alerted;
                }
                break;
        }
    }
    public void EnemySeesPlayer(bool seesPlayer,MeshRenderer enemyVisionMesh)
    {
        if (seesPlayer)
        {
            enemyVisionMesh.material.color = Color.red;
            StartCoroutine("StateChange");
        }
        else
        {
            enemyVisionMesh.material.color = Color.gray;
            StartCoroutine("StateChange");
        }
    }
}
