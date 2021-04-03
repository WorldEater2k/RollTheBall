
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace RollTheBall
{
    internal sealed class DataRepository
    {
        private readonly IData<SavedData> _data;
        private const string _folderName = "SavedData";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public DataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(Player player)
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            var savedData = new SavedData
            {
                PlayerName = "Liza",
                PlayerType = player is PlayerBall ? PlayerType.Ball
                    : player is PlayerCube ? PlayerType.Cube
                    : PlayerType.Cylinder,
                PlayerPosition = player.transform.position,
                BonusPositions = FindBonusPositions()
            };

            _data.Save(savedData, Path.Combine(_path, _fileName));
        }

        public void Load()
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
                return;
            var newData = _data.Load(file);

            Object.Destroy(Object.FindObjectOfType<Player>().gameObject);
            switch (newData.PlayerType)
            {
                case PlayerType.Ball:
                    Object.Instantiate(Resources.Load("Players/PlayerBall"), newData.PlayerPosition, Quaternion.identity);
                    break;
                case PlayerType.Cube:
                    Object.Instantiate(Resources.Load("Players/PlayerCube"), newData.PlayerPosition, Quaternion.identity);
                    break;
                default:
                    Object.Instantiate(Resources.Load("Players/PlayerCylinder"), newData.PlayerPosition, Quaternion.identity);
                    break;
            }

            foreach (var obj in Object.FindObjectsOfType<CollectableObject>())
                Object.Destroy(obj.gameObject);
            foreach (var pair in newData.BonusPositions)
            {
                CreateBonuses(pair);
            }
        }

        private void CreateBonuses(KeyValuePair<BonusType, List<Vector3Serializable>> pair)
        {
            foreach (var position in pair.Value)
            {
                switch (pair.Key)
                {
                    case BonusType.Common:
                        Object.Instantiate(Resources.Load("Collectable/CommonBonus"), position, Quaternion.identity);
                        break;
                    case BonusType.Big:
                        Object.Instantiate(Resources.Load("Collectable/BigBonus"), position, Quaternion.identity);
                        break;
                    case BonusType.Small:
                        Object.Instantiate(Resources.Load("Collectable/SmallBonus"), position, Quaternion.identity);
                        break;
                    case BonusType.Invulnerability:
                        Object.Instantiate(Resources.Load("Collectable/Invulnerability"), position, Quaternion.identity);
                        break;
                    case BonusType.Slowdown:
                        Object.Instantiate(Resources.Load("Collectable/Slowdown"), position, Quaternion.identity);
                        break;
                    case BonusType.Boost:
                        Object.Instantiate(Resources.Load("Collectable/Boost"), position, Quaternion.identity);
                        break;
                    case BonusType.Mine:
                        Object.Instantiate(Resources.Load("Collectable/Mine"), position, Quaternion.identity);
                        break;
                }
            }
        }

        private List<Vector3Serializable> GetPositions<T>() where T : CollectableObject
        {
            T[] bonuses = Object.FindObjectsOfType<T>();
            List<Vector3Serializable> list = new List<Vector3Serializable>(bonuses.Length);
            foreach (var bonus in bonuses)
                list.Add(bonus.transform.position);
            return list;
        }

        private Dictionary<BonusType, List<Vector3Serializable>> FindBonusPositions()
        {
            var dic = new Dictionary<BonusType, List<Vector3Serializable>>();

            List<Vector3Serializable> common = GetPositions<CommonBonus>();
            dic.Add(BonusType.Common, common);
            List<Vector3Serializable> big = GetPositions<BigBonus>();
            dic.Add(BonusType.Big, big);
            List<Vector3Serializable> small = GetPositions<SmallBonus>();
            dic.Add(BonusType.Small, small);
            List<Vector3Serializable> invulnerability = GetPositions<Invulnerability>();
            dic.Add(BonusType.Invulnerability, invulnerability);
            List<Vector3Serializable> boost = GetPositions<Boost>();
            dic.Add(BonusType.Boost, boost);
            List<Vector3Serializable> slowdown = GetPositions<Slowdown>();
            dic.Add(BonusType.Slowdown, slowdown);
            List<Vector3Serializable> mine = GetPositions<Mine>();
            dic.Add(BonusType.Mine, mine);

            return dic;
        }
    }
}


