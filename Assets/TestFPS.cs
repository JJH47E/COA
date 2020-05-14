using UnityEngine;
 
public class TestFPS : MonoBehaviour {
 
    #region "Variables"
    public Rigidbody Rigid;
    public float MoveSpeed;
    public float JumpForce;
    private bool canJump;
    #endregion
   
    void Update ()
    {
        Rigid.velocity = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, 0f, Input.GetAxis("Vertical") * MoveSpeed);
    }
}