using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Limbus_Combat_Console
{
    public static class JsonParser
    {
        public static void LoadType(string path)
        {
            Global.Type = JsonSerializer.Deserialize<TypeData>(File.ReadAllText(path));
        }

        public static CharacterData LoadCharacterData(string path)
        {
            CharacterData data = JsonSerializer.Deserialize<CharacterData>(File.ReadAllText(path));
            foreach (var item in data.Skills)
            {
                LoadSkill("../../../json/Skills.json", item.Id);
            }
            return data;
        }

        public static void LoadSkill(string path, int Id)
        {
            if (Global.SkillPool.TryGetValue(Id, out SkillData skl) == true) { return; }
            JsonNode root = JsonNode.Parse(File.ReadAllText(path));
            foreach(var item in root as JsonArray)
            {
                if (item["Id"].GetValue<int>() == Id)
                {
                    SkillData skill = JsonSerializer.Deserialize<SkillData>(item.ToJsonString());
                    Global.SkillPool.Add(skill.Id, skill);
                }
            }
        }
    }
}
