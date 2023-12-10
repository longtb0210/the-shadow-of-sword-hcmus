using UnityEngine;

public class UI : MonoBehaviour {
  [SerializeField] private GameObject characterUI;
  [SerializeField] private GameObject skillTreeUI;
  [SerializeField] private GameObject craftUI;
  [SerializeField] private GameObject optionsUI;


  public UI_SkillToolTip skillToolTip;
  public UI_ItemToolTip itemToolTip;
  public UI_StatToolTip statToolTip;
  public UI_CraftWindow craftWindow;



  // Start is called before the first frame update
  void Start() {
    SwitchTo(null);
    itemToolTip.gameObject.SetActive(false);
    statToolTip.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.C)) {
      SwitchWithKeyTo(characterUI);
    }

    if (Input.GetKeyDown(KeyCode.B)) {
      SwitchWithKeyTo(craftUI);
    }

    if (Input.GetKeyDown(KeyCode.K)) {
      SwitchWithKeyTo(skillTreeUI);
    }

    if (Input.GetKeyDown(KeyCode.O)) {
      SwitchWithKeyTo(optionsUI);
    }
  }

  public void SwitchTo(GameObject _menu) {
    for (int i = 0; i < transform.childCount; i++)
      transform.GetChild(i).gameObject.SetActive(false);

    if (_menu)
      _menu.SetActive(true);
  }

  public void SwitchWithKeyTo(GameObject _menu) {
    if (_menu != null && _menu.activeSelf) {
      _menu.SetActive(false);
      return;
    }
    SwitchTo(_menu);
  }
}