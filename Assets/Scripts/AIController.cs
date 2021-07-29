using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform followTarget;
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    public enum aiState { Follow, AttackAndFollow };
    public aiState currentState = aiState.Follow;

    public bool canAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Pawn item in FindObjectsOfType<Pawn>())
        {
            if (item.gameObject.CompareTag("Player"))
            {
                followTarget = item.transform;
                return;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == aiState.Follow)
        {
            if (followTarget != null)
            {
                FollowTarget(followTarget.transform);
            }
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if (canAttack)
            {

            }
        }
        else if (currentState == aiState.AttackAndFollow)
        {
            // TODO: Attack and follow stuff
            if (!canAttack)
            {

            }
        }
    }

    public void FollowTarget(Transform targetToFollow)
    {
        Vector3 vectorToTarget = targetToFollow.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);
        transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
