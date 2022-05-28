using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        public UnitEditing unitEditingUI;

        public void EnableUnitUI(Unit unit)
        {
            unitEditingUI.selectedUnit = unit;
            unitEditingUI.GenerateUIForUnit();
            unitEditingUI.gameObject.SetActive(true);
        }
        
        public void DisableUnitUI()
        {
            unitEditingUI.selectedUnit = null;
            unitEditingUI.gameObject.SetActive(false);
        }
    }
}