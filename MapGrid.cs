using System;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Map Grid", "naumenkoff", "0.1.1")]
    internal class MapGrid : RustPlugin
    {
        private void Init()
        {
            cmd.AddConsoleCommand("mg.show", this, "GetGrid");
        }

        private void GetGrid(ConsoleSystem.Arg args)
        {
            if (args.IsAdmin == false) return;
            
            if (args.IsRcon)
            {
                if (args.HasArgs(3) == false)
                {
                    args.ReplyWith("Enter \"mg.show x y z\".");
                    return;
                }
                var rconPosition = new Vector3(args.GetFloat(0), args.GetFloat(1), args.GetFloat(2));
                args.ReplyWith($"{rconPosition.ToString()} -> [{PositionToGridCoord(rconPosition)}]");
                return;
            }
            
            var player = args.Player();
            var position = player.transform.position;
            player.ConsoleMessage($"{position.ToString()} -> [{PositionToGridCoord(position)}]");
        }

        // Token: 0x06002702 RID: 9986 RVA: 0x000D9D2C File Offset: 0x000D7F2C
        // string PhoneController.PositionToGridCoord(vector3 position)
        private string PositionToGridCoord(Vector3 position)
        {
            var a = new Vector2(TerrainMeta.NormalizeX(position.x), TerrainMeta.NormalizeZ(position.z));
            var num = TerrainMeta.Size.x / 1024f;
            const int num2 = 7;
            var vector = a * num * num2;
            var num3 = Mathf.Floor(vector.x) + 1f;
            var num4 = Mathf.Floor(Mathf.Round(num) * num2 - vector.y) - 1;
            var text = string.Empty;
            var num5 = num3 / 26f;
            var num6 = num3 % 26f;
            if (num6 == 0f) num6 = 26f;
            if (num5 > 1f) text += Convert.ToChar(64 + (int)num5).ToString();
            text += Convert.ToChar(64 + (int)num6).ToString();
            return $"{text}{num4}";
        }
    }
}