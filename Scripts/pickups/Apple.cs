using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeed = 3f;

    LevelGenerator levelGenerator;

     void Start()
    {
      levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }
    protected override void Onpickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeed); 
    }
}
