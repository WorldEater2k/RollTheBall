using UnityEngine;

namespace RollTheBall
{
    internal delegate T FindObject<out T>(); //ковариантность - может возвращать и T, и его наследников
    internal delegate string ObjectInfo<in T>(T obj); //контрвариантность - может принимать и T, и его предков
    internal sealed class DelegatesExample
    {
        private FindObject<Bonus> findBonusList;
        private ObjectInfo<Bonus> bonusInfoList;

        private void Example()
        {
            findBonusList += FindBonus;
            findBonusList += FindSmallBonus;
            findBonusList += FindBigBonus;

            bonusInfoList += BonusInfo;
            bonusInfoList += CollectableInfo;
            bonusInfoList += Info;
        }

        private Bonus FindBonus()
        {
            return Object.FindObjectOfType<Bonus>();
        }
        private SmallBonus FindSmallBonus()
        {
            return Object.FindObjectOfType<SmallBonus>();
        }
        private BigBonus FindBigBonus()
        {
            return Object.FindObjectOfType<BigBonus>();
        }
        private string CollectableInfo(CollectableObject obj)
        {
            return "Collectable object type: " + obj.GetType();
        }
        private string BonusInfo(Bonus bonus)
        {
            return "Value: " + bonus.Value;
        }
        private string Info(Object obj)
        {
            return "Object type: " + obj.GetType();
        }
    }
}
