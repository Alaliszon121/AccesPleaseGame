using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OUFolder : MonoBehaviour
{
    public Department folderDepartment;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickFolder);
    }

    private void OnClickFolder()
    {
        UIManager.Instance.OnFolderClicked(folderDepartment);
    }
}