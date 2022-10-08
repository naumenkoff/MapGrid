# Map Grid

Map Grid allows you to find out the text-square location based on the coordinates.

## Use for developers (as __API__)

```
string PositionToGridCoord(Vector3 position)
```

Add my plugin as a reference to your plugin
```
[PluginReference] private Plugin MapGrid;
```

Next, call the __PositionToGridCoord__ method with a Vector3 type parameter and cast to string
```
(string) MapGrid.Call("PositionToGridCoord", Vector3.zero)
```

__Example:__
```
[PluginReference] private Plugin MapGrid;

[ChatCommand("myPosition")]
private void DisplayPlayerGrid(BasePlayer player)
{
    var gridPosition = (string) MapGrid.Call("PositionToGridCoord", player.transform.position);
    player.ChatMessage(gridPosition);
}
```

## Using the plugin itself
It can be used both through the in-game console and through the server console.
##### Via Server Console
```
mg.show x y z
```

__Example:__
```
> mg.show 322.2 533.3 144.4
(322.2, 533.3, 144.4) -> [J5]
```

##### Via In-Game Console
```
mg.show
```

__Example:__
```
> mg.show
(60.0, 36.0, 255.1) -> [H4]
```

