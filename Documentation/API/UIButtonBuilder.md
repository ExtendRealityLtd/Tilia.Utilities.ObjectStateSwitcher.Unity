# Class UIButtonBuilder

Manages the drawing of the UI Buttons for the [Switcher] and assigning their actions.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedIndexCollection]
  * [labelPrefix]
  * [panelSize]
  * [sourceButtons]
* [Properties]
  * [ButtonHeightPadding]
  * [Container]
  * [ContainerRect]
  * [PanelHeightPadding]
  * [SourceButton]
  * [Switcher]
* [Methods]
  * [Awake()]
  * [CreateButton(GameObject)]
  * [DeleteButton(GameObject)]
  * [IsValid()]
  * [RedrawButtons()]
  * [SwitchTo(Int32)]
  * [SwitchToCachedIndex(Int32)]
  * [TryGetCachedIndex(out Int32)]

## Details

##### Inheritance

* System.Object
* UIButtonBuilder

##### Namespace

* [Tilia.Utilities.ObjectStateSwitcher]

##### Syntax

```
public class UIButtonBuilder : MonoBehaviour
```

### Fields

#### cachedIndexCollection

The current cached index that will persist across scene changes.

##### Declaration

```
protected static Dictionary<string, int> cachedIndexCollection
```

#### labelPrefix

The prefix to use when creating new button GameObjects.

##### Declaration

```
protected const string labelPrefix = "Button."
```

#### panelSize

The inital size of the panel.

##### Declaration

```
protected Vector2 panelSize
```

#### sourceButtons

A collection of generated buttons linked to the source GameObject they are created for.

##### Declaration

```
protected Dictionary<GameObject, GameObject> sourceButtons
```

### Properties

#### ButtonHeightPadding

The default height padding between each button.

##### Declaration

```
public float ButtonHeightPadding { get; set; }
```

#### Container

The GameObject container of the buttons.

##### Declaration

```
public GameObject Container { get; set; }
```

#### ContainerRect

The RectTransform associated with the container panel.

##### Declaration

```
public RectTransform ContainerRect { get; set; }
```

#### PanelHeightPadding

The default padding for the final panel height.

##### Declaration

```
public float PanelHeightPadding { get; set; }
```

#### SourceButton

The GameObject that holds the source Button for the UI.

##### Declaration

```
public GameObject SourceButton { get; set; }
```

#### Switcher

The state switcher.

##### Declaration

```
public GameObjectStateSwitcher Switcher { get; set; }
```

### Methods

#### Awake()

##### Declaration

```
protected virtual void Awake()
```

#### CreateButton(GameObject)

Creates a new UI Button that will enable the given Source.

##### Declaration

```
public virtual void CreateButton(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The GameObject to enable. |

#### DeleteButton(GameObject)

Deletes an existing UI Button.

##### Declaration

```
public virtual void DeleteButton(GameObject source)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | source | The GameObject being removed. |

#### IsValid()

Determines if the relevant parameters are present.

##### Declaration

```
protected virtual bool IsValid()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether the relevant parameters are present. |

#### RedrawButtons()

Redraws the UI buttons.

##### Declaration

```
protected virtual void RedrawButtons()
```

#### SwitchTo(Int32)

Switches the [Switcher] to the given index.

##### Declaration

```
public virtual void SwitchTo(int index)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | index | The index to switch to. |

#### SwitchToCachedIndex(Int32)

Switches the [Switcher] to the current cached index.

##### Declaration

```
public virtual void SwitchToCachedIndex(int defaultWhenNoCachedIndex = 0)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | defaultWhenNoCachedIndex | The index to switch to if no cached index is present. |

#### TryGetCachedIndex(out Int32)

Attempts to receive the cached index for the current switcher.

##### Declaration

```
public virtual bool TryGetCachedIndex(out int cachedIndex)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Int32 | cachedIndex | The reference to the found cached index. |

##### Returns

| Type | Description |
| --- | --- |
| System.Boolean | Whether a cached index was found. |

[Switcher]: UIButtonBuilder.md#Switcher
[Tilia.Utilities.ObjectStateSwitcher]: README.md
[Switcher]: UIButtonBuilder.md#Switcher
[Switcher]: UIButtonBuilder.md#Switcher
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedIndexCollection]: #cachedIndexCollection
[labelPrefix]: #labelPrefix
[panelSize]: #panelSize
[sourceButtons]: #sourceButtons
[Properties]: #Properties
[ButtonHeightPadding]: #ButtonHeightPadding
[Container]: #Container
[ContainerRect]: #ContainerRect
[PanelHeightPadding]: #PanelHeightPadding
[SourceButton]: #SourceButton
[Switcher]: #Switcher
[Methods]: #Methods
[Awake()]: #Awake
[CreateButton(GameObject)]: #CreateButtonGameObject
[DeleteButton(GameObject)]: #DeleteButtonGameObject
[IsValid()]: #IsValid
[RedrawButtons()]: #RedrawButtons
[SwitchTo(Int32)]: #SwitchToInt32
[SwitchToCachedIndex(Int32)]: #SwitchToCachedIndexInt32
[TryGetCachedIndex(out Int32)]: #TryGetCachedIndexout Int32
