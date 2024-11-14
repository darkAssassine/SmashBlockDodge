using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] CheckForCollision left;
    [SerializeField] CheckForCollision right;
    [SerializeField] CheckForCollision up;
    [SerializeField] CheckForCollision down;

    public bool OnGround 
    {
        get 
        {
            return down.isColliding ; 
        } 
    }

    public bool OnWall
    {
        get
        {
            return OnRightWall || OnLeftWall;
        }
    }

    public bool OnCelling
    {
        get
        {
            return up.isColliding;
        }
    }

    public bool OnLeftWall
    {
        get
        {
            return left.isColliding;
        }
    }

    public bool OnRightWall
    {
        get
        {
            return right.isColliding;
        }
    }
}
