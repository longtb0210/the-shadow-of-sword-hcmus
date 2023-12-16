using UnityEngine;

public class PlayerStats : CharacterStats {

  private Player player;
  protected override void Start() {
    base.Start();

    player = GetComponent<Player>();
  }

  public override void TakeDamage(int _damage) {
    base.TakeDamage(_damage);
  }


  protected override void Die() {
    base.Die();
    player.Die();

    GameManager.instance.lostCurrencyAmount = PlayerManager.instance.currency;
    PlayerManager.instance.currency = 0;

    GetComponent<PlayerItemDrop>()?.GenerateDrop();
  }

  protected override void DecreaseHealthBy(int _damage) {
    base.DecreaseHealthBy(_damage);

    ItemData_Equipment currentAmor = Inventory.instance.GetEquipment(EquipmentType.Armor);

    currentAmor?.Effect(player.transform);
  }

  public override void OnEvasion() {

    player.skill.dodge.CreateMirageOnDodge();
  }

  public void CloneDoDamage(CharacterStats _targetStats, float _multiplier) {

    if (TargetCanAvoidAttack(_targetStats)) return;

    int totalDamage = damage.GetValue() + strength.GetValue();

    if (_multiplier > 0)
      totalDamage = Mathf.RoundToInt(totalDamage * _multiplier);

    if (CanCrit()) {
      totalDamage = CalculateCriticalDamage(totalDamage);
    }

    totalDamage = CheckTargetArmor(_targetStats, totalDamage);
    _targetStats.TakeDamage(totalDamage);

    DoMagicalDamage(_targetStats); // remove if you dont want to apply magic hit on primary attack

  }
}
