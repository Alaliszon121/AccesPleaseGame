using UnityEngine;

public class SetAminationParameters : MonoBehaviour
{
    Animator animator;
    bool lastbool = true;
    void Start()
    {
        try
        {
            animator = gameObject.GetComponent<Animator>();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void changeBool()
    {
        lastbool = !lastbool;
        if(animator!= null)
            animator.SetBool("opened", lastbool);
    }

    public void changeBoolToFalse()
    {
        lastbool = false;
        animator.SetBool("opened", lastbool);
    }
}
